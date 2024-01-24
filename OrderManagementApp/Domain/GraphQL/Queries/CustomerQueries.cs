using Domain.Models;

namespace Domain.GraphQL.Queries
{
    [QueryType]
    public class CustomerQueries
    {
        public IQueryable<Customer> GetCustomers([Service] RestaurantDbContext restaurantDbContext)
        {
            return restaurantDbContext.Customers;
        }
    }
}
