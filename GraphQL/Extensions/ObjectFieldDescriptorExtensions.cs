using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLPractice.GraphQL.Extensions
{
    public static class ObjectFieldDescriptorExtensions
    {
        public static IObjectFieldDescriptor UseDbContext<T>(this IObjectFieldDescriptor descriptor) where T : DbContext
        {
            return descriptor.UseScopedService(
                create: a => a.GetRequiredService<IDbContextFactory<T>>().CreateDbContext(),
                dispose: (a, b) => b.DisposeAsync()
            );
        }
    }
}
