CREATE VIEW [dbo].[ViewRestaurant]
	AS 
	SELECT RestaurantBranch.Id,
		   Restaurant.Name,
		   RestaurantBranch.AddressLine1,
		   RestaurantBranch.AddressLine2,
		   RestaurantBranch.City,
		   RestaurantBranch.Province,
		   RestaurantBranch.Country,
		   RestaurantBranch.Website,
		   RestaurantBranch.Phone,
		   RestaurantBranch.IsActive,
		   RestaurantPhoto.PhotoSource,
		   LookupRestaurantType.[Type]
	  FROM RestaurantBranch
INNER JOIN Restaurant ON Restaurant.Id = RestaurantBranch.RestaurantId
INNER JOIN LookupRestaurantType ON LookupRestaurantType.Id = Restaurant.LookupRestaurantTypeId
 LEFT JOIN RestaurantPhoto ON RestaurantPhoto.RestaurantBranchId = RestaurantBranch.Id AND RestaurantPhoto.PhotoTypeId = 1