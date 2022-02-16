using AnimalServices.Data;
using AnimalServices.Models.Clinic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalServices.Services
{
    public class ClinicService
    {
        private readonly Guid _userId;

        public ClinicService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateClinic(ClinicCreate model)
        {
            var entity =
                new Clinic()
                {
                 ClinicOwnerId = _userId,
                 Name = model.Name,
                 Address = model.Address,
                 ClinicType = model.ClinicType,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Clinics.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ClinicListItem> GetClinics()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Clinics
                        .Where(e => e.ClinicOwnerId == _userId)
                        .Select(e =>
                                new ClinicListItem
                                {
                                    ClinicId = e.ClinicId,
                                    Name = e.Name,
                                    Address = e.Address,
                                    ClinicType = e.ClinicType
                                }
                        );

                return query.ToArray();
            }
        }

        public ClinicDetail GetClinicById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Clinics
                        .Single(e => e.ClinicId == id && e.ClinicOwnerId == _userId);
                return
                    new ClinicDetail
                    {
                        ClinicId = entity.ClinicId,
                        Name = entity.Name,
                        Address = entity.Address,
                        ClinicType = entity.ClinicType
                    };
            }
        }

        public bool UpdateClinic(ClinicEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Clinics
                        .Single(e => e.ClinicId == model.ClinicId && e.ClinicOwnerId == _userId);
                entity.Name = model.Name;
                entity.Address = model.Address;
                entity.ClinicType = model.ClinicType;


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteClinic(int clinicId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Clinics
                        .Single(e => e.ClinicId == clinicId && e.ClinicOwnerId == _userId);

                ctx.Clinics.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
