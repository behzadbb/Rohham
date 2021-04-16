using Rohham.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rohham.Data.Repository
{
    public interface IServiceRepository
    {
        void CraeteService(Service service);

        void CraeteServiceFile(ServiceFile serviceFile);

        void CraeteServiceFeature(ServiceFeature serviceFeature);

        void UpdateService(Service service);

        void UpdateServiceFile(ServiceFile serviceFile);

        void UpdateServiceFeature(ServiceFeature serviceFeature);

        Service GetService(int id);

        IList<Service> GetServices();

        ServiceFeature GetServiceFeature(int id);

        IList<ServiceFeature> GetServiceFeatures();

        ServiceFile GetServiceFile(int id);

        IList<ServiceFile> GetServiceFiles();
    }
}
