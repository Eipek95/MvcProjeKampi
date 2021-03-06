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
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal _imageFile;

        public ImageFileManager(IImageFileDal image)
        {
            _imageFile = image;
        }

        public List<ImageFile> GetList()
        {
            return _imageFile.List();
        }

        public void ImageAddBL(ImageFile image)
        {
            _imageFile.Insert(image);
        }
    }
}
