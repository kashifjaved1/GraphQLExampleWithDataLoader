using GraphQLPractice.Attributes;
using GraphQLPractice.Data;
using GraphQLPractice.Data.Entities;
using GraphQLPractice.DataLoaders;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQLPractice.Schema
{
    public class Query
    {
        // resolvers

        public async Task<Gadget> GetFirstGadget([Service] AppDbContext context)
        {
            //return new Gadget
            //{
            //    Id = 1,
            //    Name= "Foo",
            //    Brand = "Bar",
            //    Price = 10,
            //    Type = "Dummy"
            //};

            return await context.Gadgets.FirstOrDefaultAsync();
        }

        public async Task<List<Gadget>> AllGadgets([Service] AppDbContext context)
        {
            return await context.Gadgets.ToListAsync();
        }

        public async Task<Gadget> GetGadgetById(int id, [Service] AppDbContext context)
        {
            var gadget = await context.Gadgets.FirstOrDefaultAsync(x => x.Id == id);
            if(gadget != null) return gadget;
            return null;
        }

        [MyDbContext] // consuming MyDbContextAttribute, and now I [ScopedService] can be use with it. This will make the resolvers thread-lock and multi-graphql fragment hit seperately to db.
        public async Task<List<Gadget>> GetGadgetsByBrand(string brand, [ScopedService] AppDbContext context)
        {
            var gadget = await context.Gadgets.Where(x => x.Brand.ToLower() == brand.ToLower())?.ToListAsync();
            if (gadget != null) return gadget;
            return null;
        }
        public async Task<List<Gadget>> GetGadgetsByBrandLoader(string brand, 
            FilterGadgetsByBrandDataLoader loader,
            CancellationToken cancellationToken
        )
        {
            return await loader.LoadAsync(brand, cancellationToken);
        }
    }
}
