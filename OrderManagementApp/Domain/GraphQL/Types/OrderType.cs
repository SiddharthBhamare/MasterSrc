using Domain.Models;

namespace Domain.GraphQL.Types
{
    public class OrderType : ObjectType<Order>
    {
        protected override void Configure(IObjectTypeDescriptor<Order> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Field(f => f.OrderId).Description("ID");
            descriptor.Field(f => f.OrderDate);
            descriptor.Field(f => f.Bill);
            descriptor.Field(f => f.OrderItems);
        }
    }
}
