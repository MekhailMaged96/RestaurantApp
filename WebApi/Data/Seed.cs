using Domain.Aggregates.FoodTypeAgg;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Data
{
    public class Seed
    {
        public static void SeedFoodsData(DataContext context)
        {

            var foodTypes = AddFoddTypes();

            if (!context.FoodTypes.Any())
            {
                foreach (var food in foodTypes)
                {
                    context.FoodTypes.Add(food);
                }
                context.SaveChanges();
            }

        }

        private static List<FoodType> AddFoddTypes()
        {
            var foodList = new List<FoodType>()
            {
                new FoodType {Name = "Fish"},
                new FoodType { Name = "Pizza" },
                new FoodType { Name = "Chicken" },
            };

            return foodList;
        }
    }
}
