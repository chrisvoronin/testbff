using System;
namespace AuthServices.Models
{
    public class LoginRequest
    {
        public LoginRequest()
        {
        }

        public string userName
        {
            get;
            set;
        }

        public string password
        {
            get;
            set;
        }
    }
}
