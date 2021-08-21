using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Sockets;
using GraphQL.Types;
using Platform.Data.Doublets;
using Microsoft.Extensions.DependencyInjection;
using Platform.Data;
using Platform.Memory;
using Platform.Data.Doublets.Gql.Schema;
using GraphQL;

namespace Input
{
    public class LinkType : ObjectGraphType<Link>
    {
        public LinkType()
        {
            Field(o => o.id);
            Field(o => o.from_id);
            Field(o => o.from, false, type: typeof(LinkType)).Resolve(ResolveFrom);
            Field(o => o.to, type: typeof(LinkType)).Resolve(ResolveTo);
            Field(o => o.to_id);
            Field(o => o.type, type: typeof(LinkType)).Resolve(ResolveType);
            Field(o => o.type_id);
            Field<ListGraphType<LinkType>>().Name("in").Resolve(ResolveIn);
            Field<ListGraphType<LinkType>>().Name("out").Resolve(ResolveOut);
        }

        private List<Link> ResolveIn(IResolveFieldContext<Link> context) => (List<Link>)LinkQuery.GetLinks(context, (ILinks<ulong>)context.RequestServices.GetService(typeof(ILinks<ulong>)), null, context.Source.id);
        private List<Link> ResolveOut(IResolveFieldContext<Link> context) => (List<Link>)LinkQuery.GetLinks(context, (ILinks<ulong>)context.RequestServices.GetService(typeof(ILinks<ulong>)), context.Source.id, null);

        private Link ResolveFrom(IResolveFieldContext<Link> context) => context.Source.@from ?? GetLinkOrDefault(context, context.Source.from_id);

        private Link ResolveTo(IResolveFieldContext<Link> context) => context.Source.to ?? GetLinkOrDefault(context, context.Source.to_id);

        private Link ResolveType(IResolveFieldContext<Link> context) => context.Source.type ?? GetLinkOrDefault(context,context.Source.type_id);

        public static Link GetLinkOrDefault(IResolveFieldContext<Link> context, long linkId) => GetLinkOrDefault(context.RequestServices.GetService(typeof(ILinks<ulong>))
            , (linkId));
      
        public static Link GetLinkOrDefault(object service, long linkId) => GetLinkOrDefault((ILinks<ulong>)service, (ulong)linkId);

        public static Link GetLinkOrDefault(ILinks<ulong> links, ulong link) => links.Exists(link) ? new Link(links.GetLink(link)) :  null;
    }
}
