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
    public class AdminRecordManager : IAdminRecordService
    {
        IAdminRecordDal _adminRecordDal;

        public AdminRecordManager(IAdminRecordDal aboutDal)
        {
            _adminRecordDal = aboutDal;
        }

        public void AdminAddBL(Admin admin)
        {
            _adminRecordDal.Insert(admin);
        }

        public void AdminDelete(Admin admin)
        {
            throw new NotImplementedException();
        }

        public void AdminUpdate(Admin admin)
        {
            _adminRecordDal.Update(admin);
        }

        public Admin GetByID(int id)
        {
            return _adminRecordDal.Get(X=>X.AdminID==id);
        }

        public List<Admin> GetList()
        {
            return _adminRecordDal.List();
        }
    }
}
