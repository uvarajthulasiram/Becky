using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Becky.Data;
using Becky.Domain.Entity;
using Becky.Task.Interface;

namespace Becky.WebApi.Controllers
{
    public class RestaurantController : ApiController
    {
        private readonly IRestaurantTask _restaurantTask;

        public RestaurantController(IRestaurantTask restaurantTask)
        {
            _restaurantTask = restaurantTask;
        }

        public IEnumerable<string> GetRestaurantNames([FromBody] RestaurantFilter restaurantFilter)
        {
            return restaurantFilter == null ? 
                _restaurantTask.GetRestaurants(null).Select(p => p.Name) : 
                _restaurantTask.GetRestaurants(restaurantFilter).Select(p => p.Name);
        }

        public IEnumerable<ViewRestaurant> GetRestaurants(RestaurantFilter restaurantFilter) => _restaurantTask.GetRestaurants(restaurantFilter);

        public IEnumerable<RestaurantPhoto> GetRestaurantPhotos(int restaurantBranchId) => _restaurantTask.GetRestaurantPhotos(restaurantBranchId);

        public float GetRestaurantRating(int restaurantBranchId)
        {
            return _restaurantTask.GetConsolidatedRating(restaurantBranchId);
        }

        [Authorize]
        public void PostRestaurantRating(RestaurantRating restaurantRating)
        {
            if (restaurantRating.Id == 0)
                _restaurantTask.AddRestaurantRating(restaurantRating);
            else
                _restaurantTask.UpdateRestaurantRating(restaurantRating);
        }

        public IEnumerable<RestaurantReview> GetRestaurantReviews(int restaurantBranchId) => _restaurantTask.GetRestaurantReviews(restaurantBranchId);

        [Authorize]
        public HttpResponseMessage PostRestaurantReview(RestaurantReview restaurantReview)
        {
            var response = new HttpResponseMessage();

            try
            {
                _restaurantTask.AddRestaurantReview(restaurantReview);
                response.StatusCode = HttpStatusCode.Created;
            }
            catch
            {
                response.StatusCode = HttpStatusCode.ExpectationFailed;
            }

            return response;
        }

        [Authorize]
        public HttpResponseMessage PostRestaurantReviewAsSpam(int restaurantReviewId)
        {
            var response = new HttpResponseMessage();

            try
            {
                _restaurantTask.ReportRestaurantReviewAsSpam(restaurantReviewId);
                response.StatusCode = HttpStatusCode.OK;
            }
            catch
            {
                response.StatusCode = HttpStatusCode.ExpectationFailed;
            }

            return response;
        }

        [Authorize]
        public HttpResponseMessage DeleteRestaurantReview(int restaurantReviewId)
        {
            var response = new HttpResponseMessage();

            try
            {
                _restaurantTask.RemoveRestaurantReview(restaurantReviewId);
                response.StatusCode = HttpStatusCode.OK;
            }
            catch
            {
                response.StatusCode = HttpStatusCode.ExpectationFailed;
            }

            return response;
        }
    }
}
