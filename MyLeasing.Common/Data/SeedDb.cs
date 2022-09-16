using Microsoft.AspNetCore.Identity;
using MyLeasing.Common.Data.Ententies;
using MyLeasing.Common.Helpers;
using MyLeasing.Web.Data.Ententies;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

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

            await _userHelper.CheckRoleAsync("Admin");
            await _userHelper.CheckRoleAsync("Owner");
            await _userHelper.CheckRoleAsync("Lessee");

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

                await _userHelper.AddUserToRoleAsync(user, "Admin");
            }

            var isInRole = await _userHelper.IsUserInRoleAsync(user, "Admin");

            if (!isInRole)
            {
                await _userHelper.AddUserToRoleAsync(user, "Admin");
            }

            
            if (!_contex.Owners.Any())
            {
                
                _contex.Owners.Add(new Owner
                {
                    Document = _random.Next(1234567, 99999999).ToString(),
                    FirstName = "Nuno",
                    LastName = "Silva",
                    FixedPhone = _random.Next(210000000, 239999999),
                    CellPhone = _random.Next(910000000, 969999999).ToString(),
                    Adress = "Cinel",
                    User = user
                });
                
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
                await AddLesseeAsync("Luis", "Camoes", "Rua do Monstrengo");
                await AddLesseeAsync("Luisa", "Dias", "Praceta da Noite");
                await AddLesseeAsync("Americo", "Vasco", "Avenida da India");
                await AddLesseeAsync("Beatriz", "Marques", "Rua da Catarina");
                await AddLesseeAsync("Leandro", "Moreira", "Avenida do Poeta");
                await _contex.SaveChangesAsync();
            }



        }

        private async Task AddLesseeAsync(string name, string name2, string name3)
        {
            var user = await _userHelper.GetUserbyEmailAsync("joaoricardo@gmail.com");

            if (user == null)
            {


                user = new User
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

                await _userHelper.AddUserToRoleAsync(user, "Lessee");

            }

            var isInRole = await _userHelper.IsUserInRoleAsync(user, "Lessee");

            if (!isInRole)
            {
                await _userHelper.AddUserToRoleAsync(user, "Lessee");
            }


            _contex.Lessees.Add(new Lessee
            {
                Document = user.Document,
                FirstName = name,
                LastName = name2,
                FixedPhone = _random.Next(210000000, 239999999),
                CellPhone = user.PhoneNumber,
                Adress = name3,
                User = user
            });
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

            await _userHelper.AddUserToRoleAsync(user, "Owner");

            _contex.Owners.Add(new Owner
            {
                Document = user.Document,
                FirstName = name,
                LastName = name2,
                FixedPhone = _random.Next(210000000, 239999999),
                CellPhone = user.PhoneNumber,
                Adress = name3,
                User = user
            });
        }
    }
}
