using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using yet.Infrastructure.Identity;
using Yet.Core.Constantes;

namespace Yet.Infrastructure.Identity
{
    /// <summary>
    /// Cria o usuário administrador do sistema
    /// </summary>
    public class AppIdentityDbContextSeed
    {
        /// <summary>
        /// Cria o perfil administrador padrão 
        /// Cria o usuário administrativo
        /// </summary>
        /// <param name="userManager">Objeto responsável por manipular o usuário</param>
        /// <param name="roleManager">Objeto responsável por manipular o perfil do usuário</param>
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //. . Cria o perdil administrador padrão
            await roleManager.CreateAsync(new IdentityRole(Autenticacao.PERFIL_ADMINISTRADOR));

            //. .  Cria o novo usuário admin
            var adminUser = new ApplicationUser { UserName = Autenticacao.USUARIO_ADMINISTRADOR, Email = Autenticacao.EMAIL_ADMINISTRADOR };
            await userManager.CreateAsync(adminUser, Autenticacao.SENHA_PADRAO);

            //. . Adiciona o perfil administrador ao novo usuário
            adminUser = await userManager.FindByNameAsync(Autenticacao.USUARIO_ADMINISTRADOR);
            await userManager.AddToRoleAsync(adminUser, Autenticacao.PERFIL_ADMINISTRADOR);
        }
    }
}
