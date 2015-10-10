using System.Collections.Generic;
using System.Linq;
using Becky.Data;
using Becky.Data.DataAccess;
using Becky.Task.Interface;

namespace Becky.Task.Task
{
    public class RestaurantReviewTask : TaskBase, IRestaurantReviewTask
    {
        private readonly IRepository<ViewReview> _viewReviewRepository;
        private readonly IRepository<RestaurantReview> _restaurantReviewRepository;

        public RestaurantReviewTask(IRepository<ViewReview> viewReviewRepository,
                    IRepository<RestaurantReview> restaurantReviewRepository)
        {
            _viewReviewRepository = viewReviewRepository;
            _restaurantReviewRepository = restaurantReviewRepository;
        }

        public IEnumerable<ViewReview> GetRestaurantReviews(int restaurantBranchId)
        {
            return _viewReviewRepository.Find(p => p.RestaurantBranchId == restaurantBranchId).OrderByDescending(p => p.ModifiedOn ?? p.CreatedOn);
        }

        public void AddRestaurantReview(RestaurantReview restaurantReview)
        {
            _restaurantReviewRepository.Insert(restaurantReview);
            _restaurantReviewRepository.SaveChanges();
        }

        public void ReportRestaurantReviewAsSpam(int restaurantReviewId)
        {
            var review = _restaurantReviewRepository.FirstOrDefault(p => p.Id == restaurantReviewId);

            if (review == null) return;

            review.IsSpam = true;

            _restaurantReviewRepository.Update(review);
            _restaurantReviewRepository.SaveChanges();
        }

        public void RemoveRestaurantReview(int restaurantReviewId)
        {
            var review = _restaurantReviewRepository.FirstOrDefault(p => p.Id == restaurantReviewId);

            if (review == null) return;

            _restaurantReviewRepository.Delete(review);
        }


    }
}