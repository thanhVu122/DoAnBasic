using System.ComponentModel.DataAnnotations;

namespace Bai_ThucHanh.Models
{
    public class User
    {
        [Key]
    public int Id { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập lại tài khoản.")]
        public string? Name { get; set; }
        public string? Email { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập lại mật khẩu.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public string? Role { get; set; }
    }
}
