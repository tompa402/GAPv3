using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GAPv3.DAL;

namespace GAPv3.Service
{
    public class NormItemService
    {
        private readonly GAPv3Context _context;

        public NormItemService(GAPv3Context context)
        {
            _context = context;
        }
    }
}