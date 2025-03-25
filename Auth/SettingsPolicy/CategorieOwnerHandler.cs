using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraStractur.Data;
using InfraStractur.Repository.RepositoryModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.Model;

namespace Auth.SettingsPolicy
{
    public class CategorieOwnerHandler : AuthorizationHandler<CategorieOwnerRequirement>
    {
        private readonly UserManager<User> _userManager;
        private readonly CategorieRepository categorieRepository;
        private readonly ConnectDataBase c;

        public CategorieOwnerHandler(
            UserManager<User> userManager,
            CategorieRepository categorieRepository,
            ConnectDataBase c
            )
        {
            Console.WriteLine();
            _userManager = userManager;
            this.categorieRepository = categorieRepository;
            this.c = c;
        }

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            CategorieOwnerRequirement requirement
            )
        {
            var user = await _userManager.GetUserAsync(context.User);
            var getListWithUsers = await c.categories.
                Include(u => u.users)
                .FirstOrDefaultAsync(x => x.Id == user.CategorieId);
          
            if (user == null)
            {
                return;
            }
            Console.WriteLine($"User CategorieId: {user.CategorieId}");



            foreach (var ee in getListWithUsers.users)
            {
                    if (user.CategorieId == ee.CategorieId)
                    {
                        context.Succeed(requirement);
                        return;
                    }
            }
           

            // السماح إذا كان المستخدم أدمن
            if (await _userManager.IsInRoleAsync(user, "Admin"))
            {
                context.Succeed(requirement);
                return;
            }
        }
    }

}
