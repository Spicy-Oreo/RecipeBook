using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RecipeBook
{
    internal class Class1
    {
        /// <summary>
        /// Declaration of variables in order to allow them to be used globally 
        /// </summary>
        string[] IngredName = new string[0];
        double[] IngredAmount = new double[0];
        string[] IngredMeasurement = new string[0];
        string[] IngredSteps = new string[0];

        string ingredientName = "";
        string uMeasurement = "";
        string recipeName = "";

        int inputHere = 0;

        double ingredientAmount = 0.0;

        string usrNumSteps = "";
        int numSteps = 0;

        /// <summary>
        /// Method used to populate the ingriend detials (Name, amount ,quatity) based on how many ingredients there are 
        /// </summary>
        public void RequiredIngredients()
        {
            try
            {
                Console.WriteLine("Please enter the recipe name");
                recipeName = Console.ReadLine();


                Console.WriteLine("Please enter the number of ingredients");
                string usrNumIngredient = Console.ReadLine();

                if (Regex.IsMatch(usrNumIngredient, @"^\d$"))
                {
                    //Converting the users standard string input into a int value
                    int numIngredients = Convert.ToInt32(usrNumIngredient);


                    //Resizing all arrays based on the number of ingredients 
                    int size = numIngredients;

                    Array.Resize(ref IngredName, size);
                    Array.Resize(ref IngredAmount, size);
                    Array.Resize(ref IngredMeasurement, size);


                    //for loop to loop through the populating of ingredient details
                    for (int i = 0; i < IngredName.Length; i++)
                    {
                        Console.WriteLine("Please enter the ingredient name");
                        ingredientName = Console.ReadLine();
                        IngredName[i] = ingredientName;

                        Console.WriteLine("Please enter the ingredient amount");
                        string usringredientAmount = Console.ReadLine();

                        ingredientAmount = Convert.ToDouble(usringredientAmount);
                        IngredAmount[i] = ingredientAmount;

                        Console.WriteLine("Please enter the ingredient unit of measurement (e.g tablespoon/teaspoon)");
                        uMeasurement = Console.ReadLine();
                        IngredMeasurement[i] = uMeasurement;
                       
                    }
                    Instructions();

                }


                //Else statement to restart the method if the user input was not in the correct format
                else
                {
                    Console.WriteLine("Invalid input for number of ingredients please try again");
                    RequiredIngredients();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// End of the method
        /// </summary>



        /// <summary>
        /// Method used to populate the steps with the information based on how many steps there are
        /// </summary>
        public void Instructions()
        {
            try
            {


                Console.WriteLine("Please enter the number of steps");
                usrNumSteps = Console.ReadLine();

                //If statment to verify user entered a number
                if (Regex.IsMatch(usrNumSteps, @"^\d$"))
                {
                    //Converting of user input to int
                    numSteps = Convert.ToInt32(usrNumSteps);

                    ///Resizing the array based on the user input
                    Array.Resize(ref IngredSteps, numSteps);

                    //For loop to populate the steps with instructions
                    for (int i = 0; i < IngredSteps.Length; i++)
                    {
                        Console.WriteLine("Please enter step " + (1 + i));
                        string stepDetails = Console.ReadLine();
                        IngredSteps[i] = stepDetails;
                    }
                    Choice();
                }
                //else statment to restart the method if a number value was not entered 
                else
                {
                    Console.WriteLine("Invalid input please enter a number");
                    Instructions();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// End of the method
        /// </summary>




        /// <summary>
        /// Method which allows user to increase scale of recipe or leave it as the original
        /// </summary>
        public void Choice()
        {
            try
            {


                Console.WriteLine("Would you like to increase the scale ? Enter 1 for no or any other digit as the scale you want to increase the recipe by");
                string input = Console.ReadLine();

                ///If user choses 1 it will print the original choice 
                if (input == "1")
                {
                    PrintOriginal();
                }

                //If the input is a digit it will be the factor at which the ingredients are multiplied by 
                else if (Regex.IsMatch(input, @"^\d$"))
                {
                    inputHere = Convert.ToInt32(input);
                    PrintScaledUp();

                }

                //If the input is not a digit it will prompt the user of the error and re-run the method so the user can re-enter in the correct format (digit)
                else
                {
                    Console.WriteLine("Invalid input please enter a digit");
                    Choice();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// End of the method
        /// </summary>






        /// <summary>
        /// Method used to print the recipe based on what it is scaled up by 
        /// </summary>
        public void PrintScaledUp()
        {
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("Ingredients");
            Console.WriteLine("-----------");
            for (int i = 0; i < IngredName.Length; i++)
            {
                string IngredientNameHere = IngredName[i];
                string IngredientMeasurementHere = IngredMeasurement[i];
                double IngredientAmountHere = (IngredAmount[i] * inputHere);
                Console.WriteLine(IngredientAmountHere + " " + IngredientMeasurementHere + " " + IngredientNameHere);
            }
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("Steps");
            Console.WriteLine("-----");
            for (int i = 0; i < IngredSteps.Length; i++)
            {
                Console.WriteLine("Step " + (i + 1) + ": " + IngredSteps[i]);
            }
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Would you like to return to the orignal values ? Enter 1 for yes or any other key to exit");
            string originalInput = Console.ReadLine();
            if (originalInput == "1")
            {
                PrintOriginal();
            }
            else
            {
                System.Environment.Exit(0);
            }
        }
        /// <summary>
        /// End of method 
        /// </summary>
        



        /// <summary>
        /// Method used to print the oringal recipe scale 
        /// </summary>
        public void PrintOriginal()
        {
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("Ingredients");
            Console.WriteLine("-----------");
            for (int i = 0; i < IngredName.Length; i++)
            {
                string IngredientNameHere = IngredName[i];
                string IngredientMeasurementHere = IngredMeasurement[i];
                double IngredientAmountHere = IngredAmount[i];
                Console.WriteLine(IngredientAmountHere + " " + IngredientMeasurementHere + " " + IngredientNameHere);
            }
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("Steps");
            Console.WriteLine("-----");
            for (int i = 0; i < IngredSteps.Length; i++)
            {
                Console.WriteLine("Step " + (i + 1) + ": " + IngredSteps[i]);
            }
            Console.WriteLine("------------------------------------------------------------------------------------------------");
        }
        /// <summary>
        /// End of the method
        /// </summary>

    }
}
/// <summary>
/// Method used to allow the user to increase the scale of the recipe or print with the original details
/// </summary>
