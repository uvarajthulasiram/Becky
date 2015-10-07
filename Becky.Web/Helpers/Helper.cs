using System;
using System.Configuration;

namespace Becky.Web.Helpers
{
    public class Helper
    {
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static int GetNumberOfRestaurantsToShowInHome()
        {
            return Convert.ToInt32(ConfigurationManager.AppSettings.Get("NumberOfRestaurantsToShowInHome"));
        }

        public static int GetNumberOfRestaurantReviewsToShow()
        {
            return Convert.ToInt32(ConfigurationManager.AppSettings.Get("NumberOfRestaurantReviewsToShow"));
        }

        public static int GetNumberOfRestaurantPhotosToShow()
        {
            return Convert.ToInt32(ConfigurationManager.AppSettings.Get("NumberOfRestaurantPhotosToShow"));
        }

        public static int GetNumberOfRelatedRestaurantsToShow()
        {
            return Convert.ToInt32(ConfigurationManager.AppSettings.Get("NumberOfRelatedRestaurantsToShow"));
        }
    }
}