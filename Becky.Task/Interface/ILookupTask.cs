using System.Collections.Generic;
using Becky.Data;

namespace Becky.Task.Interface
{
    public interface ILookupTask
    {
        IList<LookupRestaurantType> GetCuisines();
    }
}