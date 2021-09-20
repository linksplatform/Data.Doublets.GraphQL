namespace Platform.Data.Doublets.Gql.Schema.Types.Input
{
    /// <remarks>
    /// """
    /// order by stddev() on columns of table "links"
    /// """
    /// input links_stddev_order_by {
    ///   from_id: order_by
    ///   id: order_by
    ///   to_id: order_by
    ///   type_id: order_by
    /// }
    /// </remarks>
    public class LinksFieldsStdDevOrderByInputType : LinksFieldsOrderByInputType
    {
        public LinksFieldsStdDevOrderByInputType() : base("links_stddev_order_by")
        {
            Field(x => x.from_id, nullable: true, type: typeof(OrderByEnumType));
            Field(x => x.id, nullable: true, type: typeof(OrderByEnumType));
            Field(x => x.to_id, nullable: true, type: typeof(OrderByEnumType));
            Field(x => x.type_id, nullable: true, type: typeof(OrderByEnumType));
        }
    }
}
