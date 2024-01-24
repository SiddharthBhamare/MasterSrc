using Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.GraphQL.Types
{
    public class MenuItemType : ObjectType<MenuItem>
    {
        protected override void Configure(IObjectTypeDescriptor<MenuItem> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Field(f => f.MenuItemId);
            descriptor.Field(f => f.Name);
            descriptor.Field(f => f.Price);
            descriptor.Field(f => f.MenuItemId);
            descriptor.Field(f => f.OrderItems);
        }
    }
}
