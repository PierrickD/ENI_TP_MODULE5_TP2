using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationModule5Tp2_BO;
using WebApplicationModule5Tp2.Models;

namespace WebApplicationModule5Tp2.Controllers
{
    public class PizzaController : Controller
    {
        public List<Ingredient> listIngredients { get; set; } = WebApplicationModule5Tp2_BO.Pizza.IngredientsDisponibles;
        public List<Pate> listPates { get; set; } = WebApplicationModule5Tp2_BO.Pizza.PatesDisponibles;
        private List<Pizza> listPizza = new List<Pizza>();

        // GET: Pizza
        public ActionResult Index()
        {
            return View(listPizza);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            var pizzaById = listPizza.FirstOrDefault(pizza => pizza.Id == id);
            if (pizzaById == null)
            {
                RedirectToAction("Index");
            }
            return View(pizzaById);
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            PizzaViewModel pizzaVM = new PizzaViewModel();
            pizzaVM.listIngredients = listIngredients;
            pizzaVM.listPates = listPates;
            return View(pizzaVM);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzaViewModel pizzaVM)
        {
            try
            {
                // TODO: Add insert logic here
                Pizza pizza = pizzaVM.pizza;
                pizza.Id = (listPizza.OrderBy(p => p.Id).Last().Id)+1;
                pizza.Pate = pizzaVM.listPates.FirstOrDefault(pate => pate.Id == pizzaVM.idSelectPate);
                foreach(var ingredient in pizzaVM.listIngredients)
                {
                    pizza.Ingredients.Add(pizzaVM.listIngredients.FirstOrDefault(i => i.Id == ingredient.Id));
                }

                listPizza.Add(pizza);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            var pizzaById = listPizza.FirstOrDefault(pizza => pizza.Id == id);
            if (pizzaById == null)
            {
                RedirectToAction("Index");
            }
            return View(pizzaById);
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            var pizzaById = listPizza.FirstOrDefault(pizza => pizza.Id == id);
            if (pizzaById == null)
            {
                RedirectToAction("Index");
            }
            return View(pizzaById);
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var pizzaById = listPizza.FirstOrDefault(pizza => pizza.Id == id);
                if (pizzaById != null)
                {
                    listPizza.Remove(pizzaById);
                }
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
