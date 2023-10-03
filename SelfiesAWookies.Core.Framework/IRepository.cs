using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfiesAWookies.Core.Framework
{
    /// <summary>
    /// Use it to define class is a repository
    /// </summary>
    public interface IRepository //Tout ce qui est Repository sera implémenté
    {
        IUnitOfWork UnitOfWork { get; } // On veut juste qu'elle renvoit des données 
    }
}
