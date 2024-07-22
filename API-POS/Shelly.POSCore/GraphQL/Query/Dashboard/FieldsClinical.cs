namespace Shelly.POSCore.GraphQL.Query.Dashboard
{
     internal partial class Queries
     {
          public void FieldsClinical()
          {
               Field<PaginationMedicalClinicDoctorSchedulesType>("getDoctorSchedules")
                    .Argument<int>("pageNumber")
                    .Argument<int>("rowsOfPage")
                    .Resolve(GetDoctorSchedules);
               Field<PaginationMedicalClinicExplorationTypeType>("getExplorationType")
                    .Argument<int>("pageNumber")
                    .Argument<int>("rowsOfPage")
                    .Resolve(GetExplorationType);
               Field<PaginationMedicalClinicOtherServicesType>("getOtherServices")
                    .Argument<int>("pageNumber")
                    .Argument<int>("rowsOfPage")
                    .Resolve(GetOtherServices);
               Field<PaginationMedicalClinicPatientdPrescriptionsType>("getPatientdPrescriptions")
                    .Argument<int>("pageNumber")
                    .Argument<int>("rowsOfPage")
                    .Resolve(GetPatientdPrescriptions);
               Field<PaginationMedicalClinicPatientsExplorationType>("getPatientsExploration")
                    .Argument<int>("pageNumber")
                    .Argument<int>("rowsOfPage")
                    .Resolve(GetPatientsExploration);
               Field<PaginationMedicalClinicPatientsHistoryType>("getPatientsHistory")
                    .Argument<int>("pageNumber")
                    .Argument<int>("rowsOfPage")
                    .Resolve(GetPatientsHistory);
               Field<PaginationMedicalClinicPatientsLaboratoriesType>("getPatientsLaboratories")
                    .Argument<int>("pageNumber")
                    .Argument<int>("rowsOfPage")
                    .Resolve(GetPatientsLaboratories);
               Field<PaginationMedicalClinicPatientsNotesType>("getPatientsNotes")
                    .Argument<int>("pageNumber")
                    .Argument<int>("rowsOfPage")
                    .Resolve(GetPatientsNotes);
               Field<PaginationMedicalClinicPatientsServicesType>("getPatientsServices")
                    .Argument<int>("pageNumber")
                    .Argument<int>("rowsOfPage")
                    .Resolve(GetPatientsServices);
               Field<PaginationMedicalClinicReservationsType>("getReservations")
                    .Argument<int>("pageNumber")
                    .Argument<int>("rowsOfPage")
                    .Resolve(GetReservations);
          }
          private Pagination<Reservations>? GetReservations(IResolveFieldContext context) => context.TryLogged(() => { return new ReservationsCollection(_System).Where(x => x.Company == _System.Session.Company.Number, context.GetArgument<int>("pageNumber"), context.GetArgument<int>("rowsOfPage")); });
          private Pagination<PatientsServices>? GetPatientsServices(IResolveFieldContext context) => context.TryLogged(() => { return new PatientsServicesCollection(_System).Where(context.GetArgument<int>("pageNumber"), context.GetArgument<int>("rowsOfPage")); });
          private Pagination<PatientsNotes>? GetPatientsNotes(IResolveFieldContext context) => context.TryLogged(() => { return new PatientsNotesCollection(_System).Where(context.GetArgument<int>("pageNumber"), context.GetArgument<int>("rowsOfPage")); });
          private Pagination<PatientsLaboratories>? GetPatientsLaboratories(IResolveFieldContext context) => context.TryLogged(() => { return new PatientsLaboratoriesCollection(_System).Where(context.GetArgument<int>("pageNumber"), context.GetArgument<int>("rowsOfPage")); });
          private Pagination<PatientsHistory>? GetPatientsHistory(IResolveFieldContext context) => context.TryLogged(() => { return new PatientsHistoryCollection(_System).Where(context.GetArgument<int>("pageNumber"), context.GetArgument<int>("rowsOfPage")); });
          private Pagination<PatientsExploration>? GetPatientsExploration(IResolveFieldContext context) => context.TryLogged(() => { return new PatientsExplorationCollection(_System).Where(context.GetArgument<int>("pageNumber"), context.GetArgument<int>("rowsOfPage")); });
          private Pagination<PatientdPrescriptions>? GetPatientdPrescriptions(IResolveFieldContext context) => context.TryLogged(() => { return new PatientdPrescriptionsCollection(_System).Where(context.GetArgument<int>("pageNumber"), context.GetArgument<int>("rowsOfPage")); });
          private Pagination<DoctorSchedules>? GetDoctorSchedules(IResolveFieldContext context) => context.TryLogged(() => { return new DoctorSchedulesCollection(_System).Where(x => x.Company == _System.Session.Company.Number, context.GetArgument<int>("pageNumber"), context.GetArgument<int>("rowsOfPage")); });
          private Pagination<ExplorationType>? GetExplorationType(IResolveFieldContext context) => context.TryLogged(() => { return new ExplorationTypeCollection(_System).Where(context.GetArgument<int>("pageNumber"), context.GetArgument<int>("rowsOfPage")); });
          private Pagination<OtherServices>? GetOtherServices(IResolveFieldContext context) => context.TryLogged(() => { return new OtherServicesCollection(_System).Where(context.GetArgument<int>("pageNumber"), context.GetArgument<int>("rowsOfPage")); });

     }
}
