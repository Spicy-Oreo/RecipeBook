using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
    internal class Class1
    {
        string[] IngredName = new string[0];
        int[] IngredAmount = new int[0];
        string[] IngredMeasurement = new string[0];
        string[] Steps = new string[0];

        string ingredientName = "";
        string uMeasurement = "";
        string recipeName = "";

        int ingredientAmount = 0;

        string usrNumSteps = "";
        int numSteps = 0;

        public void RequiredIngredients()
        {
            Console.WriteLine("Please enter the recipe name");
            recipeName = Console.ReadLine();

            Console.WriteLine("Please enter the number of ingredients");
            string usrNumIngredient = Console.ReadLine();

            int numIngredients = Convert.ToInt32(usrNumIngredient);

            int size = numIngredients;

            Array.Resize(ref IngredName, size);
            Array.Resize(ref IngredAmount, size);
            Array.Resize(ref IngredMeasurement, size);

            for (int i = 0; i < IngredName.Length; i++)
            {
                Console.WriteLine("Please enter the ingredient name");
                ingredientName = Console.ReadLine();
                IngredName[i] = ingredientName;

                Console.WriteLine("Please enter the ingredient amount");
                string usringredientAmount = Console.ReadLine();

                ingredientAmount = Convert.ToInt32(usringredientAmount);
                IngredAmount[i] = ingredientAmount;

                Console.WriteLine("Please enter the ingredient unit of measurement (e.g tablespoon/teaspoon)");
                uMeasurement = Console.ReadLine();
                IngredMeasurement[i] = uMeasurement;
            }
        }
    }
}
