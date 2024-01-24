using Domain.Models;

namespace Domain.GraphQL.Types
{
    public class BillType: ObjectType<Bill>
    {
        protected override void Configure(IObjectTypeDescriptor<Bill> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Field<Bill>(f => f.BillId);
            descriptor.Field(f => f.OrderId);
            descriptor.Field(f => f.TotalAmount);
            descriptor.Field(f => f.order);
        }
    }
}
