using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repository
{
    public class VideoRepository : IVideoRepository
    {
        private readonly MobileShopEntities Context;

        public VideoRepository()
        {
            Context = new MobileShopEntities();
        }

        public VideoM Delete(int id)
        {
            Video videoDb = Context.Videos.Single(x => x.Id == id);
            if (videoDb == null)
            {
                return null;
            }

            Context.Videos.Remove(videoDb);
            Context.SaveChanges();

            return new VideoM()
            {
                Id =  videoDb.Id,
                Description = videoDb.VideoDescription
            };
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public VideoM Edit(VideoM video)
        {
            var found = Context.Videos.SingleOrDefault(x => x.Id == video.Id);
            if (found == null)
            {
                return null;
            }
            found.VideoDescription = video.Description;
            Context.SaveChanges();

            return video;
        }

        public IEnumerable<VideoM> FindAll()
        {
            
            List<VideoM> retVal = new List<VideoM>();
            foreach (Video a in Context.Videos.ToList())
            {
                retVal.Add(new VideoM()
                {
                    Id = a.Id,
                    Description = a.VideoDescription
                });
            }

            return retVal;
        }

        public VideoM FindById(int id)
        {
            Video found = Context.Videos.SingleOrDefault(x => x.Id == id);
            if (found == null)
            {
                return null;
            }

            return new VideoM() {
                Id = found.Id,
                Description = found.VideoDescription,
            };
        }

        public VideoM Save(VideoM video)
        {
            Video videoDb = new Video()
            {
               VideoDescription = video.Description
            };
            Context.Videos.Add(videoDb);
            Context.SaveChanges();
            video.Id = videoDb.Id;
            return video;
        }
    }
}
