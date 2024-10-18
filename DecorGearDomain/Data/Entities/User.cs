using DecorGearDomain.Data.Base;
using DecorGearDomain.Enum;
using System.ComponentModel.DataAnnotations;



namespace DecorGearDomain.Data.Entities
{
    public class User : EntityBase
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
  
      
        [Required]
        public int RoleID { get; set; }
        
       // public string RoleName { get; set; }    

        public string? RefreshToken { get; set; }
        public UserStatus Status { get; set; }
       
        // Khóa ngoại

        // 1 - n
        public virtual ICollection<Favorite>? Favorites { get; set; }
        public virtual ICollection<FeedBack>? FeedBacks { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        // 1 - 1
        public virtual Cart Cart { get; set; }
        public virtual Member Member { get; set; }

        // n - 1
        public virtual Role Role { get; set; }

       
    }
}
