using AnimalServices.Data;
using AnimalServices.Models.Animal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalServices.Services
{
    public class AnimalService
    {
        private readonly Guid _userID;

        public AnimalService(Guid userID)
        {
            _userID = userID;
        }
        public bool CreateAnimal(AnimalCreate model)
        {
            var entity =
                new Animal()
                {
                    _userID = _userID,
                    Name = model.Name,
                    Species = model.Species,
                    DateOfBirth = model.DateOfBirth,
                    Weight = model.Weight,
                    State = model.State,
                    IsFood = model.IsFood,
                    IsBred = model.IsBred,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Animals.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AnimalListItem> GetAnimals()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Animals
                        .Where(e => e.userID == _userID)
                        .Select(
                            e =>
                                new AnimalListItem
                                {
                                    
                                }
                        );

                return query.ToArray();
            }
        }

        public AnimalDetail GetAnimalById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Animals
                        .Single(e => e.AnimalID == id && e.OwnerID == _userID);
                return
                    new AnimalDetail
                    {
                        
                    };
            }
        }

        public bool UpdateNote(NoteEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Notes
                        .Single(e => e.NoteId == model.NoteId && e.OwnerId == _userId);

                entity.Title = model.Title;
                entity.Content = model.Content;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteNote(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Notes
                        .Single(e => e.NoteId == noteId && e.OwnerId == _userId);

                ctx.Notes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
