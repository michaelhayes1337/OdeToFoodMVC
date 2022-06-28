using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "PizzaPlace", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 2, Name = "FryPlace", Cuisine = CuisineType.French},
                new Restaurant { Id = 3, Name = "DurbanPlace", Cuisine = CuisineType.Indian },
                new Restaurant { Id = 4, Name = "AmericanPlace", Cuisine = CuisineType.None },
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r=> r.Name);
        }

        void IRestaurantData.AddRestaurant(Restaurant restaurant)
        {
            
            restaurant.Id = restaurants.Max(r => r.Id) + 1;
            restaurants.Add(restaurant);
        }

        void IRestaurantData.DeleteRestaurant(int id)
        {
            int index = restaurants.FindIndex(r => r.Id == id);
            if (index >= 0)
            {
                restaurants.RemoveAt(index);
            }
        }

        Restaurant IRestaurantData.Get(int id)
        {
            return restaurants.FirstOrDefault(r=>r.Id == id);
        }

        void IRestaurantData.UpdateRestaurant(Restaurant restaurant)
        {
            int index = restaurants.FindIndex(r => r.Id == restaurant.Id);
            if(index >= 0)
            {
                restaurants[index] = restaurant;
            }
        }
    }
}
