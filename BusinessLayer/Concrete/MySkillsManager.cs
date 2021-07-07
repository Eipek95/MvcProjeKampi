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
            return _mySkillsDal.Get(x=>x.mySkillsID==id);
        }

        public List<MySkills> GetList()
        {
            return _mySkillsDal.List();
        }

        public void MySkillsAddBL(MySkills skill)
        {
            _mySkillsDal.Insert(skill);
        }

        public void MySkillsDelete(MySkills skill)
        {
            _mySkillsDal.Delete(skill);
        }

        public void MySkillsUpdate(MySkills skill)
        {
            _mySkillsDal.Update(skill);
        }
    }
}
