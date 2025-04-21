using System.Collections.Generic;
using System.Linq;

namespace CarDealershipCatalog.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Cars.Any())
            {
                return;   // DB has been seeded
            }

            var cars = new List<Car>
            {
                new Car { Make = "Toyota", Model = "Camry", Year = 2020, Price = 24000, Description = "Reliable sedan with great fuel efficiency." },
                new Car { Make = "Honda", Model = "Civic", Year = 2021, Price = 22000, Description = "Compact car with sporty design and performance." },
                new Car { Make = "Ford", Model = "Mustang", Year = 2019, Price = 26000, Description = "Classic American muscle car with powerful engine." },
                new Car { Make = "Chevrolet", Model = "Malibu", Year = 2020, Price = 23000, Description = "Comfortable midsize sedan with spacious interior." },
                new Car { Make = "Tesla", Model = "Model 3", Year = 2021, Price = 35000, Description = "Electric car with cutting-edge technology and performance." }
            };

            context.Cars.AddRange(cars);
            context.SaveChanges();
        }
    }
}