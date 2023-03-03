using GraphQLPractice.Data.Entities;
using GraphQLPractice.Models;
using HotChocolate.Types;
using System;

namespace GraphQLPractice.GraphQL.ObjectTypes
{
    public class GadgetObjectType : ObjectType<Gadget>
    {
        protected override void Configure(IObjectTypeDescriptor<Gadget> descriptor)
        {
            descriptor.Field(_ => _.Id).Type<IntType>().Name("Id"); // .Type<> specify return type of field.
            descriptor.Field(_ => _.Name).Type<StringType>().Name("Name");
            descriptor.Field(_ => _.Brand).Type<StringType>().Name("Brand");
            descriptor.Field(_ => _.Price).Type<DecimalType>().Name("Price");
            descriptor.Field(_ => _.Type).Type<StringType>().Name("Type");

            // Above code will generate following schema for GraphQL.
            /*
             type Gadgets {
                Id: Int,
                Name: String,
                Brand: String,
                Price: Decimal,
                Type: String
            }
             */
        }
    }
}
