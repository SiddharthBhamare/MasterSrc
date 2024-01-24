using Domain.Models;

namespace Domain.GraphQL.Types
{
    public class CustomerType :ObjectType<Customer>
    {
        protected override void Configure(IObjectTypeDescriptor<Customer> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Field(f => f.CustomerId);
            descriptor.Field(f => f.Name);
            descriptor.Field(f => f.Email);
            descriptor.Field(f => f.Orders);
            descriptor.Field(f => f.Bills);
        }
    }
}
