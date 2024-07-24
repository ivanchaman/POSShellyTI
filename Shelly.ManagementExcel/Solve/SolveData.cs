

using Shelly.Abstractions.Constants;

namespace Shelly.ManagementExcel.Solve
{
     public partial class SolveData
     {
          private List<FieldsPreload> _FieldsPrecompilated;
          private EvaluateFormula _oEvaluator;
      
          public bool isConceptsPrecompilated { get; set; }
          public Dictionary<string, object> Parameters { get; set; }
          public int FieldsNumber { get; set; }
          public string Asset { get; set; }
          public SolveData()
          {
               Init();
          }
         
          private void Init()
          {
               _oEvaluator = new EvaluateFormula();
               Parameters = new Dictionary<string, object>();
          }

          public void AddParameter(string name, object value)
          {
               Parameters[name] = value;
          }
         
          public T Solve<T>(string formula)
          {
               object value;
               value = Solve(formula, 1);
               if (Convert.IsDBNull(value) || String.IsNullOrEmpty(Convert.ToString(value)))
                    return ExtensionStrings.GetDefaultValue<T>();
               return (T)Convert.ChangeType(value, typeof(T));
          }
          
          public T Solve<T>(string formula, int resultEvaluate)
          {
               object value;
               value = Solve(formula, resultEvaluate);
               if (Convert.IsDBNull(value) || String.IsNullOrEmpty(Convert.ToString(value)))
                    return ExtensionStrings.GetDefaultValue<T>();
               return (T)Convert.ChangeType(value, typeof(T));
          }
         
          public object Solve(string formula)
          {
               return Solve(formula, 1);
          }
        
          public object Solve(string formula, int resultEvaluate)
          {
               string result;
               result = "";
               try
               {
                    if (string.IsNullOrEmpty(formula) || formula == "0")
                         return 0;                  
                    result = formula.ToUpper();
                    result = SolveDictionaryParameters(result);
                    if (isConceptsPrecompilated)
                         result = ResolveFieldsBySymbols(formula);
                    else
                         result = ResolvePrecompiledFields(result);                   
                    result = ExtensionStrings.Replace(result, "REPLICATESTRING", "REPT");
                    if (ExtensionStrings.InStr(ExtensionStrings.UCase(result), "NUMERICTEXT(") > 0)
                         result = ExtensionStrings.Replace(result, "NUMERICTEXT", "ISNUMBER");
                    if (string.IsNullOrEmpty(ExtensionStrings.Trim(result)) || result == Convert.ToString((char)(34) + (char)(34)))
                         result = "0";
                    if (ExtensionStrings.Trim(result) == "0")
                         return -1;
                    if (resultEvaluate != 1)
                         return result;

                    if (ExtensionStrings.Len(result) <= 2501)
                    {
                         return Evaluate(result);
                    }
                    else
                    {
                         return -1;
                    }
               }
               catch (ApplicationException ax)
               {
                    return -1;
               }
               catch (Exception ex)
               {
                    return -1;
               }
          }
          private string ResolvePrecompiledFields(string formula)
          {
               int position;
               string field;
               if (FieldsNumber == -1)
                    return formula;
               while (ExtensionStrings.InStr(formula, "$") > 0)
               {
                    position = ExtensionStrings.InStr(formula, "$");
                    field = ExtensionStrings.Mid(formula, position + 1, ExtensionStrings.InStr(position + 1, formula, "$") - position - 1);
                    if (ExtensionStrings.InStr(ExtensionStrings.UCase(_FieldsPrecompilated[Convert.ToInt32(field)].Field), "VALORES(") > 0 || ExtensionStrings.InStr(ExtensionStrings.UCase(_FieldsPrecompilated[Convert.ToInt32(field)].Field), "VALFECHA(") > 0)
                         formula = ExtensionStrings.Replace(formula, "$" + field + "$", _FieldsPrecompilated[Convert.ToInt32(field)].Value);
                    else if (ExtensionStrings.IsNumeric(_FieldsPrecompilated[Convert.ToInt32(field)].Value))
                         formula = ExtensionStrings.Replace(formula, "$" + field + "$", _FieldsPrecompilated[Convert.ToInt32(field)].Value);
                    else if (ExtensionDates.IsDate(_FieldsPrecompilated[Convert.ToInt32(field)].Value))
                         formula = ExtensionStrings.Replace(formula, "$" + field + "$", "DATE(" + Convert.ToDateTime(_FieldsPrecompilated[Convert.ToInt32(field)].Value).ToString("yyyy,MM,dd") + ")");
                    else
                         formula = ExtensionStrings.Replace(formula, "$" + field + "$", (char)(34) + _FieldsPrecompilated[Convert.ToInt32(field)].Value + (char)(34));
               }
               return formula;
          }
          private string ResolveFieldsBySymbols(string formula)
          {
               formula = ReplacesFieldsTypes(formula, "%EMPD", "%", false, true);
               formula = ReplacesFieldsTypes(formula, "CONVERTTOCRYPTO(", ")", true, false);
               formula = ReplacesFieldsTypes(formula, "DIASENTREPERIODO(", ")", true, false);
               formula = ReplacesFieldsTypes(formula, "SALDOVACACIONES(", ")", false, false);
               formula = ReplacesFieldsTypes(formula, "ANIVERSARIO(", ")", true, false);
               formula = ReplacesFieldsTypes(formula, "ACUMULADOTOTALFECHASAPLICACION(", ")", true, false);
               formula = ReplacesFieldsTypes(formula, "ACUMULADOTOTALFECHAS(", ")", true, false);
               formula = ReplacesFieldsTypes(formula, "GROWSUP(", ")", true, false);
               formula = ReplacesFieldsTypes(formula, "VALORES(", ")", true, false);
               formula = ReplacesFieldsTypes(formula, "ROUNDMULT(", ")", true, false);
               formula = ReplacesFieldsTypes(formula, "VALFECHA(", ")", true, false);
               formula = ReplacesFieldsTypes(formula, "FECHAINICIOPERIODO(", ")", true, false);
               formula = ReplacesFieldsTypes(formula, "FECHAFINALPERIODO(", ")", true, false);
               formula = ReplacesFieldsTypes(formula, "PERIODO(", ")", true, false);
               formula = ReplacesFieldsTypes(formula, "ACUMULADO(", ")", true, false);
               formula = ReplacesFieldsTypes(formula, "ACUMULADOYM(", ")", true, false);
               formula = ReplacesFieldsTypes(formula, "AC(", ")", true, false);
               formula = ReplacesFieldsTypes(formula, "AMN(", ")", true, false);
               formula = ReplacesFieldsTypes(formula, "BASES(", ")", true, false);
               formula = ReplacesFieldsTypes(formula, "%ACU", "%", true, false);
               formula = ReplacesFieldsTypes(formula, "REFERENCIAD(", ")", true, false);
               formula = ReplacesFieldsTypes(formula, "ANTIGÜEDAD(", ")", false, false);
               formula = ReplacesFieldsTypes(formula, "%FORD", "%", false, false);
               formula = ReplacesFieldsTypes(formula, "CAMPOALAFECHA(", ")", false, false);
               formula = ReplacesFieldsTypes(formula, "EXTRAEDATO(", ")", false, false);
               formula = ReplacesFieldsTypes(formula, "%", "%", false, false);
               return formula;
          }
          private string ReplacesFieldsTypes(string formula, string startCaracter, string endCaracter, bool isSolveEachConcept, bool isSolveRightNow)
          {
               string field;
               int position;
               if (ExtensionStrings.InStr(ExtensionStrings.UCase(formula), startCaracter) == 0)
                    return formula;
               while (ExtensionStrings.InStr(ExtensionStrings.UCase(formula), startCaracter) != 0)
               {
                    position = ExtensionStrings.InStr(ExtensionStrings.UCase(formula), startCaracter);

                    field = startCaracter != "AC("
                         && startCaracter != "BASES("
                         && startCaracter != "AMN("
                         && startCaracter != "VALORES("
                         && startCaracter != "GROWSUP("
                         && startCaracter != "ROUNDMULT("
                         && startCaracter != "PERIODO("
                         && startCaracter != "ACUMULADO("
                         && startCaracter != "VALFECHA("
                         && startCaracter != "ACUMULADOYM("
                         && startCaracter != "REFERENCIAD("
                         && startCaracter != "CAMPOALAFECHA("
                         && startCaracter != "FALTASXPERIOD("
                         && startCaracter != "SALARIOXPERIOD("
                         && startCaracter != "EXTRAEDATO("
                         && startCaracter != "ACUMULADOTOTALFECHASAPLICACION("
                         && startCaracter != "ACUMULADOTOTALFECHAS("
                         && startCaracter != "DIASENTREPERIODO("
                         && startCaracter != "SALDOVACACIONES("
                         && startCaracter != "CONVERTTOCRYPTO("
                         ? ExtensionStrings.Mid(formula, position, ExtensionStrings.InStr(position + 1, formula, endCaracter) - position + 1)
                         : ExtensionStrings.Mid(formula, position, ParenthesisPrositionClosing(formula, position) - position + 1);
                    if (isSolveRightNow)
                    {
                         isConceptsPrecompilated = false;
                         formula = ExtensionStrings.Replace(formula, field, Solve<string>(field));
                         isConceptsPrecompilated = true;
                    }
                    else
                    {
                         position = FieldPosition(field);
                         if (position == -1)
                         {
                              FieldsNumber++;
                              position = FieldsNumber;
                              if (_FieldsPrecompilated == null)
                                   _FieldsPrecompilated = new List<FieldsPreload>();// [position];
                              _FieldsPrecompilated.Add(new FieldsPreload
                              {
                                   Field = field,
                                   Value = "0",
                                   isCalculateRealTime = isSolveEachConcept
                              });
                         }
                         formula = ExtensionStrings.Replace(formula, field, "$" + position + "$");                        
                    }
               }
               return formula;
          }
          private int ParenthesisPrositionClosing(string text, int position = 1)
          {
               int index;
               int openParenthesis = 0;
               for (index = position; index <= ExtensionStrings.Len(text); index = (index + 1))
               {
                    if (ExtensionStrings.Mid(text, index, 1) == "(")
                         openParenthesis++;
                    if (ExtensionStrings.Mid(text, index, 1) == ")")
                    {
                         openParenthesis--;
                         if (openParenthesis == 0)
                              break;
                    }
               }
               return index;
          }
          private int FieldPosition(string fieldSearch)
          {
               for (int index = 0; index <= FieldsNumber; index++)
               {
                    if (_FieldsPrecompilated[index].Field == fieldSearch)
                         return index;
               }
               return -1;
          }

          private string SolveDictionaryParameters(string formula)
          {
               int position;
               string field;

               if (!formula.Contains("##") || Parameters == null)
                    return formula;
               if (Parameters.Count == 0)
                    return formula;
               while (ExtensionStrings.InStr(formula, "##") > 0)
               {
                    position = ExtensionStrings.InStr(formula, "##");
                    field = ExtensionStrings.Mid(formula, position + 2, ExtensionStrings.InStr(position + 1, formula, "##") - position - 2).ToUpper();
                    if (Parameters.ContainsKey(field))
                    {
                         if (ExtensionStrings.IsNumeric(Parameters[field]))
                              formula = ExtensionStrings.Replace(formula, $"##{field}##", Parameters[field].ToString());
                         else if (ExtensionDates.IsDate(Parameters[field]))
                              formula = ExtensionStrings.Replace(formula, $"##{field}##", "DATE(" + Convert.ToDateTime(Parameters[field]).ToString("yyyy,MM,dd") + ")");
                         else
                              formula = ExtensionStrings.Replace(formula, $"##{field}##", (char)(34) + Parameters[field].ToString() + (char)(34));
                    }
                    else
                         formula = ExtensionStrings.Replace(formula, $"##{field}##", $"Parametro desconocido -- {field} --");
               }
               return formula;
          }
          private object Evaluate(string formula)
          {               
               try
               {
                    return _oEvaluator.Evaluate(formula);
               }
               catch
               {
                    return -1;
               }
          }
          /// <summary>
          /// Verifications the parameters in formulas.
          /// </summary>
          /// <param name="formula">The formula.</param>
          /// <returns></returns>
          public bool VerificationParametersInFormulas(string formula, out string message)
          {
               string[] parameters;
               int totalParameters;
               int indexParameter;
               bool isFails;
               string totalparameters;
               StringBuilder messagetext;
               string aux;
               int startPosition;
               int endPosition;
               bool isNoParameters;
               Dictionary<string, int[]> list;
               message = "";
               if (String.IsNullOrEmpty(formula) || formula == "0")
                    return true;
               messagetext = new StringBuilder();
               aux = formula.ToUpper();
               list = GetDictionayFormula();
               foreach (KeyValuePair<string, int[]> element in list)
               {
                    while (ExtensionStrings.InStr(ExtensionStrings.UCase(aux), String.Format("{0}(", element.Key)) > 0)
                    {
                         startPosition = ExtensionStrings.InStr(ExtensionStrings.UCase(aux), element.Key);
                         endPosition = GetLastPosicionChar(ExtensionStrings.UCase(aux), ")", startPosition + ExtensionStrings.Len(element.Key), true);
                         parameters = GetParameters(element.Key, aux);
                         totalParameters = 0;
                         isFails = true;
                         isNoParameters = false;
                         for (indexParameter = 0; indexParameter < element.Value.Length; indexParameter++)
                         {
                              if (parameters.Length != element.Value[indexParameter])
                              {
                                   if (element.Value[indexParameter] == 0 && parameters.Length == 1)
                                   {
                                        isFails = false;
                                        isNoParameters = true;
                                        break;
                                   }
                                   isNoParameters = false;
                                   isFails = true;
                              }
                              else
                              {
                                   isNoParameters = false;
                                   isFails = false;
                                   break;
                              }
                         }
                         if (isFails)
                         {
                              totalparameters = "";
                              for (indexParameter = 0; indexParameter < element.Value.Length; indexParameter++)
                              {
                                   totalparameters += String.Format("{0},", element.Value[indexParameter]);
                              }
                              totalparameters = totalparameters.Substring(0, totalparameters.Length - 1);
                              messagetext.AppendFormat("Function {0} must have at least {1} parameters.", element.Key, totalparameters);
                              messagetext.AppendLine();
                         }
                         foreach (string Ls_Parametro in parameters)
                         {
                              if (String.IsNullOrEmpty(Ls_Parametro))
                                   totalParameters++;
                         }
                         if ((totalParameters != 0) && !isNoParameters)
                         {
                              messagetext.AppendFormat(" Function {0} is missing parameters to assign.", element.Key);
                              messagetext.AppendLine();
                         }
                         aux = ExtensionStrings.Mid(aux, 1, startPosition - 1) + ExtensionStrings.Mid(aux, endPosition + 1);
                    }
               }
               if (!String.IsNullOrEmpty(messagetext.ToString()))
               {
                    messagetext.AppendFormat(" The formula: {0}", formula);
                    message = messagetext.ToString();
                    return false;
               }
               message = messagetext.ToString();
               return true;
          }
          public int Occurred(string text, string caracter)
          {
               int count = 0;
               int textLenght = ExtensionStrings.Len(text);
               int caracerLength = ExtensionStrings.Len(caracter);
               int num = textLenght;
               for (int index = 1; index <= num; index++)
               {
                    if (ExtensionStrings.Mid(text, index, caracerLength) == caracter)
                         count++;
               }
               return count;
          }
          /// <summary>
          /// Precompiles the fields enabled employee.
          /// </summary>
          public void PrecompileFieldsEnabledEmployee()
          {
               if (_FieldsPrecompilated == null)
                    return;
               foreach (FieldsPreload field in _FieldsPrecompilated)
               {
                    if (field.isCalculateRealTime)
                         continue;
                    field.Value = Solve<string>(field.Field);
               }
          }
          private int GetLastPosicionChar(string text, string search, int startPosition = 0, bool isVerifyFunctions = false)
          {
               int position;
               int parenthesis = 0;
               for (position = (startPosition == 0 ? (ExtensionStrings.InStr(text, "(") + 1) : startPosition); position <= ExtensionStrings.Len(text); position++)
               {
                    if (parenthesis == 0 && ExtensionStrings.Mid(text, position, ExtensionStrings.Len(search)) == search)
                         return position;
                    else if (ExtensionStrings.Mid(text, position, 1) == "(")
                         parenthesis++;
                    else if (ExtensionStrings.Mid(text, position, 1) == ")")
                    {
                         parenthesis--;
                         if (parenthesis == 0 && ExtensionStrings.Mid(text, position, ExtensionStrings.Len(search)) == search && isVerifyFunctions)
                              return position;
                    }
               }
               return 0;
          }

          private string[] GetParameters(string psNombreFuncion, string formula, int initialPosition = -1)
          {
               int startPosition;
               string nextCaracter;
               string value;
               int parameter;
               int endPosition;
               string[] parameters;
               if (Occurred(formula, "(") != Occurred(formula, ")"))
               {
                    throw new CoreException(Errors.E00000007, formula);
               }
               startPosition = (initialPosition > 0 ? ExtensionStrings.InStr(initialPosition, ExtensionStrings.UCase(formula), string.Concat(ExtensionStrings.UCase(psNombreFuncion), "(")) : ExtensionStrings.InStr(ExtensionStrings.UCase(formula), string.Concat(ExtensionStrings.UCase(psNombreFuncion), "(")));
               parameter = 0;
               parameters = null;
               if (startPosition == 0)
                    return parameters;
               startPosition = ExtensionStrings.InStr(startPosition + 1, formula, "(");
               while (true)
               {
                    endPosition = GetLastPosicionChar(formula, ",", (startPosition + 1), false);
                    if (endPosition == 0)
                         endPosition = ExtensionStrings.Len(formula);
                    nextCaracter = (endPosition >= GetLastPosicionChar(formula, ")", (startPosition + 1), false) ? ")" : ",");
                    endPosition = GetLastPosicionChar(formula, nextCaracter, (startPosition + 1), false);
                    value = ExtensionStrings.Mid(formula, (startPosition + 1), (endPosition - startPosition) - 1);
                    Array.Resize(ref parameters, parameter + 1);
                    parameters[parameter] = ExtensionStrings.Trim(value);
                    parameter = (parameter + 1);
                    startPosition = endPosition;
                    if (nextCaracter == ")")
                         break;
               }
               return parameters;

          }
          private Dictionary<string, int[]> GetDictionayFormula()
          {
               return new Dictionary<string, int[]>
               {
                    { "HORARIO", new int[] { 2 } },
                    { "VALORES", new int[] { 3, 4 } },
                    { "GROWSUP", new int[] { 4 } },
                    { "ANTIGÜEDAD", new int[] { 2, 3 } },
                    { "ROUNDMULT", new int[] { 3 } },
                    { "VALFECHA", new int[] { 4 } },
                    { "SALARIOXPERIOD", new int[] { 2 } },
                    { "FALTASXPERIOD", new int[] { 3 } },
                    { "DIASENTREPERIODO", new int[] { 1, 3 } },
                    { "FECHAINICIOPERIODO", new int[] { 0 } },
                    { "FECHAFINALPERIODO", new int[] { 0 } },
                    { "REFERENCIAD", new int[] { 2 } },
                    { "ANIVERSARIO", new int[] { 1 } },
                    { "SALDOVACACIONES", new int[] { 1, 2 } },
                    { "ACUMULADO", new int[] { 2 } },
                    { "ACUMULADOYM", new int[] { 3 } },
                    { "TABSHCP", new int[] { 3 } },
                    { "CAMPOALAFECHA", new int[] { 2 } },
                    { "EXTRAEDATO", new int[] { 3 } },
                    { "ACUMULADOTOTALFECHASAPLICACION", new int[] { 2 } },
                    { "ACUMULADOTOTALFECHAS", new int[] { 2 } },
                    { "BASES", new int[] { 2 } },
                    { "AMN", new int[] { 2 } },
                    { "MATRIZ", new int[] { 2 } },
                    { "CONCEPTOEXC", new int[] { 2 } },
                    { "FECHAEXC", new int[] { 2 } },
                    { "FECHA", new int[] { 1, 3 } },
                    { "MESES", new int[] { 1 } },
                    { "REFERENCIA", new int[] { 1 } },
                    { "CONVERTTOCRYPTO", new int[] { 1 } },
                    { "PERIODO", new int[] { 2 } }
               };
          }
     }

}
