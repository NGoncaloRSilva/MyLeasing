using MyLeasing.Common.Data.Ententies;
using System;
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
        public Guid ImageId { get; set; }
        

        public string ImageFullPath => ImageId == Guid.Empty ? $"https://myleasingweb20220901181751.azurewebsites.net/images/noimage.png"
            : $"https://myleasingngrs.blob.core.windows.net/owners/{ImageId}";

        public User User { get; set; }
    }
}
