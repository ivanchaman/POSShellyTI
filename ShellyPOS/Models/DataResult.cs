using Newtonsoft.Json;
using System.Net;
using ShellyPOS.Helper;
namespace ShellyPOS.Models
{
    public class DataResult<TSuccess, TError>
    {
        public bool Status { get; }
        public HttpStatusCode StatusCode { get; }
        public string Message { get; }
        public string? Result { get; }
        public TSuccess? Data { get; set; }
        public TError? Errors { get; set; }
        private DataResult(bool status, HttpStatusCode statusCode, string message) : this(status, statusCode, message, "")
        {

        }

        private DataResult(bool status, HttpStatusCode statusCode, string message, string? result)
        {
            this.Status = status;
            this.StatusCode = statusCode;
            this.Message = message;
            this.Result = result;
            switch (statusCode)
            {
                case HttpStatusCode.OK: //201
                case HttpStatusCode.Created:
                case HttpStatusCode.Accepted:

                    Data = result.ConvertJsonToObject<TSuccess>();
                    break;
                case HttpStatusCode.Unauthorized: //401
                    Errors = result.ConvertJsonToObject<TError>();
                    break;
                case HttpStatusCode.BadRequest: //400
                    Errors = result.ConvertJsonToObject<TError>();
                    break;
                case HttpStatusCode.InternalServerError: //500
                    Errors = result.ConvertJsonToObject<TError>();
                    break;
                case HttpStatusCode.ServiceUnavailable: //500
                    Errors = result.ConvertJsonToObject<TError>();
                    break;
                default:
                    Errors = result.ConvertJsonToObject<TError>();
                    break;
            }


        }
        public static DataResult<TSuccess, TError> Success(string? result)
        {
            return new DataResult<TSuccess, TError>(true, HttpStatusCode.OK, "200-La solicitud a sido exitosa", result);
        }
        public static DataResult<TSuccess, TError> Created(string? result)
        {
            return new DataResult<TSuccess, TError>(true, HttpStatusCode.Created, "201-La solicitud ha tenido éxito y se ha creado un nuevo recurso como resultado de ello", result);
        }
        public static DataResult<TSuccess, TError> BadRequest(string? result)
        {
            return new DataResult<TSuccess, TError>(false, HttpStatusCode.BadRequest, "400-Solicitud erronea,formato del objeto incorrecto. Contactar al administrador ", result);
        }
        public static DataResult<TSuccess, TError> Unauthorized(string? result)
        {
            return new DataResult<TSuccess, TError>(false, HttpStatusCode.Unauthorized, "401-Usuario no autorizado,No se ha indicado o es incorrecto el Token JWT de acceso, es necesario volver a iniciar sesión. Si persiste el problema contactar al administrador.", result);
        }
        public static DataResult<TSuccess, TError> InternalServerError(string? result)
        {
            return new DataResult<TSuccess, TError>(false, HttpStatusCode.InternalServerError, "500-Error interno. Contactar al administrador", result);
        }
        public static DataResult<TSuccess, TError> ServiceUnavailable(string? result)
        {
            return new DataResult<TSuccess, TError>(false, HttpStatusCode.ServiceUnavailable, "503-Servidor no disponible. Contactar al administrador", result);
        }
        public static DataResult<TSuccess, TError> Fail(string? code, string? result)
        {
            return new DataResult<TSuccess, TError>(false, HttpStatusCode.ServiceUnavailable, $"{code}-Ocurrió un error en el servidor. Contactar al administrador.", result);
        }
        public static DataResult<TSuccess, TError> Error(string error, string? result)
        {
            return new DataResult<TSuccess, TError>(false, HttpStatusCode.ServiceUnavailable, $"{error}. Contactar al administrador.", result);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
