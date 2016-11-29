using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{
    public class OdeToFoodDb: DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantReview> RestaurantReviews { get; set; }

        // to configure my own database connection
        public OdeToFoodDb() : base("name=DefaultConnection")
        {

        }

    }
}