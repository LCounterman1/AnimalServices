using AnimalServices.Data;
using AnimalServices.Models.Registry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalServices.Services
{
    public class RegistryService
    {
        private readonly Guid _userId;

        public RegistryService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateRegistry(RegistryCreate registry)
        {
            var entity =
                new Registry()
                {
                    AptDate = registry.AptDate,
                    AptTime = registry.AptDate,
                    AnimalId = registry.AnimalId,
                    ServiceId = registry.ServiceId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Registries.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RegistryListItem> GetRegistries()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Registries
                        .Select(
                            e =>
                                new RegistryListItem
                                {
                                    RegistryId = e.RegistryId,
                                    AnimalId = e.AnimalId,
                                    ServiceId = e.ServiceId,
                                    AptDate = e.AptDate,
                                    AptTime = e.AptTime,
                                }
                        );

                return query.ToArray();
            }
        }

        public RegistryDetail GetRegistryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Registries
                        .Single(e => e.RegistryId == id);
                return
                    new RegistryDetail
                    {
                        RegistryId = entity.RegistryId,
                        AnimalId = entity.AnimalId,
                        ServiceId = entity.ServiceId,
                        AptDate = entity.AptDate,
                        AptTime = entity.AptTime
                    };
            }
        }


        public bool UpdateRegistry(RegistryEdit registry)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Registries
                        .Single(e => e.RegistryId == registry.RegistryId);

                entity.AptDate = registry.AptDate;
                entity.AptTime = registry.AptTime;

                return ctx.SaveChanges() == 1;
            }
        }



        public bool DeleteRegistry(int registryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Registries
                        .Single(e => e.RegistryId == registryId);

                ctx.Registries.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
