﻿using GraphQL.Types;

namespace Platform.Data.Doublets.Gql.Schema.Types.Input
{
    internal class LinkInputType : InputObjectGraphType
    {
        public LinkInputType()
        {
            Field<LongGraphType>("id", null, true, null);
            Field<LongGraphType>("from_id", null, true, null);
            Field<LongGraphType>("to_id", null, true, null);
            Field<LongGraphType>("type_id", null, true, null);
        }
    }
}
