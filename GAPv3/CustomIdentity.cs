using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using GAPv3.Models;

namespace GAPv3
{
    public class CustomIdentity : IIdentity
    {
        public IIdentity Identity { get; set; }
        public User User { get; set; }
        public CustomIdentity(User user)
        {
            Identity = new GenericIdentity(user.Email);
            User = user;
        }
        public string AuthenticationType
        {
            get { return Identity.AuthenticationType; }
        }
        public bool IsAuthenticated
        {
            get { return Identity.IsAuthenticated; }
        }
        public string Name
        {
            get { return Identity.Name; }
        }
    }
}