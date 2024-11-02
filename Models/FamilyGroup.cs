namespace GrpcService1;
public class FamilyGroup
{
    public int FamilyGroupId {get;set;}

    public required string Name{get;set;}

    public required List<User> Users {get;set;}
}
