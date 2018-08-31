using IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ScreenRepository : IScreenRepository
    {
        private readonly MobileShopEntities Context;

        public ScreenRepository()
        {
            Context = new MobileShopEntities();
        }

        public ScreenM Delete(int id)
        {
            Screen screen = Context.Screens.SingleOrDefault(x => x.Id == id);
            Context.Screens.Remove(screen);
            Context.SaveChanges();

            return new ScreenM()
            {
                Id = screen.Id,
                Resolution = screen.Resolution,
                ScreenType = screen.ScreenType,
                Size = screen.Size,
                Touch = screen.Touch ?? false,
            };
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ScreenM Edit(ScreenM screen)
        {
            var found = Context.Screens.SingleOrDefault(x => x.Id == screen.Id);
            if (found == null)
            {
                return null;
            }
            found.Resolution = screen.Resolution;
            found.ScreenType = screen.ScreenType;
            found.Size = screen.Size;
            found.Touch = screen.Touch;
            Context.SaveChanges();

            return screen;
        }

        public IEnumerable<ScreenM> FindAll()
        {
            List<ScreenM> retVal = new List<ScreenM>();
            foreach (Screen s in Context.Screens.ToList())
            {
                retVal.Add(new ScreenM()
                {
                    Id = s.Id,
                    Resolution = s.Resolution,
                    ScreenType = s.ScreenType,
                    Size = s.Size,
                    Touch = s.Touch ?? false,
                });
            }

            return retVal;
        }

        public ScreenM FindById(int id)
        {
            Screen screen = Context.Screens.SingleOrDefault(x => x.Id == id);

            return new ScreenM()
            {
                Id = screen.Id,
                Resolution = screen.Resolution,
                ScreenType = screen.ScreenType,
                Size = screen.Size,
                Touch = screen.Touch ?? false,
            };
        }

        public ScreenM Save(ScreenM screen)
        {
            Screen screenDb = new Screen()
            {
                Resolution = screen.Resolution,
                ScreenType = screen.ScreenType,
                Size = screen.Size,
                Touch = screen.Touch,
            };
            Context.Screens.Add(screenDb);
            Context.SaveChanges();
            screen.Id = screenDb.Id;
            return screen;
        }
    }
}
