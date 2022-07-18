﻿using System.ComponentModel.DataAnnotations;

namespace MyLeasing.Web.Data.Ententies
{
    public class Owner
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
        public string NomeCompleto
        {
            get { return $"{FirstName} {LastName}"; }
        }
    }
}