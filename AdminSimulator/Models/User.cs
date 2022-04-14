using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminSimulator.Models
{
    public class User
    {
        public int UserId { get; set; }
        public String UserName { get; set; }
        public String UserEmail { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastActiveDate { get; set; }
        public String UserStatus { get; set; }
        public User() { }
        public User(String userName, String userEmail, DateTime registerDate, DateTime lastActiveDate, String userStatus)
        {
            this.UserName = userName;
            this.UserEmail = userEmail;
            this.RegisterDate = registerDate;
            this.LastActiveDate = lastActiveDate;
            this.UserStatus = userStatus;
        }
    }
}
