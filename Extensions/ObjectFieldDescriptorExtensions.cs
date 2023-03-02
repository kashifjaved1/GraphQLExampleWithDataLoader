using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLPractice.Extensions
{
    public static class ObjectFieldDescriptorExtensions
    {
        public static IObjectFieldDescriptor UseDbContext<T>(this IObjectFieldDescriptor descriptor) where T : DbContext
        {
            return descriptor.UseScopedService<T>(
                create: a => a.GetRequiredService<IDbContextFactory<T>>().CreateDbContext(),
                dispose: (a, b) => b.DisposeAsync()
            ); 
        }
    }
}
