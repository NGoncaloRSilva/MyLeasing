using System.ComponentModel.DataAnnotations;

namespace MyLeasing.Web.Data.Ententies
{
    public class Owner
    {
        public int Id { get; set; }

        public int Document { get; set; }

        [Display(Name = "Owener Name")]
        public string OwnerName { get; set; }

        [Display(Name = "Fixed Phone")]
        public int FixedPhone { get; set; }

        public string Adress { get; set; }
    }
}
