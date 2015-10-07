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
        IEnumerable<ViewReview> GetRestaurantReviews(int restaurantBranchId);
        IEnumerable<RestaurantPhoto> GetRestaurantPhotos(int restaurantBranchId);
        float GetConsolidatedRating(int restaurantBranchId);
        void AddRestaurantReview(RestaurantReview restaurantReview);
        void ReportRestaurantReviewAsSpam(int restaurantReviewId);
        void RemoveRestaurantReview(int restaurantReviewId);
        void AddRestaurantRating(RestaurantRating restaurantRating);
        void UpdateRestaurantRating(RestaurantRating restaurantRating);
    }
}