namespace BlazingPizza.Data;

/// <summary>
/// Represents pizza schema in the data source
/// </summary>
public class Pizza
{
    public int PizzaId { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public decimal Price { get; set; }
    
    public bool Vegetarian { get; set; }
    
    public bool Vegan { get; set; }
}