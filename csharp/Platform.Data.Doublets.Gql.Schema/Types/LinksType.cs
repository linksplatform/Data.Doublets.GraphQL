using System.Collections.Generic;
using System.Linq;
using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Platform.Data.Doublets.Gql.Schema.Types
{
    using MappedType = Links;

    /// <remarks>
    ///     """
    ///     columns and relationships of "links"
    ///     """
    ///     type links {
    ///     """An object relationship"""
    ///     from: links
    ///     from_id: bigint!
    ///     id: bigint!
    ///     """An array relationship"""
    ///     in(
    ///     """distinct select on columns"""
    ///     distinct_on: [links_select_column!]
    ///     """limit the number of rows returned"""
    ///     limit: Int
    ///     """skip the first n rows. Use only with OrderBy"""
    ///     offset: Int
    ///     """sort the rows by one or more columns"""
    ///     OrderBy: [links_order_by!]
    ///     """filter the rows returned"""
    ///     where: links_bool_exp
    ///     ): [links!]!
    ///     """An aggregated array relationship"""
    ///     in_aggregate(
    ///     """distinct select on columns"""
    ///     distinct_on: [links_select_column!]
    ///     """limit the number of rows returned"""
    ///     limit: Int
    ///     """skip the first n rows. Use only with OrderBy"""
    ///     offset: Int
    ///     """sort the rows by one or more columns"""
    ///     OrderBy: [links_order_by!]
    ///     """filter the rows returned"""
    ///     where: links_bool_exp
    ///     ): links_aggregate!
    ///     """An array relationship"""
    ///     out(
    ///     """distinct select on columns"""
    ///     distinct_on: [links_select_column!]
    ///     """limit the number of rows returned"""
    ///     limit: Int
    ///     """skip the first n rows. Use only with OrderBy"""
    ///     offset: Int
    ///     """sort the rows by one or more columns"""
    ///     OrderBy: [links_order_by!]
    ///     """filter the rows returned"""
    ///     where: links_bool_exp
    ///     ): [links!]!
    ///     """An aggregated array relationship"""
    ///     out_aggregate(
    ///     """distinct select on columns"""
    ///     distinct_on: [links_select_column!]
    ///     """limit the number of rows returned"""
    ///     limit: Int
    ///     """skip the first n rows. Use only with OrderBy"""
    ///     offset: Int
    ///     """sort the rows by one or more columns"""
    ///     OrderBy: [links_order_by!]
    ///     """filter the rows returned"""
    ///     where: links_bool_exp
    ///     ): links_aggregate!
    ///     """An object relationship"""
    ///     to: links
    ///     to_id: bigint!
    ///     """An object relationship"""
    ///     type: links
    ///     type_id: bigint!
    ///     }
    /// </remarks>
    public class LinksType : ObjectGraphType<MappedType>
    {
        public LinksType()
        {
            Name = "links";
            Field(o => o.from, true, typeof(LinksType)).Resolve(ResolveFrom);
            Field<LongGraphType>(nameof(MappedType.from_id));
            Field<LongGraphType>(nameof(MappedType.id));
            Field<ListGraphType<LinksType>>("in", null, LinksQuery.Arguments, ResolveIn);
            Field<LinksAggregateType>("in_aggregate", null, LinksQuery.Arguments, ResolveInAggregate);
            Field<ListGraphType<LinksType>>("out", null, LinksQuery.Arguments, ResolveOut);
            Field<LinksAggregateType>("out_aggregate", null, LinksQuery.Arguments, ResolveOutAggregate);
            Field(o => o.to, true, typeof(LinksType)).Resolve(ResolveTo);
            Field<LongGraphType>(nameof(MappedType.to_id));
            Field(o => o.type, true, typeof(LinksType)).Resolve(ResolveType);
            Field<LongGraphType>(nameof(MappedType.type_id));
        }

        private LinksAggregateType ResolveInAggregate(IResolveFieldContext<Links> context)
        {
            return new();
        }

        private LinksAggregateType ResolveOutAggregate(IResolveFieldContext<Links> context)
        {
            return new();
        }

        private List<Links> ResolveIn(IResolveFieldContext<Links> context)
        {
            return LinksQuery.GetLinks(context, null, context.Source.id).ToList();
        }

        private List<Links> ResolveOut(IResolveFieldContext<Links> context)
        {
            return LinksQuery.GetLinks(context, context.Source.id).ToList();
        }

        private Links ResolveFrom(IResolveFieldContext<Links> context)
        {
            return context.Source.from ?? GetLinkOrDefault(context, context.Source.from_id);
        }

        private Links ResolveTo(IResolveFieldContext<Links> context)
        {
            return context.Source.to ?? GetLinkOrDefault(context, context.Source.to_id);
        }

        private Links ResolveType(IResolveFieldContext<Links> context)
        {
            return context.Source.type ?? GetLinkOrDefault(context, context.Source.type_id);
        }

        public static Links GetLinkOrDefault(IResolveFieldContext<Links> context, long linkId)
        {
            return GetLinkOrDefault(context.RequestServices.GetService<ILinks<ulong>>(), linkId);
        }

        public static Links GetLinkOrDefault(object service, long linkId)
        {
            return GetLinkOrDefault((ILinks<ulong>)service, (ulong)linkId);
        }

        public static Links GetLinkOrDefault(ILinks<ulong> links, ulong link)
        {
            return links.Exists(link) ? new Links(links.GetLink(link)) : null;
        }
    }
}
