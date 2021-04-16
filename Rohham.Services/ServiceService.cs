using Rohham.Data.Repository;
using Rohham.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rohham.Services
{
    public interface IServiceService
    {
        void CreateService(Service service);
        void UpdateService(Service service);
        Service GetService(int id);
        IList<Service> GetServices();
        void CreateServiceFeature(ServiceFeature serviceFeature);
        void UpdateServiceFeature(Service service);
        ServiceFeature GetServiceFeature(int id);
    }

    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _repo;

        public ServiceService(IServiceRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public void CreateService(Service service)
        {
            _repo.CraeteService(service);
        }

        public void UpdateService(Service service)
        {
            _repo.UpdateService(service);
        }

        public Service GetService(int id)
        {
            return _repo.GetService(id);
        }

        public void CreateServiceFeature(ServiceFeature serviceFeature)
        {
            _repo.CraeteServiceFeature(serviceFeature);
        }

        public void UpdateServiceFeature(Service service)
        {
            _repo.UpdateService(service);
        }

        public ServiceFeature GetServiceFeature(int id)
        {
            return _repo.GetServiceFeature(id);
        }

        public IList<Service> GetServices()
        {
            return _repo.GetServices();
        }
    }
}
