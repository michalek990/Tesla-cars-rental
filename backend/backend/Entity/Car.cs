using backend.Entity.Common;

namespace backend.Entity;

public class Car : BaseEntity
{
    public string Model { get; set; }
    public decimal HorsePower { get; set; }
    public string VIN { get; set; }
    public int YearOfProduction { get; set; }
    public bool Available { get; set; }
    public double CostPerDay { get; set; }
    
    public int RentalPointId { get; set; }
    public virtual RentalPoint RentalPoints { get; set; }

    public virtual Rental Rental { get; set; }
    
}