using backend.Entity;

namespace backend;

public class DataBaseSeeder
{
    private readonly AppDbContext _context;

    public DataBaseSeeder(AppDbContext context)
    {
        _context = context;
    }

    public void Seed()
    {
        if (_context.Database.CanConnect())
        {
            if (!_context.RentalPoints.Any())
            {
                var rentalPoints = GetRentalPoints();
                _context.RentalPoints.AddRange(rentalPoints);
                _context.SaveChanges();
            }
        }
    }

    private IEnumerable<RentalPoint> GetRentalPoints()
    {
        var rentalPoints = new List<RentalPoint>()
        {
            new RentalPoint()
            {
                RentalPointName = "Palma Airport",
                City = "Palma",
                Street = "Balearic Islands",
                Number = 07611,
                Cars = new List<Car>()
                {
                    new Car()
                    {
                        Model = "Tesla Model S",
                        HorsePower = 600,
                        VIN = "LPgULh7gdSizpUOBP",
                        YearOfProduction = 2017,
                        Available = true,
                    },
                    new Car()
                    {
                        Model = "Tesla Model Y",
                        HorsePower = 250,
                        VIN = "V4Jp4ykabTtedWRYE",
                        YearOfProduction = 2020,
                        Available = true,
                    },
                    new Car()
                    {
                        Model = "Tesla Model X",
                        HorsePower = 300,
                        VIN = "x7D2B4h9U1J2iZX7E",
                        YearOfProduction = 2019,
                        Available = true,
                    }
                }
            },
            new RentalPoint()
            {
                RentalPointName = "Palma City Center",
                City = "Palma",
                Street = "Carrer de Femenies",
                Number = 12,
                Cars = new List<Car>()
                {
                    new Car()
                    {
                        Model = "Tesla Model X",
                        HorsePower = 400,
                        VIN = "JhVbz6VXiRkV4MrAW",
                        YearOfProduction = 2020,
                        Available = true,
                    },
                    new Car()
                    {
                        Model = "Tesla Model S",
                        HorsePower = 450,
                        VIN = "Xdqnvg67nAVCE7w1p",
                        YearOfProduction = 2019,
                        Available = true,
                    },
                    new Car()
                    {
                        Model = "Tesla Model S",
                        HorsePower = 350,
                        VIN = "asWdh8fSgalQvkvfL",
                        YearOfProduction = 2018,
                        Available = true,
                    }
                }
            },
            new RentalPoint()
            {
                RentalPointName = "Alcudia",
                City = "Alcudia",
                Street = "Pollentia",
                Number = 15,
                Cars = new List<Car>()
                {
                    new Car()
                    {
                        Model = "Tesla Model S",
                        HorsePower = 550,
                        VIN = "CxJtAeGfodDFhtGXO",
                        YearOfProduction = 2017,
                        Available = true,
                    },
                    new Car()
                    {
                        Model = "Tesla Model Y",
                        HorsePower = 500,
                        VIN = "j4g3waxs7jI4vEW3r",
                        YearOfProduction = 2016,
                        Available = true,
                    },
                    new Car()
                    {
                            Model = "Tesla Model X",
                        HorsePower = 700,
                        VIN = "4qZIvwuzTzb0lImxR",
                        YearOfProduction = 2016,
                        Available = true,
                    }
                }
            },
            new RentalPoint()
            {
                RentalPointName = "Manacor",
                City = "Manacor",
                Street = "Via Roma",
                Number = 234,
                Cars = new List<Car>()
                {
                    new Car()
                    {
                        Model = "Tesla Model X",
                        HorsePower = 270,
                        VIN = "yb8d72gZbRaodHqct",
                        YearOfProduction = 0,
                        Available = true,
                    },
                    new Car()
                    {
                        Model = "Tesla Model Y",
                        HorsePower = 350,
                        VIN = "d1CyXniT1IvL1XwOn",
                        YearOfProduction = 0,
                        Available = true,
                    },
                    new Car()
                    {
                        Model = "Tesla Model 3",
                        HorsePower = 400,
                        VIN = "v0YgbjvnLL7Rod1Le",
                        YearOfProduction = 0,
                        Available = true,
                    }
                }
            }
        };
        return rentalPoints;
    }
    
    
}