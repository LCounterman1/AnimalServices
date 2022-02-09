using AnimalServices.Data;
using AnimalServices.Models.Service;
using AnimalServices.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalServices.Services
{
    public class ServiceService
    {
        private readonly Guid _userId;

        public ServiceService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateService(ServiceCreate service)
        {
            if (service is null) return false;

            var entity =
                new Service()
                {
                  
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Services.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ServiceListItem> GetServices()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Services
                        .Select(
                            e =>
                                new ServiceListItem
                                {
                                    

                                }
                        );

                return query.ToArray();
            }
        }

        public ServiceDetail GetServiceById(int id)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Services
                            .Single(e => e.ServiceId == id);
                    return
                        new ServiceDetail
                        {
                           
                        };
                }
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateService(ServiceEdit service)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Services
                            .Single(e => e.ServiceId == service.ServiceId);
                    



                    return ctx.SaveChanges() == 1;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteService(int serviceId)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Services
                            .Single(e => e.ServiceId == serviceId);

                    ctx.Services.Remove(entity);

                    return ctx.SaveChanges() == 1;
                }
            }
            catch
            {
                return false;
            }

        }
    }
}
