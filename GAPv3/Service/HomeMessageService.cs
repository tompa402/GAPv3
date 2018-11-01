using GAPv3.DAL;
using GAPv3.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GAPv3.Service
{
    public class HomeMessageService
    {
        private GAPv3Context _context;

        public HomeMessageService(GAPv3Context context)
        {
            _context = context;
        }

        public HomeMessage GetById(int id)
        {
            return _context.HomeMessages.SingleOrDefault(m => m.HomeMessageId == id);
        }

        public List<HomeMessage> GetMessages()
        {
            return _context.HomeMessages.ToList();
        }

        public void AddMessage(HomeMessage message)
        {
            _context.HomeMessages.Add(message);
            // TODO: assign value CreatedBy
            _context.SaveChanges();
        }
        public void UpdateMessage(HomeMessage message)
        {
            var homeMessageInDb = _context.HomeMessages.Single(m => m.HomeMessageId == message.HomeMessageId);
            homeMessageInDb.Title = message.Title;
            homeMessageInDb.Message = message.Message;
            // TODO: assign value ModifiedBy
            homeMessageInDb.Modified = DateTime.Now;
            _context.SaveChanges();
        }

        public void DeactivateSingleHomeMessage(int msgId)
        {
            var homeMessageInDb = _context.HomeMessages.Single(m => m.HomeMessageId == msgId);
            homeMessageInDb.IsActive = !homeMessageInDb.IsActive;
            // TODO: assign value ModifiedBy
            homeMessageInDb.Modified = DateTime.Now;
            _context.SaveChanges();
        }
    }
}