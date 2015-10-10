using System.Collections.Generic;
using Becky.Data;
using Becky.Domain.Entity;

namespace Becky.Task.Interface
{
    public interface IRestaurantTask
    {
        ViewRestaurant GetRestaurant(int restaurantBranchId);
        IEnumerable<ViewRestaurant> GetRestaurants(RestaurantFilter restaurantFilter);
        IEnumerable<ViewRestaurant> GetRelatedRestaurants(int restaurantBranchId);
    }
}