using Rohham.Data.Context;
using Rohham.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Rohham.Data.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        public ApplicationDbContext _db;
        public ApplicationDbContext Db
        {
            get
            {
                if (_db == null)
                {
                    var factory = new ApplicationDbContextFactory();
                    _db = factory.CreateDbContext(new string[] { });
                }
                return _db;
            }
            set
            {
                _db = value;
            }
        }

        public void CraeteService(Service service)
        {
            Db.Services.Add(service);
            Db.SaveChangesAsync();
        }

        public void CraeteServiceFile(ServiceFile serviceFile)
        {
            Db.ServiceFiles.Add(serviceFile);
            Db.SaveChangesAsync();
        }

        public void CraeteServiceFeature(ServiceFeature serviceFeature)
        {
            Db.ServiceFeatures.Add(serviceFeature);
            Db.SaveChangesAsync();
        }

        public void UpdateService(Service service)
        {
            var obj = Db.Services.Find(service.ServiceId);
            obj.Name = service.Name;
            obj.Title = service.Title;
            obj.Description = service.Description;
            obj.Text = service.Text;
            obj.Icon = service.Icon;
            obj.ImageUrl = service.ImageUrl;
            obj.Priority = service.Priority;
            obj.ModifyDate = DateTime.Now;
            Db.SaveChangesAsync();
        }

        public void UpdateServiceFile(ServiceFile serviceFile)
        {
            var obj = Db.ServiceFiles.Find(serviceFile.Id);
            obj.Title = serviceFile.Title;
            obj.FileName = serviceFile.FileName;
            obj.Priority = serviceFile.Priority;
            obj.ServiceId = serviceFile.ServiceId;
            obj.ModifyDate = DateTime.Now;
            Db.SaveChangesAsync();
        }

        public void UpdateServiceFeature(ServiceFeature serviceFeature)
        {
            var obj = Db.ServiceFeatures.Find(serviceFeature.Id);
            obj.Name = obj.Name;
            obj.Title = obj.Title;
            obj.ServiceId = obj.ServiceId;
            obj.Priority = obj.Priority;
            obj.ModifyDate = DateTime.Now;
            Db.SaveChangesAsync();
        }

        public Service GetService(int id)
        {
            var s = Db.Services.Where(x => x.ServiceId == id).Include(x => x.FeatureServices).Include(y => y.ServiceFiles).FirstOrDefault();
            return s;
        }

        public IList<Service> GetServices()
        {
            return Db.Services.OrderBy(x => x.Priority).ToList();
        }

        public ServiceFeature GetServiceFeature(int id)
        {
            return Db.ServiceFeatures.Find(id);
        }

        public IList<ServiceFeature> GetServiceFeatures()
        {
            return Db.ServiceFeatures.OrderBy(x => x.Priority).ToList();
        }

        public ServiceFile GetServiceFile(int id)
        {
            return Db.ServiceFiles.Find(id);
        }

        public IList<ServiceFile> GetServiceFiles()
        {
            return Db.ServiceFiles.OrderBy(x => x.Priority).ToList();
        }
    }
}