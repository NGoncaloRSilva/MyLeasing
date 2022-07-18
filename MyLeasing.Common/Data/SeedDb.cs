using MyLeasing.Web.Data.Ententies;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Common.Data
{
    public class SeedDb
    {
        private readonly DataContext _contex;
        private Random _random;

        public SeedDb(DataContext contex)
        {
            _contex = contex;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _contex.Database.EnsureCreatedAsync();

            if (!_contex.Owners.Any())
            {
                AddOwner("João ","Rodrigues","Rua da verdade verdadinha 21 A");
                AddOwner("Maria ","Calhas", "Av. da Liberdade 22");
                AddOwner("Maria ","Lópes", "Travessa das Flores 1");
                AddOwner("Rui ","Costa", "Estádio da Luz");
                AddOwner("Joana", " Sousa", "Rua da verdade verdadinha 23 B");
                AddOwner("Mario ", "Carreto", "Av. da Liberdade 42");
                AddOwner("Mario ", "Santana", "Travessa das Flores 6");
                AddOwner("Rute ", "Silva", "Estádio do Sporting");
                AddOwner("Vitória", "Mata", "Rua da mentira 5 A");
                AddOwner("Tatiana ", "Santos", "Av. do Camões 26");
                await _contex.SaveChangesAsync();
            }
        }

        private void AddOwner(string name, string name2, string name3)
        {
            _contex.Owners.Add(new Owner
            {
                Document = _random.Next(1234567, 99999999),
                FirstName = name,
                LastName = name2,
                FixedPhone = _random.Next(210000000, 239999999),
                CellPhone = _random.Next(910000000,969999999),
                Adress = name3
                
            });
        }
    }
}
