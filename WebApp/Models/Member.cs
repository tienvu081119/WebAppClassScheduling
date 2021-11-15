using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    [Table("Member")]
    public class Member
    {
        [Column("MemberId")]

        public string Id { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }

        public string Email { get; set; }

        public bool Gender { get; set; }
        public string Token { get; set; }

    }
}
