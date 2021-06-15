using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DraftManager : IDraftService
    {
        IDraftDal _DraftDal;

        public DraftManager(IDraftDal draftDal)
        {
            _DraftDal = draftDal;
        }

        public void DraftAddBL(Draft draft)
        {
            _DraftDal.Insert(draft);
        }

        public void DraftDelete(Draft draft)
        {
            _DraftDal.Delete(draft);
        }

        public void DraftUpdate(Draft draft)
        {
            _DraftDal.Update(draft);
        }

        public Draft GetByID(int id)
        {
            return _DraftDal.Get(x => x.ID== id);
        }

        public List<Draft> GetList()
        {
            return _DraftDal.List();
        }
    }
}
