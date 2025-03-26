using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraStractur.Data;
using InfraStractur.Repository.RepositoryModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
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
            var httpContext = context.Resource as HttpContext;
            var routeData = httpContext?.GetRouteData();
            Console.WriteLine(routeData);
            // الحصول على الـ id من الراوت
            var categorieId = routeData?.Values["id"]?.ToString();
           

            var user = await _userManager.GetUserAsync(context.User);
           
            if (user == null)
            {
                return;
            }
            Console.WriteLine($"User CategorieId: {user.CategorieId}");

            if (user.CategorieId== categorieId)
            {
                context.Succeed(requirement);
                return;
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
