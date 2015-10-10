using System.Collections.Generic;
using Becky.Data;

namespace Becky.Task.Interface
{
    public interface IRestaurantReviewTask
    {
        IEnumerable<ViewReview> GetRestaurantReviews(int restaurantBranchId);
        void AddRestaurantReview(RestaurantReview restaurantReview);
        void ReportRestaurantReviewAsSpam(int restaurantReviewId);
        void RemoveRestaurantReview(int restaurantReviewId);
    }
}