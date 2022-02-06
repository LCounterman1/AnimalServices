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
        private readonly Guid _userId;

        public AnimalService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateAnimal(AnimalCreate model)
        {
            var entity =
                new Animal()
                {
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
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new AnimalListItem
                                {
                                    AnimalId = e.Id,
                                    Name = e.Name,
                                    DateOfBirth = e.DateOfBirth

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
                        .Single(e => e.Id == id && e.UserId == _userId);
                return
                    new AnimalDetail
                    {
                        AnimalId = entity.Id,
                        Name = entity.Name,
                        Species = entity.Species,
                        DateOfBirth = entity.DateOfBirth,
                        Weight = entity.Weight,
                        State = entity.State,
                        IsFood = entity.IsFood,
                        IsBred = entity.IsBred
                    };
            }
        }

        public bool UpdateAnimal(AnimalEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Animals
                        .Single(e => e.Id == model.AnimalId && e.UserId == _userId);
                entity.Id = model.AnimalId;
                entity.Name = model.Name;
                entity.Weight = model.Weight;
                entity.State = model.State;
                entity.IsBred = model.IsBred;



                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAnimal(int animalId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Animals
                        .Single(e => e.Id == animalId && e.UserId == _userId);

                ctx.Animals.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
