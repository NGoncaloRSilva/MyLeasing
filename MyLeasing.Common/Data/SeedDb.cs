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

            //Criação customer

            var user2 = await _userHelper.GetUserbyEmailAsync("joaoricardo@gmail.com");
            if (user2 == null)
            {
                user2 = new User
                {
                    Document = "864897762",
                    FirstName = "Joao",
                    LastName = "Ricardo",
                    Email = "joaoricardo@gmail.com",
                    UserName = "joaoricardo@gmail.com",
                    PhoneNumber = "212344555",
                    Address = "Rua do Cinel 321"
                };

                var result = await _userHelper.AddUserAsync(user2, "123456");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

                await _userHelper.AddUserToRoleAsync(user2, "Owner");
            }

            var isInRole2 = await _userHelper.IsUserInRoleAsync(user, "Owner");

            if (!isInRole2)
            {
                await _userHelper.AddUserToRoleAsync(user2, "Owner");
            }

            if (!_contex.Owners.Any())
            {
                AddOwnerAsync("Nuno", "Silva", "Cinel", user);
                AddOwnerAsync("Joao","Rodrigues","Rua da verdade verdadinha 21 A",user);
                AddOwnerAsync("Maria","Calhas", "Av. da Liberdade 22", user);
                AddOwnerAsync("Maria","Lopes", "Travessa das Flores 1", user);
                AddOwnerAsync("Rui","Costa", "Estádio da Luz", user);
                AddOwnerAsync("Joana", "Sousa", "Rua da verdade verdadinha 23 B", user);
                AddOwnerAsync("Mario", "Carreto", "Av. da Liberdade 42", user);
                AddOwnerAsync("Mario", "Santana", "Travessa das Flores 6", user);
                AddOwnerAsync("Rute", "Silva", "Estádio do Sporting", user);
                AddOwnerAsync("Vitoria", "Mata", "Rua da mentira 5 A", user);
                AddOwnerAsync("Tatiana", "Santos", "Av. do Camões 26", user);
                AddLesseeAsync("Luis", "Camoes", "Rua do Monstrengo", user);
                AddLesseeAsync("Luisa", "Dias", "Praceta da Noite", user);
                AddLesseeAsync("Americo", "Vasco", "Avenida da India", user);
                AddLesseeAsync("Beatriz", "Marques", "Rua da Catarina", user);
                AddLesseeAsync("Leandro", "Moreira", "Avenida do Poeta", user);
                await _contex.SaveChangesAsync();
            }



        }

        private void AddLesseeAsync(string name, string name2, string name3, User user)
        {
            //var user = new User
            //{


            //    PhoneNumber = _random.Next(910000000, 969999999).ToString(),
            //    Document = _random.Next(1234567, 99999999).ToString(),
            //    FirstName = name,
            //    LastName = name2,
            //    Address = name3,
            //    Email = name + name2 + "@gmail.com",
            //    UserName = name + name2 + "@gmail.com",
            //};

            //var result = await _userHelper.AddUserAsync(user, "123456");

            //if (result != IdentityResult.Success)
            //{
            //    throw new InvalidOperationException("Could not create the user in seeder");
            //}

            _contex.Lessees.Add(new Lessee
            {
                Document = /*Convert.ToInt32(user.Document)*/_random.Next(1234567, 99999999).ToString(),
                FirstName = name,
                LastName = name2,
                FixedPhone = _random.Next(210000000, 239999999),
                CellPhone = /*Convert.ToInt32(user.PhoneNumber)*/_random.Next(910000000, 969999999).ToString(),
                Adress = name3,
                User = user
            });
        }

        private void AddOwnerAsync(string name, string name2, string name3, User user)
        {
            //var user = new User
            //{
                
                
            //    PhoneNumber = _random.Next(910000000, 969999999).ToString(),
            //    Document = _random.Next(1234567, 99999999).ToString(),
            //    FirstName = name,
            //    LastName = name2,
            //    Address = name3,
            //    Email = name + name2 + "@gmail.com",
            //    UserName = name + name2 + "@gmail.com",
            //};

            //var result = await _userHelper.AddUserAsync(user, "123456");

            //if (result != IdentityResult.Success)
            //{
            //    throw new InvalidOperationException("Could not create the user in seeder");
            //}

            _contex.Owners.Add(new Owner
            {
                Document = /*Convert.ToInt32(user.Document)*/_random.Next(1234567, 99999999).ToString(),
                FirstName = name,
                LastName = name2,
                FixedPhone = _random.Next(210000000, 239999999),
                CellPhone = /*Convert.ToInt32(user.PhoneNumber)*/_random.Next(910000000, 969999999).ToString(),
                Adress = name3,
                User = user
            });
        }
    }
}
