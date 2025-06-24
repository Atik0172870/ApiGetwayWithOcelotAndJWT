using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Writer.Models
{
    public class Writer
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
