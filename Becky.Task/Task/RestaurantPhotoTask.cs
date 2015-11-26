using System.Collections.Generic;
using System.Linq;
using Becky.Data;
using Becky.Data.DataAccess;
using Becky.Domain.Enums;
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
            restaurantPhoto.PhotoTypeId =
                _restaurantPhotoRepository.Find(
                    p =>
                        p.RestaurantBranchId == restaurantPhoto.RestaurantBranchId &&
                        p.PhotoTypeId == (int) PhotoType.Primary).Any()
                    ? (int) PhotoType.Secondary
                    : (int) PhotoType.Primary;

            _restaurantPhotoRepository.Insert(restaurantPhoto);
            _restaurantPhotoRepository.SaveChanges();
        }

        public void ReportPhotoAsSpam(int restaurantPhotoId)
        {
            var photo = _restaurantPhotoRepository.FirstOrDefault(p => p.Id == restaurantPhotoId);

            if (photo == null) return;

            photo.IsSpam = true;

            _restaurantPhotoRepository.Update(photo);
            _restaurantPhotoRepository.SaveChanges();
        }

        public void SetAsPrimaryPhoto(int restaurantPhotoId)
        {
            var newPrimaryPhoto = _restaurantPhotoRepository.FirstOrDefault(p => p.Id == restaurantPhotoId);
            var currentPrimaryPhoto =
                _restaurantPhotoRepository.FirstOrDefault(
                    p =>
                        p.RestaurantBranchId == newPrimaryPhoto.RestaurantBranchId &&
                        p.PhotoTypeId == (int) PhotoType.Primary);

            if (newPrimaryPhoto == null) return;

            if (currentPrimaryPhoto != null)
            {
                currentPrimaryPhoto.PhotoTypeId = (int) PhotoType.Secondary;
                _restaurantPhotoRepository.Update(currentPrimaryPhoto);
            }

            newPrimaryPhoto.PhotoTypeId = (int) PhotoType.Primary;
            
            _restaurantPhotoRepository.Update(newPrimaryPhoto);
            _restaurantPhotoRepository.SaveChanges();
        }
    }
}