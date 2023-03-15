using backend.Entity.Common;

namespace backend.Entity;

public class Rental : BaseEntity
{
    public string FirstName { get; set; }
    public string Surname { get; set; }
    public string PeselNumber { get; set; }
    public int ContactNumber { get; set; }
    public Nationality Nationality { get; set; }
    public Gender Gender { get; set; }
    public DateTime RentalDateStart { get; set; }
    public DateTime RentalDateEnd { get; set; }
    public double TotalCostOfRent { get; set; }
    
    public int CarId { get; set; }
    public virtual Car Car { get; set; }
    
    public int StartRentalPointId { get; set; }
    public virtual RentalPoint StartRentalPoint { get; set; }
    
    public int EndRentalPointId { get; set; }
    public virtual RentalPoint EndRentalPoint { get; set; }

}