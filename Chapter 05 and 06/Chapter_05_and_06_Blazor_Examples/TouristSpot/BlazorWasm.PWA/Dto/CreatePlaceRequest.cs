using System.ComponentModel.DataAnnotations;

namespace BlazorWasm.PWA.Dto
{
    public class CreatePlaceRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string About { get; set; }
        [Required]
        public int Reviews { get; set; }
        public string ImageData { get; set; }
    }
}
