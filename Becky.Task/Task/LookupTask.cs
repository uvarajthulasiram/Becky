using System.Collections.Generic;
using System.Linq;
using Becky.Data;
using Becky.Data.DataAccess;
using Becky.Task.Interface;

namespace Becky.Task.Task
{
    public class LookupTask : TaskBase, ILookupTask
    {
        private readonly IRepository<LookupRestaurantType> _lookupRestaurantTypeRepository;

        public LookupTask(IRepository<LookupRestaurantType> lookupRestaurantTypeRepository)
        {
            _lookupRestaurantTypeRepository = lookupRestaurantTypeRepository;
        }

        public IList<LookupRestaurantType> GetCuisines()
        {
            return _lookupRestaurantTypeRepository.GetAll().ToList();
        }
    }
}