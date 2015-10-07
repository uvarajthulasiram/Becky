CREATE VIEW [dbo].[ViewReview]
AS
	SELECT RestaurantReview.Id,
		   RestaurantReview.RestaurantBranchId,
		   RestaurantReview.ReviewTitle,
		   RestaurantReview.ReviewText,
		   RestaurantReview.CreatedOn,
		   RestaurantReview.ModifiedOn,
		   AspNetUsers.FirstName,
		   AspNetUsers.LastName,
		   AspNetUsers.ProfilePictureUrl
	  FROM RestaurantBranch
INNER JOIN RestaurantReview ON RestaurantReview.RestaurantBranchId = RestaurantBranch.Id
INNER JOIN AspNetUsers ON AspNetUsers.Id = RestaurantReview.AspNetUserId