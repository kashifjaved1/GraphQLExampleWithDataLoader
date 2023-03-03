using GraphQLPractice.Models.Inputs;
using HotChocolate.Types;

namespace GraphQLPractice.GraphQL.ObjectTypes
{
    public class GadgetInputObjectType : InputObjectType<GadgetInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<GadgetInput> descriptor)
        {
            descriptor.Field(_ => _.Name).Type<StringType>().Name("Name");
            descriptor.Field(_ => _.Brand).Type<StringType>().Name("Brand");
            descriptor.Field(_ => _.Price).Type<DecimalType>().Name("Price");
            descriptor.Field(_ => _.Type).Type<StringType>().Name("Type");
        }
    }
}
