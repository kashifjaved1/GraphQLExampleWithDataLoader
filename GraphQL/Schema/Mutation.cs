using AutoMapper;
using GraphQLPractice.Data;
using GraphQLPractice.Data.Entities;
using GraphQLPractice.Models;
using GraphQLPractice.Models.Inputs;
using GraphQLPractice.UOW;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GraphQLPractice.GraphQL.Schema
{
    public class Mutation
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public Mutation(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<Gadget> CreateGadget(GadgetInput input, [Service] AppDbContext context)
        {
            var gadget = _mapper.Map<Gadget>(input);
            await context.Gadgets.AddAsync(gadget);
            //await _uow.SaveAsync();
            await context.SaveChangesAsync();

            return gadget;
        }
    }
}
