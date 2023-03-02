using System.ComponentModel.DataAnnotations;

namespace GraphQLPractice.Models
{
    public class CreateGadgetDTO
    {
        [Required]
        public string Name { get; set; }

        public string Brand { get; set; } = null;

        public decimal Price { get; set; } = 0;

        [Required]
        public string Type { get; set; }
    }

    public class GadgetDTO : CreateGadgetDTO 
    {
        public int Id { get; set; }
    }
}
