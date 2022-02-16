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
        public bool CreateAnimal(AnimalCreate animal)
        {
            var entity =
                new Animal()
                {
                    OwnerId = _userId,
                    Name = animal.Name,
                    Species = animal.Species,
                    DateOfBirth = animal.DateOfBirth,
                    Weight = animal.Weight,
                    State = animal.State,
                    IsFood = animal.IsFood,
                    IsBred = animal.IsBred,
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
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new AnimalListItem
                                {
                                    AnimalId = e.AnimalId,
                                    Name = e.Name,
                                    Species = e.Species,
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
                        .Single(e => e.AnimalId == id && e.OwnerId == _userId);
                return
                    new AnimalDetail
                    {
                        AnimalId = entity.AnimalId,
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


        public bool UpdateAnimal(AnimalEdit animal)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Animals
                        .Single(e => e.AnimalId == animal.AnimalId && e.OwnerId == _userId);
                entity.Name = animal.Name;
                entity.Weight = animal.Weight;
                entity.State = animal.State;
                entity.IsBred = animal.IsBred;



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
                        .Single(e => e.AnimalId == animalId && e.OwnerId == _userId);

                ctx.Animals.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}