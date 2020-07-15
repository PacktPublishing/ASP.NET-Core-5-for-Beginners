using Chapter_03_QuickStart.Models;
using System;
using System.Collections.Generic;

namespace Chapter_03_QuickStart.DataManager
{
    public interface IMusicManager
    {
        //CONSTRUCTOR INJECTION EXAMPLE
        List<SongModel> GetAllMusic();

        //METHOD INJECTION EXAMPLE
        List<SongModel> GetAllMusicThenNotify(INotifier notifier);

        //PROPERTY INJECTION EXAMPLE
        INotifier Notify { get; set; }
        List<SongModel> GetAllMusicThenNotify();

        Guid RequestId { get; set; }
    }
}

