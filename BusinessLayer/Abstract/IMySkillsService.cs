using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    interface IMySkillsService
    {
        List<MySkills> GetList();
        void MySkillsAddBL(MySkills skill);
        MySkills GetByID(int id);
        void MySkillsDelete(MySkills skill);
        void MySkillsUpdate(MySkills skill);
    }
}
