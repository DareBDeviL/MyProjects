﻿namespace RealEstate.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using RealEstate.Data.Models;

    internal class PropertyCategoryTypeSeeder : DataSeeder, ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.PropertyCategoryTypes.Any())
            {
                return;
            }

            var propertyCategoryTypes = this.GetData<PropertyCategoryType>(nameof(PropertyCategoryType));

            await dbContext.AddRangeAsync(propertyCategoryTypes);
        }
    }
}