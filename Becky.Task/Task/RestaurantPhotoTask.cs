using System.Collections.Generic;
using Becky.Data;
using Becky.Data.DataAccess;
using Becky.Task.Interface;

namespace Becky.Task.Task
{
    public class RestaurantPhotoTask : TaskBase, IRestaurantPhotoTask
    {
        private readonly IRepository<RestaurantPhoto> _restaurantPhotoRepository;
        public RestaurantPhotoTask(IRepository<RestaurantPhoto> restaurantPhotoRepository)
        {
            _restaurantPhotoRepository = restaurantPhotoRepository;
        }

        public IEnumerable<RestaurantPhoto> GetRestaurantPhotos(int restaurantBranchId)
        {
            return _restaurantPhotoRepository.Find(p => p.RestaurantBranchId == restaurantBranchId);
        }

        public void AddPhoto(RestaurantPhoto restaurantPhoto)
        {
            throw new System.NotImplementedException();
        }

        public void ReportPhotoAsSpam(int restaurantPhotoId)
        {
            throw new System.NotImplementedException();
        }

        public void SetAsPrimaryPhoto(int restaurantPhotoId)
        {
            throw new System.NotImplementedException();
        }
    }
}