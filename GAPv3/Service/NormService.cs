using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using AutoMapper;
using GAPv3.DAL;
using GAPv3.Models;
using GAPv3.ViewModels;

namespace GAPv3.Service
{
    public class NormService
    {
        private readonly GAPv3Context _context;

        public NormService(GAPv3Context context)
        {
            _context = context;
        }

        public Norm GetNormById(int id)
        {
            return _context.Norms.SingleOrDefault(n => n.NormId == id);
        }

        public List<NormViewModel> GetNormList()
        {
            var norms = _context.Norms.ToList();
            var normViewModels = new List<NormViewModel>();
            foreach (var norm in norms)
            {
                var additionalItems = _context.ReportValueAdditionalItems.SingleOrDefault(x => x.NormId == norm.NormId);
                var haveAdditionalItems = additionalItems != null && (additionalItems.HaveControl && additionalItems.HaveReason);
                if (norm.Description.Length > 64)
                    norm.Description = norm.Description.Substring(0, 63) + "...";
                normViewModels.Add(new NormViewModel { Name = norm.Name, NormId = norm.NormId, Description = norm.Description, HaveAdditionalItems = haveAdditionalItems });
            }
            return normViewModels;
        }

        public NormViewModel CreateViewModel()
        {
            var normViewModel = new NormViewModel();
            return normViewModel;
        }

        public NormViewModel EditViewModel(Norm norm)
        {
            var model = Mapper.Map<Norm, NormViewModel>(norm);
            var additionalItems = _context.ReportValueAdditionalItems.SingleOrDefault(x => x.NormId == norm.NormId);
            var haveAdditionalItems = additionalItems != null && (additionalItems.HaveControl && additionalItems.HaveReason);
            model.HaveAdditionalItems = haveAdditionalItems;
            return model;
        }

        public void SaveNorm(NormViewModel model)
        {
            var norm = Mapper.Map<NormViewModel, Norm>(model);
            _context.Norms.Add(norm);

            if (model.HaveAdditionalItems)
                _context.ReportValueAdditionalItems.Add(new ReportValueAdditionalItem { HaveControl = true, HaveReason = true });

            _context.SaveChanges();
        }

        public void UpdateNorm(NormViewModel model)
        {
            // TODO: refactor AddOrUpdate because that method is used only for migrations.
            // TODO: Implement update of additional items.
            var norm = Mapper.Map<NormViewModel, Norm>(model);
            _context.Norms.AddOrUpdate(norm);
            _context.SaveChanges();
        }

    }
}