namespace BlazingPizza.Data;

public class PizzaService
{
    public virtual Task<Pizza[]> GetPizzasAsync()
    {
        Pizza[] pizzas = [
            new Pizza()
            {
                Name = "Margherita",
                Description = "Very delicious",
                PizzaId = 1,
                Price = 12.6M,
                Vegan = false,
                Vegetarian = false,
            }
        ];

        // Call your data access technology here
        // For now, return in-memory
        return Task.FromResult(pizzas);
    }
}