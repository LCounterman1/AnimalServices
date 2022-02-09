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
            if (registry is null) return false;

            var entity =
                new Registry()
                {

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


                                }
                        );

                return query.ToArray();
            }
        }

        public RegistryDetail GetRegistryById(int id)
        {
            try
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

                        };
                }
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateRegistry(RegistryEdit registry)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Registries
                            .Single(e => e.RegistryId == registry.RegistryId);




                    return ctx.SaveChanges() == 1;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteRegistry(int registryId)
        {
            try
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
            catch
            {
                return false;
            }

        }
    }
}
