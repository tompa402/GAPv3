using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using GAPv3.DAL;
using GAPv3.Handlers;
using GAPv3.Helpers;
using GAPv3.Models;

namespace GAPv3.Service
{
    public class UserService
    {
        private DbContext _context;

        public void SaveUser(User user)
        {
            using (GAPv3Context _context = new GAPv3Context())
            {
                //TODO: provjera je li user postoji.
                user.Password = PasswordHandler.EncryptPassword(CredentialsManager.GetDefaultPass(user.Email));
                _context.Users.Add(user);
                _context.SaveChanges();
            }
        }

        public IEnumerable<User> GetUsers()
        {
            using (GAPv3Context _context = new GAPv3Context())
            {
                return _context.Users.ToList();
            }
        }

        public void DeactivateUser(int id)
        {
            using (GAPv3Context _context = new GAPv3Context())
            {
                var existingUser = _context.Users.SingleOrDefault(u => u.UserId == id);
                if (existingUser != null)
                {
                    if (existingUser.IsActive)
                    {
                        existingUser.IsActive = false;
                    }
                    else
                    {
                        existingUser.IsActive = true;
                    } 
                    _context.SaveChanges();
                }
            }
        }

        public User DetailsUser(int? id)
        {
            using (GAPv3Context _context = new GAPv3Context())
            {
                User user = _context.Users.SingleOrDefault(u => u.UserId == id);
                return user;

            }
        }

        public User Update(int id)
        {
            using (GAPv3Context _context = new GAPv3Context())
            {
                User user = _context.Users.SingleOrDefault(u => u.UserId == id);
                return user;
            }
        }
        public User UpdateUser(User user)
        {
            using (GAPv3Context _context = new GAPv3Context())
            {
                var existingUser = _context.Users.SingleOrDefault(u => u.UserId == user.UserId);
                if (existingUser != null)
                {
                    existingUser.Email = user.Email;
                    existingUser.Name = user.Name;
                    existingUser.LastName = user.LastName;
                    existingUser.JMBAG = user.JMBAG;
                    existingUser.Modified=DateTime.Now;
                    _context.SaveChanges();
                }

                return user;
            }
        }
        public void UpdatePass(User user)
        {
            
            using (GAPv3Context _context = new GAPv3Context())
            {
                User existingUser = _context.Users.SingleOrDefault(u => u.Email == user.Email);
                if (existingUser != null)
                {
                    existingUser.Password = PasswordHandler.EncryptPassword(user.Password);
                    existingUser.Modified = DateTime.Now;
                    _context.SaveChanges();

                }
            }
        }
    }
}