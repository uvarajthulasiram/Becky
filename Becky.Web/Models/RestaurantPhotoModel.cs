namespace Becky.Web.Models
{
    public class RestaurantPhotoModel
    {
        public int Id { get; set; }
        public int RestaurantBranchId { get; set; }
        public int PhotoTypeId { get; set; }
        public string PhotoSource { get; set; }
    }
}