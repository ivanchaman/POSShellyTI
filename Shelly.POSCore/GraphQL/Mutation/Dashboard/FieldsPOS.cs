using Shelly.POSCore.GraphQL.InputTypes;
using Shelly.ProviderData.Repository.Entity;

namespace Shelly.POSCore.GraphQL.Mutation.Dashboard
{
     internal partial class Mutations
     {
          public void FieldsPOS()
          {
               Field<Boolean>("setDiagnostics")
                    .Argument<MedicalClinicDiagnosticsInputType>("data")
                    .Resolve(SetDiagnostics);
               Field<Boolean>("setServices")
                    .Argument<MedicalClinicServicesInputType>("data")
                    .Resolve(SetServices);
               Field<Boolean>("setReservations")
                    .Argument<MedicalClinicReservationsInputType>("data")
                    .Resolve(SetReservations);
               Field<Boolean>("setPatientsNotes")
                    .Argument<MedicalClinicPatientsNotesInputType>("data")
                    .Resolve(SetPatientsNotes);
               Field<Boolean>("setPatientsWeightLoss")
                    .Argument<MedicalClinicPatientsWeightLossInputType>("data")
                    .Resolve(SetPatientsWeightLoss);
               Field<Boolean>("setPatientsServices")
                    .Argument<MedicalClinicPatientsServicesInputType>("data")
                    .Resolve(SetPatientsServices);
               Field<Boolean>("setPatientsHistory")
                    .Argument<MedicalClinicPatientsHistoryInputType>("data")
                    .Resolve(SetPatientsHistory);
               Field<Boolean>("setPatientsLaboratories")
                    .Argument<MedicalClinicPatientsLaboratoriesInputType>("data")
                    .Resolve(SetPatientsLaboratories);
               Field<Boolean>("setPatientsExploration")
                    .Argument<MedicalClinicPatientsExplorationInputType>("data")
                    .Resolve(SetPatientsExploration);
               Field<Boolean>("setPatientdPrescriptions")
                    .Argument<MedicalClinicPatientdPrescriptionsInputType>("data")
                    .Resolve(SetPatientdPrescriptions);
               Field<Boolean>("setOtherServices")
                    .Argument<MedicalClinicOtherServicesInputType>("data")
                    .Resolve(SetOtherServices);
               Field<Boolean>("setLaboratoriesType")
                    .Argument<MedicalClinicLaboratoriesTypeInputType>("data")
                    .Resolve(SetLaboratoriesType);
               Field<Boolean>("setLaboratories")
                    .Argument<MedicalClinicLaboratoriesInputType>("data")
                    .Resolve(SetLaboratories);
               Field<Boolean>("setDoctorSchedules")
                    .Argument<MedicalClinicDoctorSchedulesInputType>("data")
                    .Resolve(SetDoctorSchedules);
               Field<Boolean>("setExplorationType")
                    .Argument<MedicalClinicExplorationTypeInputType>("data")
                    .Resolve(SetExplorationType);
          }
          private bool SetExplorationType(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               ExplorationType data = new(_System);
               data.Add(context.GetArgument<ExplorationType>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });
          private bool SetDoctorSchedules(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               DoctorSchedules data = new(_System);
               data.Add(context.GetArgument<DoctorSchedules>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });
          private bool SetLaboratories(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               Laboratories data = new(_System);
               data.Add(context.GetArgument<Laboratories>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });
          private bool SetLaboratoriesType(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               LaboratoriesType data = new(_System);
               data.Add(context.GetArgument<LaboratoriesType>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });
          private bool SetOtherServices(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               OtherServices data = new(_System);
               data.Add(context.GetArgument<OtherServices>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });
          private bool SetPatientdPrescriptions(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               PatientdPrescriptions data = new(_System);
               data.Add(context.GetArgument<PatientdPrescriptions>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });
          private bool SetPatientsExploration(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               PatientsExploration data = new(_System);
               data.Add(context.GetArgument<PatientsExploration>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });
          private bool SetPatientsLaboratories(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               PatientsLaboratories data = new(_System);
               data.Add(context.GetArgument<PatientsLaboratories>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });
          private bool SetPatientsHistory(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               PatientsHistory data = new(_System);
               data.Add(context.GetArgument<PatientsHistory>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });
          private bool SetDiagnostics(IResolveFieldContext context) => context.TryLogged(() =>
          {

               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction(); Diagnostics data = new(_System);
               data.Add(context.GetArgument<Diagnostics>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });
          private bool SetServices(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               Shelly.POSProviderData.Repository.Entity.Services data = new(_System);
               data.Add(context.GetArgument<Shelly.POSProviderData.Repository.Entity.Services>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });
          private bool SetReservations(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction(); Reservations data = new(_System);
               data.Add(context.GetArgument<Reservations>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });
          private bool SetPatientsWeightLoss(IResolveFieldContext context) => context.TryLogged(() =>

          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               PatientsWeightLoss data = new(_System);
               data.Add(context.GetArgument<PatientsWeightLoss>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });
          private bool SetPatientsNotes(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               PatientsNotes data = new(_System);
               data.Add(context.GetArgument<PatientsNotes>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });

          private bool SetPatientsServices(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               PatientsServices data = new(_System);
               data.Add(context.GetArgument<PatientsServices>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });


     }
}
