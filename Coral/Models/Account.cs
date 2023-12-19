using System.ComponentModel.DataAnnotations;

namespace Coral.Models {
    public class Account {
        public int Id { get; set; }

        [Display(Name = "用户名 *", Order = 10)]
        [Required(ErrorMessage = "用户名必须的")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "用户名5-20")]
        public required string UserName { get; set; }

        [StringLength(50, MinimumLength = 8)]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Display(Name = "电话", Order = 30)]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20)]
        public string? Phone { get; set; }

        [Display(Name = "邮箱", Order = 40)]
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        public string? Email { get; set; }

        [Display(Name = "邀请人", Order = 50)]
        [StringLength(20)]
        public string? Inviter { get; set; }

        [Display(Name = "注册日期", Order = 60)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreationTime { get; set; }

        [Display(Name = "备注", Order = 70)]
        [StringLength(500)]
        public string? Note { get; set; }

        [StringLength(32)]
        public required string Salt { get; set; }
    }

}
