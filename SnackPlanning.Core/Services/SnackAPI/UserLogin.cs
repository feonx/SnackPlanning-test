using System;
namespace SnackPlanning.Core.Services.SnackAPI
{
    public class UserLogin
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string IPaddress { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
