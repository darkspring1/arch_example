using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Persistent.State
{
    public class UserState
    {
        public Guid Id { get; set; }

        [MaxLength(1024)]
        public string PasswordHash { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }


        public DateTime CreatedAt { get; set; }
    }
}
