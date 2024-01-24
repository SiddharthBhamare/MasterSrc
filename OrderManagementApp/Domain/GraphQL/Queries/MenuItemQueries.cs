using Domain.Models;

namespace Domain.GraphQL.Queries
{

    [QueryType]
    public class MenuItemQueries
    {
        public IQueryable<MenuItem> GetMenuItems([Service] RestaurantDbContext restaurantDbContext)
        {
            return restaurantDbContext.MenuItems;
        }
    }
}
