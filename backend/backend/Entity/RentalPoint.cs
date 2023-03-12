using backend.Entity.Common;

namespace backend.Entity;

public class RentalPoint : BaseEntity
{
    public string RentalPointName { get; set; }
    public string City { get; set; }
    public string? Street { get; set; }
    public int Number { get; set; }
 
    public virtual List<Car> Cars { get; set; }
    
    public virtual Rental StartRental { get; set; }
    public virtual Rental EndRental { get; set; }
}