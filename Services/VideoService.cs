using IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repository;

namespace Services
{
    public class VideoService : IVideoService
    {
        private readonly VideoRepository videoRepository;

        public VideoService()
        {
            videoRepository = new VideoRepository();
        }

        public VideoM Delete(int id)
        {
            return videoRepository.Delete(id);
        }

        public VideoM Edit(VideoM video)
        {
            return videoRepository.Edit(video);
        }

        public IEnumerable<VideoM> FindAll()
        {
            return videoRepository.FindAll();
        }

        public VideoM FindById(int id)
        {
            return videoRepository.FindById(id);
        }

        public VideoM Save(VideoM video)
        {
            return videoRepository.Save(video);
        }
    }
}
