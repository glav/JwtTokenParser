using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Linq;

namespace JwtTokenParser
{
    internal class TokenParser
    {
        private JwtSecurityToken _token;

        public TokenParseResult SetToken(string token)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                _token = handler.ReadJwtToken(token);

                return new TokenParseResult(_token);

            }
            catch (Exception ex)
            {
                return new TokenParseResult($"Error in parsing token: {ex.Message}");
            }
        }

    }
}
