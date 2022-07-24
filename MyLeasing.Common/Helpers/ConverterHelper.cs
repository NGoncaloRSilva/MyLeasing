
using MyLeasing.Web.Data.Ententies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLeasing.Common.Data.Models;

namespace MyLeasing.Common.Helpers
{
    public class ConverterHelper : IConverterHelper
    {

        public Owner toOwner(OwnerViewModel model, string path, bool isNew)
        {
            return new Owner
            {

                Document = model.Document,
                FirstName = model.FirstName,
                LastName = model.LastName,
                FixedPhone = model.FixedPhone,
                CellPhone = model.CellPhone,
                Adress = model.Adress,
                ImageUrl = path,
                User = model.User

            };
        }

        public OwnerViewModel toOwnerViewModel(Owner owner)
        {
            return new OwnerViewModel
            {
                Document = owner.Document,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                FixedPhone = owner.FixedPhone,
                CellPhone = owner.CellPhone,
                Adress = owner.Adress,
                ImageUrl = owner.ImageUrl,
                User = owner.User
            };
        }
    }
}
