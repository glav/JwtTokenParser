using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Linq;

namespace JwtTokenParser
{
    internal class TokenParseResult
    {
        private List<Claim> _claims = new List<Claim>();

        public TokenParseResult(string errorMessage)
        {
            IsValid = false;
            ErrorMessage = errorMessage;

        }

        public TokenParseResult(JwtSecurityToken token)
        {
            Issuer = token.Issuer;
            AudienceList = token.Audiences;
            Claims = token.Claims;
            ConstructExpiryInformation(token);

            if (token.ValidFrom >= DateTime.UtcNow && token.ValidTo <= DateTime.UtcNow)
            {
                IsValid = true;
            }
            else
            {
                IsValid = false;
                ErrorMessage = $"Token has expired. {ExpiryInformation}";
            }
        }
        public bool IsValid { get; private set; }

        public string ErrorMessage { get; private set; }

        public string Issuer { get; private set; }
        public IEnumerable<string> AudienceList { get; private set; }

        public string ExpiryInformation { get; private set; }


        public IEnumerable<Claim> Claims { get; }

        private void ConstructExpiryInformation(JwtSecurityToken token)
        {
            ExpiryInformation = $"Token is valid only from {token.ValidFrom.ToLocalTime().ToString("yyyy-MM-dd hh:mm:ss")} to {token.ValidTo.ToLocalTime().ToString("yyyy-MM-dd hh:mm:ss")} (local time)";
        }

    }
}
