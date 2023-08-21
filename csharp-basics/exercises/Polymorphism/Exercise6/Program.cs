namespace Exercise6;

internal class Program
{
    private static void Main(string[] args)
    {
        var animalInput = string.Empty;
        List<Mammal> resultList = new();

        while (animalInput != "End")
        {
            Console.WriteLine("Enter animal type, name, weight, region and breed(if applicable)");
            animalInput = Console.ReadLine();
            if (animalInput.Equals("End")) break;


            var animalInputSplited = animalInput.Split(" ");
            var type = animalInputSplited[0];
            var name = animalInputSplited[1];
            var weight = double.Parse(animalInputSplited[2]);
            var region = animalInputSplited[3];

            var food = ReadFoodInput();

            switch (type.ToLower())
            {
                case "cat":
                    var breed = animalInputSplited[4];
                    var cat1 = new Cat(type, name, weight, region, breed);
                    cat1.MakeSound();
                    cat1.EatFood(food);
                    Console.WriteLine(cat1.ToString());
                    resultList.Add(cat1);
                    break;
                case "tiger":
                    var tiger1 = new Tiger(type, name, weight, region);
                    tiger1.MakeSound();
                    tiger1.EatFood(food);
                    Console.WriteLine(tiger1.ToString());
                    resultList.Add(tiger1);
                    break;
                case "mouse":
                    var mouse1 = new Mouse(type, name, weight, region);
                    mouse1.MakeSound();
                    mouse1.EatFood(food);
                    Console.WriteLine(mouse1.ToString());
                    resultList.Add(mouse1);
                    break;
                case "zebra":
                    var zebra1 = new Zebra(type, name, weight, region);
                    zebra1.MakeSound();
                    zebra1.EatFood(food);
                    Console.WriteLine(zebra1.ToString());
                    resultList.Add(zebra1);
                    break;
            }
        }

        Console.WriteLine(string.Join(",", resultList));
    }

    public static Food ReadFoodInput()
    {
        Console.WriteLine("Provide food");
        var foodInput = Console.ReadLine();
        var foodInputSplited = foodInput.Split(" ");
        var foodType = foodInputSplited[0];
        var amount = int.Parse(foodInputSplited[1]);
        if (foodType.Equals("meat"))
        {
            var meat = new Meat(amount);
            return meat;
        }

        var vegetable = new Vegetable(amount);
        return vegetable;
    }
}