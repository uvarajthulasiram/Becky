using System.Web.Http;
using Becky.Data;
using Becky.Task.Interface;

namespace Becky.WebApi.Controllers
{
    public class RestaurantRatingController : ApiController
    {
        private readonly IRestaurantRatingTask _restaurantRatingTask;

        public RestaurantRatingController(IRestaurantRatingTask restaurantRatingTask)
        {
            _restaurantRatingTask = restaurantRatingTask;
        }

        public float Get(int restaurantBranchId)
        {
            return _restaurantRatingTask.GetConsolidatedRating(restaurantBranchId);
        }

        public void Post(RestaurantRating restaurantRating)
        {
            if (restaurantRating.Id == 0)
                _restaurantRatingTask.AddRestaurantRating(restaurantRating);
            else
                _restaurantRatingTask.UpdateRestaurantRating(restaurantRating);
        }
    }
}
