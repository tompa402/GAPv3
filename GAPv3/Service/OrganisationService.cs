using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GAPv3.DAL;
using GAPv3.Models;
using GAPv3.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace GAPv3.Service
{
    public class OrganisationService
    {
        private GAPv3Context _context;

        public OrganisationService(GAPv3Context context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetUsersWithoutOrganisation()
        {
            var users = _context.Users
                .Where(c => c.OrganisationId == null)
                .Select(x =>
                    new SelectListItem
                    {
                        Value = x.UserId.ToString(),
                        Text = x.Name + " " + x.LastName
                    });
            return new SelectList(users, "Value", "Text");
        }

        public IEnumerable<SelectListItem> GetUsersForEdit(int orgId)
        {
            var users = _context.Users
                .Where(c => c.OrganisationId == null || c.OrganisationId == orgId)
                .Select(x =>
                    new SelectListItem
                    {
                        Value = x.UserId.ToString(),
                        Text = x.Name + " " + x.LastName
                    });
            return new SelectList(users, "Value", "Text");
        }

        public IEnumerable<Organisation> GetOrganisations()
        {
            return _context.Organisations.Include(u => u.Users).ToList();
        }

        public Organisation GetOrganisationById(int id)
        {
            return _context.Organisations.Include(c => c.Users).SingleOrDefault(c => c.OrganisationId == id);
        }

        public UserOrganisationViewModel CreateViewModel()
        {
            UserOrganisationViewModel model = new UserOrganisationViewModel
            {
                Organisation = new Organisation(),
                Users = GetUsersWithoutOrganisation()
            };
            return model;
        }

        public UserOrganisationViewModel EditViewModel(Organisation organisation)
        {
            UserOrganisationViewModel model = new UserOrganisationViewModel
            {
                Organisation = organisation,
                Users = GetUsersForEdit(organisation.OrganisationId),
                SelectedUsers = _context.Users
                    .Where(c => c.OrganisationId == organisation.OrganisationId)
                    .Select(c => c.UserId)
                    .ToList()
            };
            return model;
        }

        public void SaveUserOrganisation(UserOrganisationViewModel model)
        {
            _context.Organisations.Add(model.Organisation);

            foreach (var usrId in model.SelectedUsers)
            {
                var userInDb = _context.Users.SingleOrDefault(c => c.UserId == usrId);
                if (userInDb != null)
                    userInDb.OrganisationId = model.Organisation.OrganisationId;
            }
            _context.SaveChanges();
        }

        public void UpdateUserOrganisation(UserOrganisationViewModel model)
        {
            model.Organisation.Modified = DateTime.Now;
            _context.Organisations.AddOrUpdate(model.Organisation);

            var oldUsers = _context.Users
                .Where(c => c.OrganisationId == model.Organisation.OrganisationId)
                .Select(c => c.UserId)
                .ToList();

            var newUsers = model.SelectedUsers.Except(oldUsers).ToList();

            var usersToRemoveOrg = oldUsers.Except(model.SelectedUsers).ToList();

            foreach (var usrId in newUsers)
            {
                var userInDb = _context.Users.SingleOrDefault(c => c.UserId == usrId);
                if (userInDb != null)
                    userInDb.OrganisationId = model.Organisation.OrganisationId;
            }

            foreach (var usrId in usersToRemoveOrg)
            {
                var userInDb = _context.Users.SingleOrDefault(c => c.UserId == usrId);
                if (userInDb != null)
                    userInDb.OrganisationId = null;
            }
            _context.SaveChanges();
        }

        //TODO: implement activate/deactivate module
    }
}