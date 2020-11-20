using System;

namespace PlaceApi.Db.Models
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string About { get; set; }
        public int Reviews { get; set; }
        public string ImageData { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
