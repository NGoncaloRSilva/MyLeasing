using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeasing.Common.Data.Ententies
{
    public class Lessee : IEntity
    {
        public int Id { get; set; }

        public int Document { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Fixed Phone")]
        public int FixedPhone { get; set; }

        [Display(Name = "Cell Phone")]
        public int CellPhone { get; set; }

        public string Adress { get; set; }

        [Display(Name = "Owner Name")]

        public string NomeCompleto()
        {
            return FirstName + LastName;
        }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(ImageUrl))
                {
                    return string.Empty;
                }

                return $"https://localhost:44389{ImageUrl.Substring(1)}";
            }
        }

        public string FullName => $"{FirstName} {LastName}";

        public string FullNameWithDocument => $"{FirstName} {LastName} -{Document}";

        public User User { get; set; }
    }
}
