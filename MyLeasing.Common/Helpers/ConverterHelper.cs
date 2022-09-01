
using MyLeasing.Web.Data.Ententies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLeasing.Common.Data.Models;
using MyLeasing.Common.Data.Ententies;

namespace MyLeasing.Common.Helpers
{
    public class ConverterHelper : IConverterHelper
    {

        public Owner toOwner(OwnerViewModel model,  Guid imageId, bool isNew)
        {
            return new Owner
            {

                Document = model.Document,
                FirstName = model.FirstName,
                LastName = model.LastName,
                FixedPhone = model.FixedPhone,
                CellPhone = model.CellPhone,
                Adress = model.Adress,
                ImageId = imageId,
                User = model.User

            };
        }

        public Lessee toLessee(LesseeViewModel model, Guid imageId, bool isNew)
        {
            return new Lessee
            {

                Document = model.Document,
                FirstName = model.FirstName,
                LastName = model.LastName,
                FixedPhone = model.FixedPhone,
                CellPhone = model.CellPhone,
                Adress = model.Adress,
                ImageId = imageId,
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
                ImageId = owner.ImageId,
                User = owner.User
            };
        }

        public LesseeViewModel toLesseeViewModel(Lessee lessee)
        {
            return new LesseeViewModel
            {
                Document = lessee.Document,
                FirstName = lessee.FirstName,
                LastName = lessee.LastName,
                FixedPhone = lessee.FixedPhone,
                CellPhone = lessee.CellPhone,
                Adress = lessee.Adress,
                ImageId = lessee.ImageId,
                User = lessee.User
            };
        }
    }
}
