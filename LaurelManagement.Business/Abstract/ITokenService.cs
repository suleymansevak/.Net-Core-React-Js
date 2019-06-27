using LaurelManagement.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaurelManagement.Business.Abstract
{
   public interface ITokenService
    {
        string GenerateToken(User entity );
    }
}
