using System.Collections.Generic;
using System.Linq;
using ContosoPizza.Models;

namespace ContosoPizza.Services
{
  public static class PizzaService
  {
    private static List<Pizza> _pizzas { get; }
    private static int nextId = 3;

    static PizzaService()
    {
      _pizzas = new List<Pizza>()
      {
        new Pizza {Id = 1, Name = "Classic Italian", IsGlutenFree = false},
        new Pizza {Id = 2, Name = "Veggie", IsGlutenFree = true}
      };
    }

    public static List<Pizza> GetAll() => _pizzas;

    public static Pizza Get(int id) => _pizzas.FirstOrDefault(p => p.Id == id);

    public static void Add(Pizza pizza)
    {
      pizza.Id = nextId++;
      _pizzas.Add(pizza);
    }

    public static void Delete(int id)
    {
      var pizza = Get(id);
      if (pizza is null)
        return;

      _pizzas.Remove(pizza);
    }

    public static void Update(Pizza pizza)
    {
      var index = _pizzas.FindIndex(p => p.Id == pizza.Id);
      if (index == -1)
        return;

      _pizzas[index] = pizza;
    }
  }
}