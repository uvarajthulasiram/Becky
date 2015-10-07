using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Becky.Data;
using Becky.Task.Interface;

namespace Becky.WebApi.Controllers
{
    public class RestaurantReviewController : ApiController
    {
        private readonly IRestaurantTask _restaurantTask;
        public RestaurantReviewController(IRestaurantTask restaurantTask)
        {
            _restaurantTask = restaurantTask;
        }

        //public IEnumerable<RestaurantReview> GetRestaurantReviews(int restaurantBranchId)
        //{
        //    return _restaurantTask.GetRestaurantReviews(restaurantBranchId);
        //}
    }
}
