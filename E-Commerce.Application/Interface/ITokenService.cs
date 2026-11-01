using E_Commerce.Domian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Interface
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
