use async_graphql::*;

#[derive(Debug)]
pub struct ObjectsVarPopFields;

#[Object(name = "objects_var_pop_fields")]
impl ObjectsVarPopFields {
    pub async fn id(&self, ctx: &Context<'_>) -> Option<f64> {
        todo!()
    }
    #[graphql(name = "link_id")]
    pub async fn link_id(&self, ctx: &Context<'_>) -> Option<f64> {
        todo!()
    }
}
