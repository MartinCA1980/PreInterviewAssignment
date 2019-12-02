using Data;
using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using Model;
using Repository;
using Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Service
{
    public interface IJwtTokenService
    {



        JWTToken GenerateToken(CustomerModel customer);
      
    }
}
