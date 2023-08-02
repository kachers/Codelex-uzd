namespace Exercise5;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(PhoneKeyPadSwitch());
        Console.WriteLine(PhoneKeyPadIf());
    }

    private static string PhoneKeyPadSwitch()
    {
        Console.WriteLine("Provide your message");
        var input = Console.ReadLine().ToLower().ToCharArray();
        var result = "";
        foreach (var c in input)
            switch (c)
            {
                case 'a':
                    result = string.Concat(result, "2 ");
                    break;
                case 'b':
                    result = string.Concat(result, "22 ");
                    break;
                case 'c':
                    result = string.Concat(result, "222 ");
                    break;
                case 'd':
                    result = string.Concat(result, "3 ");
                    break;
                case 'e':
                    result = string.Concat(result, "33 ");
                    break;
                case 'f':
                    result = string.Concat(result, "333 ");
                    break;
                case 'g':
                    result = string.Concat(result, "4 ");
                    break;
                case 'h':
                    result = string.Concat(result, "44 ");
                    break;
                case 'i':
                    result = string.Concat(result, "444 ");
                    break;
                case 'j':
                    result = string.Concat(result, "5 ");
                    break;
                case 'k':
                    result = string.Concat(result, "55 ");
                    break;
                case 'l':
                    result = string.Concat(result, "555 ");
                    break;
                case 'm':
                    result = string.Concat(result, "6 ");
                    break;
                case 'n':
                    result = string.Concat(result, "66 ");
                    break;
                case 'o':
                    result = string.Concat(result, "666 ");
                    break;
                case 'p':
                    result = string.Concat(result, "7 ");
                    break;
                case 'q':
                    result = string.Concat(result, "77 ");
                    break;
                case 'r':
                    result = string.Concat(result, "777 ");
                    break;
                case 's':
                    result = string.Concat(result, "7777 ");
                    break;
                case 't':
                    result = string.Concat(result, "8 ");
                    break;
                case 'u':
                    result = string.Concat(result, "88 ");
                    break;
                case 'v':
                    result = string.Concat(result, "888 ");
                    break;
                case 'w':
                    result = string.Concat(result, "9 ");
                    break;
                case 'x':
                    result = string.Concat(result, "99 ");
                    break;
                case 'y':
                    result = string.Concat(result, "999 ");
                    break;
                case 'z':
                    result = string.Concat(result, "9999 ");
                    break;
                case ' ':
                    result = string.Concat(result, "0 ");
                    break;
                case '.':
                    result = string.Concat(result, "1 ");
                    break;
                case '!':
                    result = string.Concat(result, "11 ");
                    break;
                default:
                    result = string.Concat(result, "* ");
                    break;
            }

        return result;
    }

    private static string PhoneKeyPadIf()
    {
        Console.WriteLine("Provide your message");
        var input = Console.ReadLine().ToLower().ToCharArray();
        var result = "";
        foreach (var c in input)
        {
            if (c.ToString().Contains("a")) result = string.Concat(result, "2 ");
            if (c.ToString().Contains("b")) result = string.Concat(result, "22 ");
            if (c.ToString().Contains("c")) result = string.Concat(result, "222 ");
            if (c.ToString().Contains("d")) result = string.Concat(result, "3 ");
            if (c.ToString().Contains("e")) result = string.Concat(result, "33 ");
            if (c.ToString().Contains("f")) result = string.Concat(result, "333 ");
            if (c.ToString().Contains("g")) result = string.Concat(result, "4 ");
            if (c.ToString().Contains("h")) result = string.Concat(result, "44 ");
            if (c.ToString().Contains("i")) result = string.Concat(result, "444 ");
            if (c.ToString().Contains("j")) result = string.Concat(result, "5 ");
            if (c.ToString().Contains("k")) result = string.Concat(result, "55 ");
            if (c.ToString().Contains("l")) result = string.Concat(result, "555 ");
            if (c.ToString().Contains("m")) result = string.Concat(result, "6 ");
            if (c.ToString().Contains("n")) result = string.Concat(result, "66 ");
            if (c.ToString().Contains("o")) result = string.Concat(result, "666 ");
            if (c.ToString().Contains("p")) result = string.Concat(result, "7 ");
            if (c.ToString().Contains("q")) result = string.Concat(result, "77 ");
            if (c.ToString().Contains("r")) result = string.Concat(result, "777 ");
            if (c.ToString().Contains("s")) result = string.Concat(result, "7777 ");
            if (c.ToString().Contains("t")) result = string.Concat(result, "8 ");
            if (c.ToString().Contains("u")) result = string.Concat(result, "88 ");
            if (c.ToString().Contains("v")) result = string.Concat(result, "888 ");
            if (c.ToString().Contains("w")) result = string.Concat(result, "9 ");
            if (c.ToString().Contains("x")) result = string.Concat(result, "99 ");
            if (c.ToString().Contains("y")) result = string.Concat(result, "999 ");
            if (c.ToString().Contains("z")) result = string.Concat(result, "9999 ");
            if (c.ToString().Contains(" ")) result = string.Concat(result, "0 ");
            if (c.ToString().Contains(".")) result = string.Concat(result, "1 ");
            if (c.ToString().Contains("!")) result = string.Concat(result, "11 ");
        }

        return result;
    }
}