using System.ComponentModel.DataAnnotations;

namespace Day13Lab_Lab3.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Họ tên bắt buộc phải nhập")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Họ tên phải từ 4 đến 100 ký tự")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Email bắt buộc phải nhập")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@gmail\.com$",
        ErrorMessage = "Email phải có đuôi gmail.com")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Mật khẩu bắt buộc phải nhập")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$",
        ErrorMessage = "Mật khẩu phải từ 8 ký tự, bao gồm chữ hoa, chữ thường, số và ký tự đặc biệt")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Ngành học bắt buộc phải chọn")]
        public Branch? Branch { get; set; }
        [Required(ErrorMessage = "Giới tính bắt buộc phải chọn")]
        public Gender? Gender { get; set; }
        public bool IsRegular { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        public string? Address { get; set; }
        [Required(ErrorMessage = "Ngày sinh bắt buộc phải nhập")]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "1963-01-01", "2005-12-31",
        ErrorMessage = "Ngày sinh phải từ năm 1963 đến 2005")]
        public DateTime DateOfBorth { get; set; }
        public IFormFile? Avatar { get; set; }
        public string? ImagePath { get; set; }
    }
}
