namespace RecipeBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, welcome to My Recipe Book!");
            Class1 c1 = new Class1();
            c1.RequiredIngredients();
            c1.Instructions();
            c1.Choice();

            Console.ReadLine();
        }
    }
}