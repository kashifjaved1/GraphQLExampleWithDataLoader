using GraphQLPractice.Data;
using GraphQLPractice.GraphQL.Extensions;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using System.Reflection;

namespace GraphQLPractice.GraphQL.Attributes
{
    public class UseAppDbContextAttribute : ObjectFieldDescriptorAttribute
    {
        public override void OnConfigure(IDescriptorContext context, IObjectFieldDescriptor descriptor, MemberInfo member)
        {
            descriptor.UseDbContext<AppDbContext>(); // consuming ObjectFieldDescriptor extensions method
        }
    }
}
