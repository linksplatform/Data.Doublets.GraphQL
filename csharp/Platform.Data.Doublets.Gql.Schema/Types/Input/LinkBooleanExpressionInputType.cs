﻿using GraphQL.Types;
using System;

namespace Platform.Data.Doublets.Gql.Schema.Types.Input
{
    public class LinkBooleanExpressionInputType : InputObjectGraphType<LinkBooleanExpression>
    {
        /// <remarks>
        /// """
        /// Boolean expression to filter rows from the table "links". All fields are combined with a logical 'AND'.
        /// """
        /// input links_bool_exp {
        ///   _and: [links_bool_exp]
        ///   _not: links_bool_exp
        ///   _or: [links_bool_exp]
        ///   from: links_bool_exp
        ///   from_id: bigint_comparison_exp
        ///   id: bigint_comparison_exp
        ///   in: links_bool_exp
        ///   out: links_bool_exp
        ///   to: links_bool_exp
        ///   to_id: bigint_comparison_exp
        ///   type: links_bool_exp
        ///   type_id: bigint_comparison_exp
        /// }
        /// </remarks>
        public LinkBooleanExpressionInputType()
        {

            Field(x => x._and, nullable: true,type: typeof(ListGraphType<LinkBooleanExpressionInputType>));
            Field(x => x._or, nullable: true, type: typeof(ListGraphType<LinkBooleanExpressionInputType>));
            Field(x => x._not, nullable: true, type: typeof(LinkBooleanExpressionInputType));
            Field(x => x.from, nullable: true, type: typeof(LinkBooleanExpressionInputType));
            Field(x => x.from_id, nullable: true, type: typeof(LongComparisonExpressionInputType)); 
            Field(x => x.id, nullable: true, type: typeof(LongComparisonExpressionInputType));
            Field(x => x.@in, nullable: true, type: typeof(LinkBooleanExpressionInputType));
            Field(x => x.@out, nullable: true, type: typeof(LinkBooleanExpressionInputType));
            Field(x => x.to, nullable: true, type: typeof(LinkBooleanExpressionInputType));
            Field(x => x.to_id, nullable: true, type: typeof(LongComparisonExpressionInputType));
            Field(x => x.type, nullable: true, type: typeof(LinkBooleanExpressionInputType));
            Field(x => x.type_id, nullable: true, type: typeof(LongComparisonExpressionInputType));
        }
    }
}