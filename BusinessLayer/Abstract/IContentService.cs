﻿using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList();
        List<Content> GetListByID(int id);
        void ContentAddBL(Content category);
        Content GetByID(int id);
        void ContentDelete(Content category);
        void ContentUpdate(Content category);
    }
}