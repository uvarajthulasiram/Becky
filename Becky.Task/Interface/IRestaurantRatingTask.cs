using Becky.Data;

namespace Becky.Task.Interface
{
    public interface IRestaurantRatingTask
    {
        float GetConsolidatedRating(int restaurantBranchId);
        void AddRestaurantRating(RestaurantRating restaurantRating);
        void UpdateRestaurantRating(RestaurantRating restaurantRating);
    }
}