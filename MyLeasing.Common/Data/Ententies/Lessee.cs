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

        public string Document { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Fixed Phone")]
        public int FixedPhone { get; set; }

        [Display(Name = "Cell Phone")]
        public string CellPhone { get; set; }

        public string Adress { get; set; }

        [Display(Name = "Owner Name")]

        public string NomeCompleto()
        {
            return FirstName + LastName;
        }

        [Display(Name = "Image")]
        public Guid ImageId { get; set; }


        public string ImageFullPath => ImageId == Guid.Empty ? $"https://myleasingweb20220901181751.azurewebsites.net/images/noimage.png"
            : $"https://myleasingngrs.blob.core.windows.net/lessees/{ImageId}";

        public string FullName => $"{FirstName} {LastName}";

        public string FullNameWithDocument => $"{FirstName} {LastName} -{Document}";

        public User User { get; set; }
    }
}
