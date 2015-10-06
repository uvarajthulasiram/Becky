using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Becky.Data;
using Becky.Task.Interface;

namespace Becky.WebApi.Controllers
{
    public class RestaurantPhotoController : ApiController
    {
        private readonly IRestaurantTask _restaurantTask;

        public RestaurantPhotoController(IRestaurantTask restaurantTask)
        {
            _restaurantTask = restaurantTask;
        }

        public IEnumerable<RestaurantPhoto> Get(int restaurantBranchId) => _restaurantTask.GetRestaurantPhotos(restaurantBranchId);
    }
}
