using System.Web.Http;
using Becky.Data;
using Becky.Task.Interface;

namespace Becky.WebApi.Controllers
{
    public class RestaurantRatingController : ApiController
    {
        private readonly IRestaurantTask _restaurantTask;

        public RestaurantRatingController(IRestaurantTask restaurantTask)
        {
            _restaurantTask = restaurantTask;
        }

        public float Get(int restaurantBranchId)
        {
            return _restaurantTask.GetConsolidatedRating(restaurantBranchId);
        }

        public void Post(RestaurantRating restaurantRating)
        {
            if (restaurantRating.Id == 0)
                _restaurantTask.AddRestaurantRating(restaurantRating);
            else
                _restaurantTask.UpdateRestaurantRating(restaurantRating);
        }
    }
}
