using Microsoft.AspNetCore.Identity;
using MyLeasing.Common.Data.Ententies;
using MyLeasing.Common.Helpers;
using MyLeasing.Web.Data.Ententies;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Common.Data
{
    public class SeedDb
    {
        private readonly DataContext _contex;
        private readonly IUserHelper _userHelper;
        private Random _random;

        public SeedDb(DataContext contex, IUserHelper userHelper)
        {
            _contex = contex;
            _userHelper = userHelper;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _contex.Database.EnsureCreatedAsync();

            var user = await _userHelper.GetUserbyEmailAsync("ngoncalorsilva@gmail.com");

            if (user == null)
            {
                user = new User
                {
                    Document = "377509235",
                    FirstName = "Nuno",
                    LastName = "Silva",
                    Email = "ngoncalorsilva@gmail.com",
                    UserName = "ngoncalorsilva@gmail.com",
                    PhoneNumber = "212344555",
                    Address = "Rua do Cinel 123"
                };

                var result = await _userHelper.AddUserAsync(user, "123456");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }
            if (!_contex.Owners.Any())
            {
                
                await AddOwnerAsync("Joao","Rodrigues","Rua da verdade verdadinha 21 A");
                await AddOwnerAsync("Maria","Calhas", "Av. da Liberdade 22");
                await AddOwnerAsync("Maria","Lopes", "Travessa das Flores 1");
                await AddOwnerAsync("Rui","Costa", "Estádio da Luz");
                await AddOwnerAsync("Joana", "Sousa", "Rua da verdade verdadinha 23 B");
                await AddOwnerAsync("Mario", "Carreto", "Av. da Liberdade 42");
                await AddOwnerAsync("Mario", "Santana", "Travessa das Flores 6");
                await AddOwnerAsync("Rute", "Silva", "Estádio do Sporting");
                await AddOwnerAsync("Vitoria", "Mata", "Rua da mentira 5 A");
                await AddOwnerAsync("Tatiana", "Santos", "Av. do Camões 26");
                await _contex.SaveChangesAsync();
            }



        }

        private async Task AddOwnerAsync(string name, string name2, string name3)
        {
            var user = new User
            {
                
                
                PhoneNumber = _random.Next(910000000, 969999999).ToString(),
                Document = _random.Next(1234567, 99999999).ToString(),
                FirstName = name,
                LastName = name2,
                Address = name3,
                Email = name + name2 + "@gmail.com",
                UserName = name + name2 + "@gmail.com",
            };

            var result = await _userHelper.AddUserAsync(user, "123456");

            if (result != IdentityResult.Success)
            {
                throw new InvalidOperationException("Could not create the user in seeder");
            }

            _contex.Owners.Add(new Owner
            {
                Document = Convert.ToInt32(user.Document),
                FirstName = name,
                LastName = name2,
                FixedPhone = _random.Next(210000000, 239999999),
                CellPhone = Convert.ToInt32(user.PhoneNumber),
                Adress = name3,
                User = user
            });
        }
    }
}
