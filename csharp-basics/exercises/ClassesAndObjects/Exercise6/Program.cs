namespace Exercise6;

internal class Program
{
    private static void Main(string[] args)
    {
        var dog1 = new Dog("Max", "male");
        var dog2 = new Dog("Rocky", "male");
        var dog3 = new Dog("Sparky", "male");
        var dog4 = new Dog("Buster", "male");
        var dog5 = new Dog("Sam", "male");
        var dog6 = new Dog("Lady", "female");
        var dog7 = new Dog("Molly", "female");
        var dog8 = new Dog("Coco", "female");

        dog1.Mother = dog6;
        dog1.Father = dog2;
        dog2.Mother = dog7;
        dog2.Father = dog5;
        dog4.Mother = dog6;
        dog4.Father = dog3;
        dog8.Mother = dog7;
        dog8.Father = dog4;

        Console.WriteLine($"Should return Buster: \n actually returns : {dog8.FathersName()}");
        Console.WriteLine($"\nShould return Unknown: \n actually returns : {dog3.FathersName()}");
        Console.WriteLine($"\nIf Coco has the same Mother as Rocky" +
                          $" it should return True: \n actually returns : {dog8.HasSameMotherAs(dog2)}");
    }
}