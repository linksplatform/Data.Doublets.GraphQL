﻿using GraphQL.Types;
using Platform.Data.Doublets.Gql.Schema.Types;

namespace Gql.Samples.Schemas.Link.Types
{
    internal class LinksAggregateType : ObjectGraphType
    {
        public LinksAggregateType()
        {
            Field<LinksAggregateFieldsType>("aggregate");
            Field<ListGraphType<LinkType>>("nodes");
        }
    }
}
