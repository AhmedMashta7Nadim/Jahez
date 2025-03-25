namespace Models.DTO
{
    public class CategorieDTO
    {
        public required string NameCategorie { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public int? Quantity { get; set; }
        public required string departmintId { get; set; }
    }
}

