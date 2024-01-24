using Domain.Models;

namespace Domain.GraphQL.Queries
{
    [QueryType]
    public class OrderQueries
    {
        public IQueryable<Order> GetOrders([Service] RestaurantDbContext restaurantDbContext)
        {
            return restaurantDbContext.Orders;
        }
    }
}
