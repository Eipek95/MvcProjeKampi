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
    public class MySkillsManager: IMySkillsService
    {
        IMySkillsDal _mySkillsDal;

        public MySkillsManager(IMySkillsDal mySkillsDal)
        {
            _mySkillsDal = mySkillsDal;
        }

        public MySkills GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<MySkills> GetList()
        {
            return _mySkillsDal.List();
        }

        public void MySkillsAddBL(MySkills skill)
        {
            throw new NotImplementedException();
        }

        public void MySkillsDelete(MySkills skill)
        {
            throw new NotImplementedException();
        }

        public void MySkillsUpdate(MySkills skill)
        {
            throw new NotImplementedException();
        }
    }
}
