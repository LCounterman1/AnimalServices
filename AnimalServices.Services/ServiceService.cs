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

            var entity =
                new Service()
                {
                    ServiceType = service.ServiceType,
                    Price = service.Price,
                    Length = service.Length,
                    ClinicId = service.ClinicId

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
                                    ServiceId = e.ServiceId,
                                    ServiceType = e.ServiceType,
                                    ClinicId = e.ClinicId,
                                    Price = e.Price,
                                    Length = e.Length

                                }
                        );

                return query.ToArray();
            }
        }

        public ServiceDetail GetServiceById(int id)
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
                        ServiceId = entity.ServiceId,
                        ServiceType = entity.ServiceType,
                        Price = entity.Price,
                        Length = entity.Length,
                        ClinicId = entity.ClinicId,
                        ClinicName = entity.Clinic.Name
                    };
            }
        }


        public bool UpdateService(ServiceEdit service)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Services
                        .Single(e => e.ServiceId == service.ServiceId);

                entity.ServiceType = service.ServiceType;
                entity.Price = service.Price;
                entity.Length = service.Length;


                return ctx.SaveChanges() == 1;
            }
        }



        public bool DeleteService(int serviceId)
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

    }
}
