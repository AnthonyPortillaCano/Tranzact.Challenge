using Challenge.External.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.External.Interfaces
{
    public interface IExternalProxy
    {
        ExternalProduct GetExternalProductById(int productId);
    }
}
