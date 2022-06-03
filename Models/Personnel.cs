using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLNS
{
    public class Users
    {
        public int Id { get; set; }

        [MaxLength(300)]
        [Required]
        public string FullName { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }


        public byte Status { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Sex { get; set; }

        [Required]
        public string BirthOfDate { get; set; }

        [Required]
        public string Avartar { get; set; }
        public string Descripion { get; set; }     //mô tả

        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<SalaryHistory> Salary { get; set; }
        public virtual ICollection<LeaveApplication> LApp { get; set; }
    }
    public class SalaryHistory  //Lịch sử tiền lương
    {
        public int Id { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public string ApplyDate { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public double Salary { get; set; }  //lương
        [Required]
        public double Allowance { get; set; }  //phụ cấp
        [Required]
        public string Reason { get; set; }  // lý do

        [ForeignKey("UserId")]
        public virtual Users User { get; set; }
    }
    public class Review  // đánh giá
    {
        public int Id { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int Rate { get; set; }  //sao
        [Required]
        public string Content { get; set; } //nội dung

        [ForeignKey("UserId")]
        public virtual Users User { get; set; }
    }
    public class LeaveApplication // 
    {
        public int Id { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string Reason { get; set; }
        public byte Status { get; set; }

        [ForeignKey("UserId")]
        public virtual Users User { get; set; }
    }
    public class Roles  // vai trò, chức vụ
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(300)]
        public string Name { get; set; }  //tên chức vụ
        [Required]
        public DateTime CreatedDate { get; set; }
        public byte Status { get; set; } //trạng thái, chú thích
        [Required]
        public int DepartmentId { get; set; } // thuộc bộ phận nào

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
    }
    public class UserRoles  //bảng n n
    {
        [Key]
        public int UserId { get; set; }
        [Key]
        public int RoleId { get; set; }

        [ForeignKey("UserId")]
        public virtual Users User { get; set; }

        [ForeignKey("RoleId")]
        public virtual Roles Role { get; set; }

    }
    public class Department //bộ phận
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }  //tên bộ phận
        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public string Description { get; set; }  //loại bộ phận
        public byte Status { get; set; }
    }
    public class RoleClaims  //chi tiết vai trò
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        public string ClaimType { get; set; }
        [Required]
        public string ClaimValue { get; set; }

        [ForeignKey("RoleId")]
        public virtual Roles Role { get; set; }

    }
    public class Profile
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime SignDate { get; set; }
        [MaxLength(300)]
        public string Content { get; set; }
    }
    public class ProfileAttachment
    {
        [Key]
        public int ProfileId { get; set; }
        [Key]
        public int AttachmentId { get; set; }

        [ForeignKey("ProfileId")]
        public virtual Profile Profile { get; set; }
        [ForeignKey("AttachmentId")]
        public virtual Attachment Attachment { get; set; }
    }
    public class Attachment // tập tin
    {
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int Size { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public string Ext { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}