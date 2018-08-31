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
    public class ScreenService : IScreenService
    {
        private readonly ScreenRepository screenRepository;

        public ScreenService()
        {
            screenRepository = new ScreenRepository();
        }

        public ScreenM Delete(int id)
        {
            return screenRepository.Delete(id);
        }

        public ScreenM Edit(ScreenM screen)
        {
            return screenRepository.Edit(screen);
        }

        public IEnumerable<ScreenM> FindAll()
        {
            return screenRepository.FindAll();
        }

        public ScreenM FindById(int id)
        {
            return screenRepository.FindById(id);
        }

        public ScreenM Save(ScreenM screen)
        {
            return screenRepository.Save(screen);
        }
    }
}
