namespace GrpcService1;
public class VaccineCategory 
{
    public int VaccineCategoryId {get; set;}

    public required string Name {get;set;}

    public required List<Vaccine> Vaccines {get; set;}
}