using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace UserLoginApi.Models
{
    public partial class UserNotes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public double? Amount { get; set; }
        [JsonIgnore]
        public virtual Users Users { get; set; }
    }
}
