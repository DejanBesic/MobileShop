using IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ImageRepository : IImageRepository
    {
        private readonly MobileShopEntities Context;

        public ImageRepository()
        {
            Context = new MobileShopEntities();
        }

        public ImagesM Delete(int id)
        {
            Image img = Context.Images.SingleOrDefault(x => x.Id == id);
            if (img == null)
            {
                return null;
            }

            Context.Images.Remove(img);
            Context.SaveChanges();

            return new ImagesM()
            {
                Id = img.Id,
                ImageBinary = img.ImageBinary,
                MobileId = img.MobileId ?? -1,
            };
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ImagesM Edit(ImagesM image)
        {
            var found = Context.Images.SingleOrDefault(x => x.Id == image.Id);
            if (found == null)
            {
                return null;
            }
            found.MobileId = image.MobileId;
            found.ImageBinary = image.ImageBinary;
            Context.SaveChanges();

            return image;
        }

        public IEnumerable<ImagesM> FindAll()
        {
            List<ImagesM> retVal = new List<ImagesM>();
            foreach (Image b in Context.Images.ToList())
            {
                retVal.Add(new ImagesM() { Id = b.Id, ImageBinary =b.ImageBinary, MobileId = b.MobileId ?? -1});
            }

            return retVal;
        }

        public ImagesM FindById(int id)
        {
            Image img = Context.Images.SingleOrDefault(x => x.Id == id);
            if (img == null)
            {

                return null;
            }

            return new ImagesM() { Id = img.Id, MobileId = img.MobileId ?? -1, ImageBinary = img.ImageBinary };
        }

        public IEnumerable<ImagesM> FindByMobile(int mobileId)
        {
            IEnumerable<Image> img = Context.Images.Where(x => x.MobileId == mobileId);
            List<ImagesM> retVal = new List<ImagesM>();
            foreach (Image b in img)
            {
                retVal.Add(new ImagesM() { Id = b.Id, ImageBinary = b.ImageBinary, MobileId = b.MobileId ?? -1 });
            }

            return retVal;
        }

        public ImagesM Save(ImagesM image)
        {
            Image imgDb = new Image()
            {
                ImageBinary = image.ImageBinary,
                MobileId = image.MobileId,
            };
            imgDb = Context.Images.Add(imgDb);
            Context.SaveChanges();
            image.Id = imgDb.Id;
            return image;
        }
    }
}
