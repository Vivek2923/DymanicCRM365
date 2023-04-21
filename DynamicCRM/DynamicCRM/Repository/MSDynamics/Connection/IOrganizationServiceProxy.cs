using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace UoPeople.NGPortal.Service.Repository.MSDynamics.Connection
{
    public interface IOrganizationServiceProxy
    {
        void Associate(string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities);
        Guid Create(Entity entity);
        void Delete(string entityName, Guid id);
        void Disassociate(string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities);
        OrganizationResponse Execute(OrganizationRequest request);
        Entity Retrieve(string entityName, Guid id, ColumnSet columnSet);
        EntityCollection RetrieveMultiple(QueryBase query);
        void Update(Entity entity);
    }
}