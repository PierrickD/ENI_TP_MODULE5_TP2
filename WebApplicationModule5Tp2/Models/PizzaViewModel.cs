using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationModule5Tp2_BO;

namespace WebApplicationModule5Tp2.Models
{
    public class PizzaViewModel
    {
        public Pizza pizza { get; set; }
        public List<Ingredient> listIngredients { get; set; } = new List<Ingredient>();
        public List<Pate> listPates { get; set; } = new List<Pate>();

        public List<int> idSelectIngredients { get; set; } = new List<int>();
        public int idSelectPate { get; set; }
        
    }
}