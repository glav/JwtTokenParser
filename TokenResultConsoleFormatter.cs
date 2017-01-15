using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JwtTokenParser
{
    internal class TokenResultConsoleFormatter
    {
        public void WriteToConsole(TokenParseResult parseResult)
        {
            Console.WriteLine("Token Information");
            Console.WriteLine("Expiry Information: {0}", parseResult.ExpiryInformation);
            Console.WriteLine("> Is token valid?: {0}", parseResult.IsValid);
            if (!parseResult.IsValid)
            {
                Console.WriteLine("> Token invalid reason: {0}", parseResult.ErrorMessage);
            }
            Console.WriteLine("> Issuer: ", parseResult.Issuer);
            Console.WriteLine("> Audience List:");
            parseResult.AudienceList.ToList().ForEach(a => Console.WriteLine("\t>> {0}", a));
            Console.WriteLine("> Claims:");
            parseResult.Claims.ToList().ForEach(c => Console.WriteLine("\t>> Type:[{0}], Value: [{1}]", c.Type, c.Value));
            Console.WriteLine();


        }
    }
}
