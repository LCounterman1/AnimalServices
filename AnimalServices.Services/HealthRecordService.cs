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
                    RecordType = model.RecordType,
                    DateGiven = model.DateGiven,
                    FrequencyNeeded = model.FrequencyNeeded,
                    Comments = model.Comments,
                    AnimalId = model.AnimalId
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
                        .Where(e => e.AnimalId == e.AnimalId)
                        .Select(
                            e =>
                                new HealthRecordListItem
                                {
                                    HealthRecordId = e.HealthRecordId,
                                    AnimalId = e.AnimalId,
                                    RecordType = e.RecordType,
                                    DateGiven = e.DateGiven
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
                        .Single(e => e.HealthRecordId == id && e.AnimalId == e.AnimalId);
                return
                    new HealthRecordDetail
                    {
                        HealthRecordId = entity.HealthRecordId,
                        AnimalId = entity.AnimalId,
                        RecordType = entity.RecordType,
                        DateGiven = entity.DateGiven,
                        FrequencyNeeded = entity.FrequencyNeeded,
                        Comments = entity.Comments

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
                        .Single(e => e.HealthRecordId == model.HealthRecordId);
                
                entity.Comments = model.Comments;


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
                        .Single(e => e.HealthRecordId == healthRecordId && e.AnimalId == e.AnimalId);

                ctx.HealthRecords.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
