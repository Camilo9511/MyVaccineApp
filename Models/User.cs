namespace GrpcService1;
public  class User
{
    public int UserId {get; set;}

    public string UserName {get; set;}

    public string Email {get; set;}

    public required string Password {get; set;}

    public required List<Dependent> Dependents { get; set;}

    public required List<FamilyGroup> FamilyGroups {get; set;}

    public required List<VaccineRecord> VaccineRecords{get; set;}

    public required List<Allergy> Allergies {get; set;}
}