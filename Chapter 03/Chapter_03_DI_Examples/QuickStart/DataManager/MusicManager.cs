using Chapter_03_QuickStart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter_03_QuickStart.DataManager
{
    public class MusicManager : IMusicManager
    {
        ////DEPENDENCY LIFETIME EXAMPLE
        public Guid RequestId { get; set; }
        public MusicManager() : this(Guid.NewGuid())
        {
        }
        public MusicManager(Guid requestId)
        {
            RequestId = requestId;
        }

        public INotifier Notify { get; set; }

        //// CONSTRUCTOR INJECTION EXAMPLE
        public List<SongModel> GetAllMusic()
        {
            return new List<SongModel>
            {
                new SongModel { Id = 1, Title = "Interstate Love Song", Artist ="STP", Genre = "Hard Rock" },
                new SongModel { Id = 2, Title = "Man In The Box", Artist ="Alice In Chains", Genre = "Grunge" },
                new SongModel { Id = 3, Title = "Blind", Artist ="Lifehouse", Genre = "Alternative" },
                new SongModel { Id = 4, Title = "Hey Jude", Artist ="The Beatles", Genre = "Rock n Roll" }
            };
        }

        //// METHOD INJECTION EXAMPLE
        public List<SongModel> GetAllMusicThenNotify(INotifier notifier)
        {
            //invoke the notifier method
            var success = notifier.SendMessage("User viewed the music list page.");

            //return the response
            return success
                   ? GetAllMusic()
                   : Enumerable.Empty<SongModel>().ToList();

        }

        //// PROPERTY INJECTION EXAMPLE
        public List<SongModel> GetAllMusicThenNotify()
        {
            // Check if the Notify property has been set
            if (Notify != default)
            {
                //invoke the notifier method
                Notify.SendMessage("User viewed the music list page.");

            }

            //return list of music
            return GetAllMusic();
        }

        //// VIEW INJECTION EXAMPLE
        public async Task<int> GetMusicCount()
        {
            return await Task.FromResult(GetAllMusic().Count);
        }
    }
}

