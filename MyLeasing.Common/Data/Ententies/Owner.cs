using MyLeasing.Common.Data.Ententies;
using System.ComponentModel.DataAnnotations;

namespace MyLeasing.Web.Data.Ententies
{
    public class Owner : IEntity
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

        public string FullName => $"{FirstName} {LastName}";

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

                return $"https://myleasingweb20220901181751.azurewebsites.net{ImageUrl.Substring(1)}";
            }
        }

        public User User { get; set; }
    }
}
