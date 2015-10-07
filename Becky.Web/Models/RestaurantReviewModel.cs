using System;

namespace Becky.Web.Models
{
    public class RestaurantReviewModel
    {
        public int Id { get; set; }
        public string ReviewText { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string ReviewTitle { get; set; }
        public int RestaurantBranchId { get; set; }

        public string ReviewerFullName => $"{FirstName}{LastName}";
        public DateTime ReviewedOn => ModifiedOn ?? CreatedOn;
    }
}