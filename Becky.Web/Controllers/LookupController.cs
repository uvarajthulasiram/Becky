using System.Linq;
using System.Web.Mvc;
using Becky.Data;
using Becky.Task.Interface;
using Becky.Web.Helpers;
using Becky.Web.Models;

namespace Becky.Web.Controllers
{
    public class LookupController : Controller
    {
        private readonly ILookupTask _lookupTask;
        private readonly IMappingService _mappingService;

        public LookupController(ILookupTask lookupTask, IMappingService mappingService)
        {
            _lookupTask = lookupTask;
            _mappingService = mappingService;
        }

        public JsonResult GetCuisines()
        {
            return Json(_lookupTask.GetCuisines().Select(
                type => _mappingService.Map<LookupRestaurantType, CuisineModel>(type)).ToList());
        }
    }
}