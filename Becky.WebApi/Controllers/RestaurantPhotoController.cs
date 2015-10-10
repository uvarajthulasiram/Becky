using System.Collections.Generic;
using System.Web.Http;
using Becky.Data;
using Becky.Task.Interface;

namespace Becky.WebApi.Controllers
{
    public class RestaurantPhotoController : ApiController
    {
        private readonly IRestaurantPhotoTask _restaurantPhotoTask;

        public RestaurantPhotoController(IRestaurantPhotoTask restaurantPhotoTask)
        {
            _restaurantPhotoTask = restaurantPhotoTask;
        }

        public IEnumerable<RestaurantPhoto> Get(int restaurantBranchId) => _restaurantPhotoTask.GetRestaurantPhotos(restaurantBranchId);
    }
}
