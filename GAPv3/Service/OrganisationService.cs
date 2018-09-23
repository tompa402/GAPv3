using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GAPv3.DAL;
using GAPv3.Models;
using GAPv3.ViewModels;

namespace GAPv3.Service
{
    public class OrganisationService
    {
        private UnitOfWork unitOfWork;

        public OrganisationService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<SelectListItem> GetUser()
        {
            var users = unitOfWork.UserRepository.Get()
                .Select(x =>
                    new SelectListItem
                    {
                        Value = x.UserId.ToString(),
                        Text = x.Name + " " + x.LastName
                    });
            return new SelectList(users, "Value", "Text");
        }

        public void SaveUserOrganisation(UserOrganisationViewModel model)
        {
            unitOfWork.OrganisationRepository.Insert(model.Organisation);
            int organisationId = model.Organisation.OrganisationId;

            foreach (int id in model.SelectedUsers)
            {
                var UserOrganisation = new UserOrganisation
                {
                    OrganisationId = organisationId,
                    UserId = id
                };
                unitOfWork.UserOrganisationRepository.Insert(UserOrganisation);
            }

            unitOfWork.Save();
        }

        public IEnumerable<Organisation> GetOrganisations()
        {
            return unitOfWork.OrganisationRepository.Get();
        }
    }
}