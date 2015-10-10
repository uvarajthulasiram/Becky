using System.Linq;
using Becky.Data;
using Becky.Data.DataAccess;
using Becky.Task.Interface;

namespace Becky.Task.Task
{
    public class RestaurantRatingTask : TaskBase, IRestaurantRatingTask
    {
        private readonly IRepository<RestaurantRating> _restaurantRatingRepository;

        public RestaurantRatingTask(IRepository<RestaurantRating> restaurantRatingRepository)
        {
            _restaurantRatingRepository = restaurantRatingRepository;
        }

        public void AddRestaurantRating(RestaurantRating restaurantRating)
        {
            _restaurantRatingRepository.Insert(restaurantRating);
            _restaurantRatingRepository.SaveChanges();
        }

        public void UpdateRestaurantRating(RestaurantRating restaurantRating)
        {
            var rating = _restaurantRatingRepository.FirstOrDefault(p => p.Id == restaurantRating.Id);

            if (rating == null) return;

            rating.Rating = restaurantRating.Rating;

            _restaurantRatingRepository.Update(rating);
            _restaurantRatingRepository.SaveChanges();
        }

        public float GetConsolidatedRating(int restaurantBranchId)
        {
            var ratings = _restaurantRatingRepository.Find(p => p.RestaurantBranchId == restaurantBranchId);

            if (ratings == null || !ratings.Any()) return 0;

            return (float)ratings.OrderByDescending(p => p.ModifiedOn ?? p.CreatedOn).Take(20).Average(p => p.Rating);
        }
    }
}