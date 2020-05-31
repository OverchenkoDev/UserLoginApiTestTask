using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UserLoginApi.Models
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public bool Activated { get; set; }
        public int? UserData { get; set; }
        [ForeignKey("UserData")]
        [JsonIgnore]
        public virtual UserNotes IdNavigation { get; set; }
        
    }
}
