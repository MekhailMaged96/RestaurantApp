using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApi.Controllers
{

    public class BaseController : ControllerBase
    {
        protected int GetUserId()
        {
            IList<Claim> claims = GetTokenClaims();

            return Convert.ToInt32(claims[0].Value);
        }

        private IList<Claim> GetTokenClaims()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            IList<Claim> claims = identity.Claims.ToList();
            return claims;
        }
    }
}
