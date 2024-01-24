using Domain.Models;

namespace Domain.GraphQL.Mutations
{
    [MutationType]
    public class MenuItemMutation
    {
       public IQueryable<MenuItem> AddMenuItem(MenuItem menuItem, [Service] RestaurantDbContext restaurantDbContext)
        {
            restaurantDbContext.MenuItems.Add(menuItem);
            restaurantDbContext.SaveChanges();
            return restaurantDbContext.MenuItems;
        }
    }
}
