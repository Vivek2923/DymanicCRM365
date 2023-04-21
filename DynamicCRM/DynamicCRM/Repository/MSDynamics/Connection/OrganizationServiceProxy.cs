using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;

namespace UoPeople.NGPortal.Service.Repository.MSDynamics.Connection
{

    public class OrganizationServiceProxy : OrganizationServiceContext, IOrganizationService, IOrganizationServiceProxy
    {
        private bool _proxyTypesBehaviorIsAdded = false;
        readonly IOrganizationService _ioService;

        public OrganizationServiceProxy(ServiceClient connection)
            : base(connection)
        {
            this._ioService = connection;
        }

        public Guid Create(Entity entity)
        {
            if (!_proxyTypesBehaviorIsAdded)
            {
                _proxyTypesBehaviorIsAdded = true;
            }

            return _ioService.Create(entity);

        }
        public new OrganizationResponse Execute(OrganizationRequest request)
        {
            if (_proxyTypesBehaviorIsAdded)
            {
                _proxyTypesBehaviorIsAdded = false;
            }
            return _ioService.Execute(request);
        }
        public void Update(Entity entity)
        {
            if (!_proxyTypesBehaviorIsAdded)
            {
                _proxyTypesBehaviorIsAdded = true;
            }

            _ioService.Update(entity);

        }
        public void Delete(string entityName, Guid id)
        {
            if (!_proxyTypesBehaviorIsAdded)
            {
                _proxyTypesBehaviorIsAdded = true;
            }

            _ioService.Delete(entityName, id);

        }
        public void Disassociate(string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities)
        {
            if (!_proxyTypesBehaviorIsAdded)
            {
                _proxyTypesBehaviorIsAdded = true;
            }

            _ioService.Disassociate(entityName, entityId, relationship, relatedEntities);

        }
        public void Associate(string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities)
        {
            if (!_proxyTypesBehaviorIsAdded)
            {
                _proxyTypesBehaviorIsAdded = true;
            }

            _ioService.Associate(entityName, entityId, relationship, relatedEntities);
        }
        public Entity Retrieve(string entityName, Guid id, ColumnSet columnSet)
        {
            if (!_proxyTypesBehaviorIsAdded)
            {
                _proxyTypesBehaviorIsAdded = true;
            }

            return _ioService.Retrieve(entityName, id, columnSet);
        }
        public EntityCollection RetrieveMultiple(QueryBase query)
        {
            if (!_proxyTypesBehaviorIsAdded)
            {
                _proxyTypesBehaviorIsAdded = true;
            }

            return _ioService.RetrieveMultiple(query);
        }
    }
}