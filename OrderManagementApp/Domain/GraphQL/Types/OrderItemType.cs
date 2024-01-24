using Domain.Models;

namespace Domain.GraphQL.Types
{
    public class OrderItemType : ObjectType<OrderItem>
    {
        protected override void Configure(IObjectTypeDescriptor<OrderItem> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Field(f => f.OrderItemId).Description("ID");
            descriptor.Field(f => f.OrderId);
            descriptor.Field(f => f.Quantity);
            descriptor.Field(f => f.MenuItemId);
            descriptor.Field(f => f.Order);
        }
    }
}
