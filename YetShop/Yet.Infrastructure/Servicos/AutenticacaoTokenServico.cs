using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Yet.Core.Constantes;
using Yet.Core.Interfaces;
using Yet.Infrastructure.Identity;

namespace Yet.Infrastructure.Servicos
{
    public class AutenticacaoTokenServico : ITokenServico
    {
        #region Campos
        private readonly UserManager<UsuarioApp> _userManager;
        #endregion

        #region Ctor
        public AutenticacaoTokenServico(UserManager<UsuarioApp> userManager)
        {
            _userManager = userManager;
        }
        #endregion

        #region Métodos
        public async Task<string> ObterTokenAsync(string userName)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Autenticacao.SECRET_KEY);
            var user = await _userManager.FindByNameAsync(userName);
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, userName) };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims.ToArray()),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        #endregion
    }
}
