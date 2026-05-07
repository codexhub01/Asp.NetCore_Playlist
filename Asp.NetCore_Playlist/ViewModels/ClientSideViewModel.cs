using System.ComponentModel.DataAnnotations;

namespace Asp.NetCore_Playlist.ViewModels
{
    public class ClientSideViewModel
    {
        [Required(ErrorMessage ="Enter a mail")]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
