using Becky.Domain.Enums;

namespace Becky.Domain.Entity
{
    public class RestaurantFilter
    {
        public string Name { get; set; }
        public Cuisine? Cuisine { get; set; }
    }
}
