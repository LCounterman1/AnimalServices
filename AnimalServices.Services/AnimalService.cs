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
            if (animal is null) return false;

            var entity =
                new Animal()
                {
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
                        .Select(
                            e =>
                                new AnimalListItem
                                {
                                    AnimalId = e.AnimalId,
                                    Name = e.Name,
                                    DateOfBirth = e.DateOfBirth

                                }
                        );

                return query.ToArray();
            }
        }

        public AnimalDetail GetAnimalById(int id)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Animals
                            .Single(e => e.AnimalId == id);
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
            catch
            {
                return null;
            }
        }

        public bool UpdateAnimal(AnimalEdit animal)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Animals
                            .Single(e => e.AnimalId == animal.AnimalId);
                    entity.AnimalId = animal.AnimalId;
                    entity.Name = animal.Name;
                    entity.Weight = animal.Weight;
                    entity.State = animal.State;
                    entity.IsBred = animal.IsBred;



                    return ctx.SaveChanges() == 1;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteAnimal(int animalId)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Animals
                            .Single(e => e.AnimalId == animalId);

                    ctx.Animals.Remove(entity);

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
