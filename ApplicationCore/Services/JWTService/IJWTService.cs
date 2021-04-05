using Domain.Aggregates.UserAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Services.JWTService
{
    public interface IJWTService
    {
        public string GenerateJWTToken(User user);

    }
}
