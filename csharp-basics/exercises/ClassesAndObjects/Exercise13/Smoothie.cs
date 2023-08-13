namespace Exercise13;

internal class Smoothie
{
    public readonly List<string> Ingredients;

    public Smoothie(List<string> ingredients)
    {
        Ingredients = ingredients;
    }

    public double GetCost()
    {
        double totalCost = 0;
        foreach (var fruit in Ingredients)
            switch (fruit)
            {
                case "Strawberries":
                    totalCost += 1.5;
                    break;
                case "Banana":
                    totalCost += 0.5;
                    break;
                case "Mango":
                    totalCost += 2.5;
                    break;
                case "Blueberries":
                    totalCost += 1;
                    break;
                case "Raspberries":
                    totalCost += 1;
                    break;
                case "Apple":
                    totalCost += 1.75;
                    break;
                case "Pineapple":
                    totalCost += 3.5;
                    break;
            }

        return totalCost;
    }

    public double GetPrice()
    {
        var cost = GetCost();
        var price = cost + cost * 1.5;
        return Math.Round(price, 2);
    }

    public string GetName()
    {
        var name = string.Empty;
        Ingredients.Sort();
        foreach (var fruit in Ingredients) name += fruit.Replace("berries", "berry") + " ";

        return Ingredients.Count < 2 ? $"{name + "Smoothie"}" : $"{name + "Fusion"}";
    }
}