namespace GrpcService1;
public class VaccineRecord
{
    public int VaccineCategoryId {get;set;}

    public int UserId {get; set;}

    public required User User {get; set;}

    public int DependentId {get; set;}

    public required Dependent Dependent {get;set;}

    public int VaccineId {get; set;}

    public required Vaccine Vaccine {get;set;}

    public DateTime DateAdministered {get;set;}

    public required string AdministeredLocation {get; set;}

    public required string AdministeredBy{get;set;}


}