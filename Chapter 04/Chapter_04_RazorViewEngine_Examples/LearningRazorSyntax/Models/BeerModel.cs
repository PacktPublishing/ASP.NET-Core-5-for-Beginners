using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter_04_LearningRazorSyntax.Models
{
    public class BeerModel
    {
        [Display(Name = "Beer Id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }

    //This class should be in a separate class file to value separation of concerns
    //But we just include it here for the simplicity of this exercise
    public class Beer
    {
        public List<BeerModel> GetAllBeer()
        {
            return new List<BeerModel>
            {
                new BeerModel { Id =1, Name="Redhorse", Type="Lager" },
                new BeerModel { Id =2, Name="Furious", Type="IPA" },
                new BeerModel { Id =3, Name="Guinness", Type="Stout" },
                new BeerModel { Id =4, Name="Sierra", Type="Ale" },
                new BeerModel { Id =5, Name="Stella", Type="Pilsner" },
            };
        }
    }

}

