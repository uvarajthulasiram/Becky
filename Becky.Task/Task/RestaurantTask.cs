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
        private readonly IRepository<RestaurantPhoto> _restaurantPhotoRepository;

        private readonly IRestaurantRatingTask _restaurantRatingTask;

        public RestaurantTask(IRepository<ViewRestaurant> viewRestaurantRepository,
            IRepository<RestaurantPhoto> restaurantPhotoRepository,
            IRestaurantRatingTask restaurantRatingTask)
        {
            _viewRestaurantRepository = viewRestaurantRepository;
            _restaurantPhotoRepository = restaurantPhotoRepository;
            _restaurantRatingTask = restaurantRatingTask;
        }

        public ViewRestaurant GetRestaurant(int restaurantBranchId)
        {
            return _viewRestaurantRepository.Single(p => p.Id == restaurantBranchId);
        }

        public IEnumerable<ViewRestaurant> GetRestaurants(RestaurantFilter restaurantFilter)
        {
            IEnumerable<ViewRestaurant> restaurants =
                _viewRestaurantRepository.GetAll()
                    .OrderByDescending(p => _restaurantRatingTask.GetConsolidatedRating(p.Id));

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
    }
}