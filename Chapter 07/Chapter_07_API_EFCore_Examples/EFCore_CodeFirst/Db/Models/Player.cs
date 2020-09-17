using System;
using System.Collections.Generic;

namespace EFCore_CodeFirst.Db.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string NickName { get; set; }
        public DateTime JoinedDate { get; set; }
        public List<PlayerInstrument> Instruments { get; set; }
    }
}


