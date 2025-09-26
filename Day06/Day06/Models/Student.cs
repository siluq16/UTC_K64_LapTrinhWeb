using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Day06.Models
{
    public class Student
    {
        public int Id { get; set; } 

        [Required(ErrorMessage = "Họ tên bắt buộc phải nhập")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Họ tên phải từ 4 đến 100 ký tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email bắt buộc phải nhập")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@gmail\.com$", ErrorMessage = "Email phải có đuôi @gmail.com")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mật khẩu bắt buộc phải nhập")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Mật khẩu phải từ 8 ký tự trở lên")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).+$",
            ErrorMessage = "Mật khẩu phải có chữ hoa, chữ thường, số và ký tự đặc biệt")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Ngành học bắt buộc phải chọn")]
        public Branch Branch { get; set; } 

        [Required(ErrorMessage = "Giới tính bắt buộc phải chọn")]
        public Gender Gender { get; set; }

        public bool IsRegular { get; set; } 

        [Required(ErrorMessage = "Địa chỉ bắt buộc phải nhập")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Range(typeof(DateTime), "01/01/1963", "31/12/2005",
    ErrorMessage = "Ngày sinh phải từ 01/01/1963 đến 31/12/2005")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }


        [Required(ErrorMessage = "Điểm bắt buộc phải nhập")]
        [Range(0.0, 10.0, ErrorMessage = "Điểm phải từ 0.0 đến 10.0")]
        public double Diem { get; set; } 
    }

    public enum Branch
    {
        IT, BE, CE, EE
    }

    public enum Gender
    {
        Nam, Nu, Khac
    }
}
