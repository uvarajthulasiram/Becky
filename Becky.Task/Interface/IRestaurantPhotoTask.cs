using System.Collections.Generic;
using Becky.Data;

namespace Becky.Task.Interface
{
    public interface IRestaurantPhotoTask
    {
        IEnumerable<RestaurantPhoto> GetRestaurantPhotos(int restaurantBranchId);
        void AddPhoto(RestaurantPhoto restaurantPhoto);
        void ReportPhotoAsSpam(int restaurantPhotoId);
        void SetAsPrimaryPhoto(int restaurantPhotoId);
    }
}