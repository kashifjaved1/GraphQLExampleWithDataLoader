using GraphQLPractice.Data.Entities;
using GraphQLPractice.GraphQL.Schema;
using HotChocolate.Types;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLPractice.GraphQL.ObjectTypes
{
    public class QueryObjectType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(_ => _.GetFirstGadget(default)).Type<GadgetObjectType>().Name("GetFirstGadget"); // .Type<> specify return type of field.

            // Above code will generate following schema for GraphQL.
            /*
             type Query {
                GetFirst: Gadget
            }
             */

            descriptor.Field(_ => _.AllGadgets(default)).Type<ListType<GadgetObjectType>>().Name("AllGadgets");
            descriptor.Field(_ => _.GetGadgetById(default, default)).Type<GadgetObjectType>().Name("FilterGadgetById");
            descriptor.Field(_ => _.GetGadgetsByBrand(default, default)).Type<ListType<GadgetObjectType>>().Name("FilterGadgetsByBrand");
            descriptor.Field(_ => _.GetGadgetsByBrandLoader(default, default, default)).Type<ListType<GadgetObjectType>>().Name("FilterGadgetsByBrandLoader");
        }
    }
}
