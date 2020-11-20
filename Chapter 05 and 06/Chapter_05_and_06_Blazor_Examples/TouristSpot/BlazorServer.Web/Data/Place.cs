using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorServer.Web.Data
{
    public class Place
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Location { get; set; }
        [Required] public string About { get; set; }
        public int Reviews { get; set; }
        public string ImageData { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}

