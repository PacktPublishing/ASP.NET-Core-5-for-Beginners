using Chapter_03_QuickStart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter_03_QuickStart.DataManager
{
    public class AwesomeMusicManager : IMusicManager
    {
        public INotifier Notify { get; set; }
        public Guid RequestId { get; set; }

        public List<SongModel> GetAllMusic()
        {
            throw new NotImplementedException();
        }

        public List<SongModel> GetAllMusicThenNotify(INotifier notifier)
        {
            throw new NotImplementedException();
        }

        public List<SongModel> GetAllMusicThenNotify()
        {
            throw new NotImplementedException();
        }
    }
}
