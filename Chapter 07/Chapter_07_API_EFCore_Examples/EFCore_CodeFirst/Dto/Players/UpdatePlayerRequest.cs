using System.ComponentModel.DataAnnotations;

namespace EFCore_CodeFirst.Dto.Players
{
    public class UpdatePlayerRequest
    {
        [Required]
        public string NickName { get; set; }
    }
}
