using MyLeasing.Common.Data.Ententies;
using MyLeasing.Common.Data.Models;
using MyLeasing.Web.Data.Ententies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeasing.Common.Helpers
{
    public interface IConverterHelper
    {
        public Owner toOwner(OwnerViewModel model, Guid imageId, bool isNew);

        public Lessee toLessee(LesseeViewModel model, Guid imageId, bool isNew);

        public OwnerViewModel toOwnerViewModel(Owner owner);

        public LesseeViewModel toLesseeViewModel(Lessee lessee);
    }
}
