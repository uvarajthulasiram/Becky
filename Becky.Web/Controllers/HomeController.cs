using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using AutoMapper.Internal;
using Becky.Data;
using Becky.Domain.Entity;
using Becky.Domain.Enums;
using Becky.Task.Interface;
using Becky.Web.Helpers;
using Becky.Web.Models;
using Microsoft.AspNet.Identity;

namespace Becky.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRestaurantTask _restaurantTask;
        private readonly ILookupTask _lookupTask;
        private readonly IMappingService _mappingService;

        public HomeController(IMappingService mappingService, IRestaurantTask restaurantTask, ILookupTask lookupTask)
        {
            _mappingService = mappingService;
            _restaurantTask = restaurantTask;
            _lookupTask = lookupTask;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Restaurant(int parameter)
        {
            var restaurant = _restaurantTask.GetRestaurant(parameter);

            return View(_mappingService.Map<ViewRestaurant, RestaurantModel>(restaurant));
        }

        public JsonResult GetAutocompleteValues()
        {
            var autocompleteModels = new List<AutocompleteModel>();
            var cuisines = _lookupTask.GetCuisines().Select(p => p.Type);
            var restaurants = _restaurantTask.GetRestaurants(null).Select(p => p.Name);

            cuisines.Each(p => autocompleteModels.Add(new AutocompleteModel {category = "Cuisine", label = p}));
            restaurants.Each(p => autocompleteModels.Add(new AutocompleteModel {category = "Name", label = p}));

            return Json(autocompleteModels);
        }

        public JsonResult GetRestaurant(int parameter)
        {
            var restaurant = _restaurantTask.GetRestaurant(parameter);

            ViewBag.Title = restaurant.Name;
            return Json(restaurant);
        }

        public JsonResult GetRestaurants(string parameter)
        {
            if(string.IsNullOrWhiteSpace(parameter) || parameter == "undefined")
                return Json(_restaurantTask.GetRestaurants(null).Take(30));

            var restaurantFilter = Enum.IsDefined(typeof(Cuisine), parameter) ? 
                new RestaurantFilter {Cuisine = Helper.ParseEnum<Cuisine>(parameter)} : 
                new RestaurantFilter {Name = parameter};

            return Json(_restaurantTask.GetRestaurants(restaurantFilter).Select(_mappingService.Map<ViewRestaurant, RestaurantModel>).Take(30));
        }

        public JsonResult GetRelatedRestaurants(int parameter)
        {
            return Json(_restaurantTask.GetRelatedRestaurants(parameter).Select(_mappingService.Map<ViewRestaurant, RestaurantModel>).Take(5));
        }

        public JsonResult GetRestaurantPhotos(int parameter) => Json(_restaurantTask.GetRestaurantPhotos(parameter));

        public JsonResult GetRestaurantRating(int parameter)
        {
            return Json(_restaurantTask.GetConsolidatedRating(parameter));
        }

        [Authorize]
        public void PostRestaurantRating(RestaurantRating restaurantRating)
        {
            if (restaurantRating.Id == 0)
                _restaurantTask.AddRestaurantRating(restaurantRating);
            else
                _restaurantTask.UpdateRestaurantRating(restaurantRating);
        }

        public JsonResult GetRestaurantReviews(int parameter) => Json(_restaurantTask.GetRestaurantReviews(parameter).Select(_mappingService.Map<RestaurantReview, RestaurantReviewModel>));

        [Authorize]
        public JsonResult PostRestaurantReview(RestaurantReviewModel model)
        {
            var restaurantReview = new RestaurantReview
            {
                AspNetUserId = User.Identity.GetUserId(),
                RestaurantBranchId = model.RestaurantBranchId,
                ReviewText = model.ReviewText,
                ReviewTypeId = model.ReviewTypeId,
                CreatedOn = DateTime.Now,
                CreatedBy = User.Identity.GetUserId()
            };

            try
            {
                _restaurantTask.AddRestaurantReview(restaurantReview);
                return Json(new { status = ActionStatus.Successful });
            }
            catch (Exception exception)
            {
                return Json(new { status = ActionStatus.Failed, data = exception.Message });
            }
        }

        [Authorize]
        public JsonResult PostRestaurantReviewAsSpam(int parameter)
        {
            try
            {
                _restaurantTask.ReportRestaurantReviewAsSpam(parameter);
                return Json(new { status = ActionStatus.Successful });
            }
            catch (Exception exception)
            {
                return Json(new { status = ActionStatus.Failed, data = exception.Message });
            }
        }

        [Authorize]
        public JsonResult DeleteRestaurantReview(int parameter)
        {
            try
            {
                _restaurantTask.RemoveRestaurantReview(parameter);
                return Json(new { status = ActionStatus.Successful });
            }
            catch (Exception exception)
            {
                return Json(new { status = ActionStatus.Failed, data = exception.Message });
            }
        }
    }
}