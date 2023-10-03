using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfiesAWookies.Core.Framework
{
    public interface IUnitOfWork
    {
        int SaveChanges();// Pour réaliser des enregistrements, cela nous permettra d'amorcer la prochaine quête qui est
                          // autour de l'ajout d'un SelfieAWookies
    }
}
