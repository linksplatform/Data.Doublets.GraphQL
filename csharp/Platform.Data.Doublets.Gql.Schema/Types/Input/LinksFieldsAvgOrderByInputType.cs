namespace Platform.Data.Doublets.Gql.Schema.Types.Input
{
    /// <remarks>
    ///     """
    ///     order by avg() on columns of table "links"
    ///     """
    ///     input links_avg_order_by {
    ///     from_id: OrderBy
    ///     id: OrderBy
    ///     to_id: OrderBy
    ///     type_id: OrderBy
    ///     }
    /// </remarks>
    public class LinksFieldsAvgOrderByInputType : LinksFieldsOrderByInputType
    {
        public LinksFieldsAvgOrderByInputType() : base("links_avg_order_by")
        {
        }
    }
}
