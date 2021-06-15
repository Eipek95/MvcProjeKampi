using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IDraftService
    {
        List<Draft> GetList();
        void DraftAddBL(Draft contact);
        Draft GetByID(int id);
        void DraftDelete(Draft contact);
        void DraftUpdate(Draft contact);
    }
}
