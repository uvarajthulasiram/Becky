using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Becky.Data;
using Becky.Data.DataAccess;
using Becky.Domain.Entity;
using Becky.Task.Interface;

namespace Becky.Task.Task
{
    public class RestaurantTask : TaskBase, IRestaurantTask
    {
        private readonly IRepository<ViewRestaurant> _viewRestaurantRepository;
        private readonly IRepository<ViewReview> _viewReviewRepository;
        private readonly IRepository<RestaurantReview> _restaurantReviewRepository;
        private readonly IRepository<RestaurantRating> _restaurantRatingRepository;
        private readonly IRepository<RestaurantPhoto> _restaurantPhotoRepository;

        public RestaurantTask(IRepository<ViewRestaurant> viewRestaurantRepository, 
            IRepository<ViewReview> viewReviewRepository, 
            IRepository<RestaurantReview> restaurantReviewRepository, 
            IRepository<RestaurantRating> restaurantRatingRepository, 
            IRepository<RestaurantPhoto> restaurantPhotoRepository)
        {
            _viewRestaurantRepository = viewRestaurantRepository;
            _viewReviewRepository = viewReviewRepository;
            _restaurantReviewRepository = restaurantReviewRepository;
            _restaurantRatingRepository = restaurantRatingRepository;
            _restaurantPhotoRepository = restaurantPhotoRepository;
        }

        public ViewRestaurant GetRestaurant(int restaurantBranchId)
        {
            return _viewRestaurantRepository.Single(p => p.Id == restaurantBranchId);
        }

        public IEnumerable<ViewRestaurant> GetRestaurants(RestaurantFilter restaurantFilter)
        {
            IEnumerable<ViewRestaurant> restaurants = _viewRestaurantRepository.GetAll().OrderByDescending(p => GetConsolidatedRating(p.Id));

            if (restaurantFilter == null) return restaurants;

            if (!string.IsNullOrWhiteSpace(restaurantFilter.Name))
                restaurants =
                    restaurants.Where(
                        p => p.Name.IndexOf(restaurantFilter.Name, StringComparison.InvariantCultureIgnoreCase) != -1);

            if (restaurantFilter.Cuisine != null)
                restaurants =
                    restaurants?.Where(p => p.Type == restaurantFilter.Cuisine.ToString());

            return restaurants;
        }

        public IEnumerable<ViewRestaurant> GetRelatedRestaurants(int restaurantBranchId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ViewReview> GetRestaurantReviews(int restaurantBranchId)
        {
            return _viewReviewRepository.Find(p => p.RestaurantBranchId == restaurantBranchId).OrderByDescending(p => p.ModifiedOn ?? p.CreatedOn);
        }

        public IEnumerable<RestaurantPhoto> GetRestaurantPhotos(int restaurantBranchId)
        {
            return _restaurantPhotoRepository.Find(p => p.RestaurantBranchId == restaurantBranchId);
        }

        public void AddRestaurantReview(RestaurantReview restaurantReview)
        {
            _restaurantReviewRepository.Insert(restaurantReview);
            _restaurantReviewRepository.SaveChanges();
        }

        public void ReportRestaurantReviewAsSpam(int restaurantReviewId)
        {
            var review =_restaurantReviewRepository.FirstOrDefault(p => p.Id == restaurantReviewId);

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
            var ratings = _restaurantRatingRepository.Find(p => p.Id == restaurantBranchId);

            if (ratings == null || !ratings.Any()) return 0;

            return (float)ratings.OrderByDescending(p => p.ModifiedOn ?? p.CreatedOn).Take(20).Average(p => p.Rating);
        }
    }
}