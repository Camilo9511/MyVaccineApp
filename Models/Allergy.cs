namespace GrpcService1;

public class Allergy
{
    public int AllergyId {get;set;}

    public required string Name {get;set;}

    public int UserId {get;set;}

    public required User User {get; set;}
}
