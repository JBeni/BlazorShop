// <copyright file="JwtTokenParser.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Auth
{
    /// <summary>
    /// A service to parse claims from the generated token.
    /// </summary>
    public static class JwtTokenParser
    {
        /// <summary>
        /// Taking the claims from the token.
        /// </summary>
        /// <param name="jwt">The token.</param>
        /// <returns>The user claims list.</returns>
        public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            ExtractRolesFromJWT(claims, keyValuePairs);
            claims.AddRange(keyValuePairs.Select(keyValue => new Claim(keyValue.Key, keyValue.Value.ToString())));

            return claims;
        }

        /// <summary>
        /// Extracts the roles from the JWT token.
        /// </summary>
        /// <param name="claims">The list of user claims.</param>
        /// <param name="keyValuePairs">The dictionary.</param>
        private static void ExtractRolesFromJWT(List<Claim> claims, Dictionary<string, object> keyValuePairs)
        {
            keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);
            if (roles is not null)
            {
                var parsedRoles = roles.ToString().Trim().TrimStart('[').TrimEnd(']').Split(',');

                if (parsedRoles.Length > 1)
                {
                    foreach (var parsedRole in parsedRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, parsedRole.Trim('"')));
                    }
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, parsedRoles[0]));
                }

                keyValuePairs.Remove(ClaimTypes.Role);
            }
        }

        /// <summary>
        /// Checking the base64 string nad fix it in case of missing the padding.
        /// </summary>
        /// <param name="base64">The base64 value.</param>
        /// <returns>The completed base64 string.</returns>
        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2:
                    base64 += "==";
                    break;
                case 3:
                    base64 += "=";
                    break;
            }

            return Convert.FromBase64String(base64);
        }
    }
}
