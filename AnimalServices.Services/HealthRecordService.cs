using AnimalServices.Data;
using AnimalServices.Models.HealthRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalServices.Services
{
    public class HealthRecordService
    {
        private readonly Guid _userId;

        public HealthRecordService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateHealthRecord(HealthRecordCreate model)
        {
            var entity =
                new HealthRecord()
                {
                    Name = model.Name,
                    Address = model.Address,
                    ClinicType = model.ClinicType,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.HealthRecords.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<HealthRecordListItem> GetHealthRecords()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .HealthRecords
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new HealthRecordListItem
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

        public HealthRecordDetail GetHealthRecordById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .HealthRecords
                        .Single(e => e.HealthRecordId == id && e.UserId == _userId);
                return
                    new HealthRecordDetail
                    {
                        ClinicId = entity.ClinicId,
                        Name = entity.Name,
                        Address = entity.Address,
                        ClinicType = entity.ClinicType
                    };
            }
        }

        public bool UpdateHealthRecord(HealthRecordEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .HealthRecords
                        .Single(e => e.HealthRecordId == model.HealthRecordId && e.UserId == _userId);
                entity.ClinicId = model.Id;
                entity.Name = model.Name;
                entity.Address = model.Address;
                entity.ClinicType = model.ClinicType;


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteHealthRecord(int healthRecordId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .HealthRecords
                        .Single(e => e.HealthRecordId == healthRecordId && e.UserId == _userId);

                ctx.HealthRecords.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
