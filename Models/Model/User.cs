using Microsoft.AspNetCore.Identity;
using Models.Entitys;
using Models.Enum;

namespace Models.Model
{
    public class User : IdentityUser,IEntityModels
    {
        public virtual required string FirstName { get; set; }
        public virtual required string LastName { get; set; }
        public override string Id { get => base.Id; set => base.Id = value; }
        public bool IsActive { get; set; } = true;
        public UserRole Role { get; set; }
        public string? CategorieId { get; set; }
        public Categorie? categorie { get; set; }

    }
}
