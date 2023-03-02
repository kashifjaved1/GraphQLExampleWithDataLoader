using GraphQLPractice.Data;
using GraphQLPractice.Extensions;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using System.Reflection;

namespace GraphQLPractice.Attributes
{
    public class MyDbContextAttribute : ObjectFieldDescriptorAttribute
    {
        public override void OnConfigure(IDescriptorContext context, IObjectFieldDescriptor descriptor, MemberInfo member)
        {
            descriptor.UseDbContext<AppDbContext>(); // consuming ObjectFieldDescriptor extensions method
        }
    }
}
