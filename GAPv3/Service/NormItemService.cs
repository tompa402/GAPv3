using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GAPv3.DAL;
using GAPv3.Models;
using System.Data.Entity;
using AutoMapper;
using GAPv3.ViewModels;

namespace GAPv3.Service
{
    public class NormItemService
    {
        private readonly GAPv3Context _context;

        public NormItemService(GAPv3Context context)
        {
            _context = context;
        }

        public List<NormItemViewModel> GetNormItems(int normId, int? parentId)
        {
            var normItems = _context.NormItems.Include(n => n.Norm).Include(n => n.Parent).Where(n => n.NormId == normId && n.ParentId == parentId).ToList();
            var normItemList = Mapper.Map<List<NormItem>, List<NormItemViewModel>>(normItems);
            foreach (var item in normItemList)
            {
                if (item.Parent == null)
                {
                    item.Level = "1";
                    item.Target = "#cardChild";
                }
                else if (item.Parent.Parent == null)
                {
                    item.Level = "2";
                    item.Target = "#cardItem";
                }
                else
                {
                    item.Level = "3";
                }
            }
            return normItemList;
        }

        public NormItemFormViewModel CreateNormItem(int normId, int? parentId)
        {
            var norm = _context.Norms.SingleOrDefault(x => x.NormId == normId);
            var parent = _context.NormItems.SingleOrDefault(x => x.NormItemId == parentId);
            var model = new NormItemFormViewModel(normId, parentId)
            {
                NormName = norm?.Name,
                ParentName = parent == null ? "Ovaj zahtjev nema nadređeni zahtjev/klauzulu" : parent.Name
            };
            return model;
        }

        public NormItem GetNormItemById(int id)
        {
            return _context.NormItems.SingleOrDefault(n => n.NormItemId == id);
        }

        public NormItemFormViewModel EditViewModel(NormItem norm)
        {
            var model = Mapper.Map <NormItem, NormItemFormViewModel> (norm);
            return model;
        }

        public void SaveNormItem(NormItemFormViewModel model)
        {
            _context.NormItems.Add(Mapper.Map<NormItemFormViewModel, NormItem>(model));
            _context.SaveChanges();
        }

        public void UpdateNormItem(NormItemFormViewModel model)
        {
            var norm = _context.NormItems.SingleOrDefault(n => n.NormItemId == model.NormItemId);
            if (norm != null)
            {
                norm.Name = model.Name;
                norm.Order = model.Order;
                norm.IsItem = model.IsItem;
            }
            _context.SaveChanges();
        }
    }
}