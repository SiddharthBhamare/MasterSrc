using Domain.Models;

namespace Domain.GraphQL.Mutations
{

    [MutationType]
    public class CustomerMutation
    {
        public IQueryable<Customer> AddCustomer(Customer customer, [Service] RestaurantDbContext restaurantDbContext)
        {
            restaurantDbContext.Customers.Add(customer);
            restaurantDbContext.SaveChanges();
            return restaurantDbContext.Customers;
        }
    }
}
