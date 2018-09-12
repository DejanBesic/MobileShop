using IServices;
using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ImageService : IImageService
    {
        private readonly ImageRepository imageRepository;

        public ImageService()
        {
            imageRepository = new ImageRepository();
        }

        public ImagesM Delete(int id)
        {
            return imageRepository.Delete(id);
        }

        public ImagesM Edit(ImagesM image)
        {
            return imageRepository.Edit(image);
        }

        public IEnumerable<ImagesM> FindAll()
        {
            return imageRepository.FindAll();
        }

        public ImagesM FindById(int id)
        {
            return imageRepository.FindById(id);
        }

        public IEnumerable<ImagesM> FindByMobile(int mobileId)
        {
            return imageRepository.FindByMobile(mobileId);
        }

        public ImagesM Save(ImagesM image)
        {
            return imageRepository.Save(image);
        }
    }
}
