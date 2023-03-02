using GraphQLPractice.Schema;
using HotChocolate.Types;

namespace GraphQLPractice.ObjectTypes
{
    public class MutationObjectType : ObjectType<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor.Field(_ => _.CreateGadget(default, default)).Type<GadgetObjectType>().Name("Create")
                .Argument("input", x => x.Type<GadgetInputObjectType>());
        }
    }
}
