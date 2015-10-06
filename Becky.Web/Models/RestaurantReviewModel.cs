namespace Becky.Web.Models
{
    public class RestaurantReviewModel
    {
        public int? Id { get; set; }
        public int RestaurantBranchId { get; set; }
        public string AspNetUserId { get; set; }
        public string ReviewText { get; set; }
        public int ReviewTypeId { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime? CreatedOn { get; set; }
    }
}