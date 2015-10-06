using System.Collections.Generic;
using System.Web.Http;
using Becky.Data;
using Becky.Task.Interface;

namespace Becky.WebApi.Controllers
{
    public class LookupController : ApiController
    {
        private readonly ILookupTask _lookupTask;

        public LookupController(ILookupTask lookupTask)
        {
            _lookupTask = lookupTask;
        }

        public IEnumerable<LookupRestaurantType> GetCuisines() => _lookupTask.GetCuisines();
    }
}
