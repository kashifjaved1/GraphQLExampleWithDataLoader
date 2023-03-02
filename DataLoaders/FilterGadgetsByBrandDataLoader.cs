using GraphQLPractice.Data;
using GraphQLPractice.Data.Entities;
using GreenDonut;
using HotChocolate.Fetching;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQLPractice.DataLoaders
{
    public class FilterGadgetsByBrandDataLoader : BatchDataLoader<string, List<Gadget>>
    {
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

        public FilterGadgetsByBrandDataLoader(IDbContextFactory<AppDbContext> dbContextFactory, BatchScheduler batchScheduler) : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory;
        }

        protected override async Task<IReadOnlyDictionary<string, List<Gadget>>> 
            LoadBatchAsync(IReadOnlyList<string> keys, CancellationToken cancellationToken)
        {
            await using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                var gadgets = await dbContext.Gadgets.
                    .Where(a => keys.Select(b => b.ToLower()).ToList().Contains(a.Brand.ToLower()))
                    .ToListAsync();
                return gadgets.GroupBy(a => a.Brand).Select(b => new // a => a.Brand.ToList()
                {
                    key = b.Key,
                    Gedget = b.ToList()
                }).ToDictionary(k => k.key, v => v.Gedget);
            }
        }
    }
}
