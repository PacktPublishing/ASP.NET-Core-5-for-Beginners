using System;

namespace Chapter_03_QuickStart.DataManager
{
    public class InstrumentalMusicManager 
    {

        private readonly IMusicManager _musicManager;
        public Guid RequestId { get; set; }
        public InstrumentalMusicManager(IMusicManager musicManager)
        {
            RequestId = musicManager.RequestId;
        }

    }
}
