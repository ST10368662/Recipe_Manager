using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows;
using System;
using System.Xml.Linq;

namespace poe
{
    internal class capturing
    {

        //the generic collection
        public static List<string> nameOfRecipe = new List<string>();
        private static List<string> TheIngredients = new List<string>();
        private static List<string> TheQuantity = new List<string>();
        private static List<string> TheMeasurements = new List<string>();
        private static List<string> Thecalories = new List<string>();
        private static List<string> ThefoodGroups = new List<string>();
        private static List<string> TheSteps = new List<string>();
        private static List<string> OriginalQuantity = new List<string>();
        public List<string> addingForFilter = new List<string>();


        //The delegate to calculate the calories
        delegate T caloriesCalculations<T>(T calculations);

        //string manipulations

        string holdName = "";

        double m;
        string measure = "";
        int counts = 1;
        int counting = 1;
        int stepCounting = 1;
        int incrementOfSteps = 1;

        public int addTheCalories = 0;
        public int captureCalories = 0;
        public int countCalculate = 0;


        //method to capture recipe name and the number of recipes
        public void count(string name, string count, System.Windows.Controls.Label recipe, System.Windows.Controls.Label countless, Grid cap, Button captButton)
        {

            if (name != "" && count != "" && count.Any(char.IsNumber))
            {
                //ingredientsNumberCount = int.Parse(numberOfIngredient);

                //the recipe name label content
                recipe.Content = "Recipe name: " + name.ToUpper();
                nameOfRecipe.Add(name);


                //changing the button content based on the number of ingredients
                cap.Visibility = Visibility.Visible;


                countless.Content = "Ingredient " + counting + "/" + count;


                captButton.Content = "Capture";
                counts = int.Parse(count);

                holdName = name;
            }

            else if (name != "" && count != "" && !count.Any(char.IsNumber))
            {
                // error handling;
                MessageBox.Show("Please enter a number on number of ingredients box", "Words or letter Entry", MessageBoxButton.OK);
            }
            else
            {
                // error handling;
                MessageBox.Show("Please fill in the space", "Blank Entry", MessageBoxButton.OK);
            }

            addTheCalories = 0;
            captureCalories = int.Parse(count);
            countCalculate = 0;

        }

        //method to capture the recipe ingredient
        internal void captures(string text1, string text2, string text3, string text4, string text5, System.Windows.Controls.Label countless, Button cap, System.Windows.Controls.Label check)

        {
            countCalculate++;

            check.Content = "true";

            if (counting < counts)
            {

                if (text1 != "" && text3 != "" && text2 != "" && text2.Any(char.IsNumber) && text5 != "")
                {
                    m = double.Parse(text2);
                    measure = text3;

                    if (Regex.IsMatch(text2, @"\d+$") && Regex.IsMatch(text5, @"\d+$"))
                    {
                        TheIngredients.Add(text1 + holdName);
                        TheQuantity.Add(m + holdName);
                        TheMeasurements.Add(measure + holdName);
                        Thecalories.Add(text5 + holdName);
                        ThefoodGroups.Add(text4 + holdName);
                        OriginalQuantity.Add(m + holdName);


                        counting += 1;
                        countless.Content = "Ingredient " + counting + "/" + counts;

                        check.Content = "true";

                    }

                    else
                    {
                        check.Content = "false";

                        MessageBox.Show("Only digits allowed on quantity and the calories");
                    }

                }

                else if (text1 != "" && text3 != "" && text2 != "" && !text2.Any(char.IsNumber) && text5 != "")
                {
                    check.Content = "false";
                    MessageBox.Show("Please enter a number on quantity box", "Words or letter Entry", MessageBoxButton.OK);

                }

                else if (text1 != "" && text3 != "" && text2 != "" && text5 != "" && !text5.Any(char.IsNumber))
                {
                    check.Content = "false";

                    MessageBox.Show("Please enter a number on calories box", "Words or letter Entry", MessageBoxButton.OK);
                }

                else
                {
                    check.Content = "false";
                    // error handling;
                    MessageBox.Show("fill in the space", "Blank Entry", MessageBoxButton.OK);
                }

            }
            else
            {
                if (counting == counts)
                {

                    if (Regex.IsMatch(text2, @"\d+$") && Regex.IsMatch(text5, @"\d+$"))
                    {
                        MessageBox.Show("Stored Ingredient data");


                        cap.Content = "Steps";

                        measure = text3;
                        m = double.Parse(text2);

                        TheIngredients.Add(text1 + holdName);
                        TheQuantity.Add(m + holdName);
                        TheMeasurements.Add(measure + holdName);
                        Thecalories.Add(text5 + holdName);
                        ThefoodGroups.Add(text4 + holdName);
                        OriginalQuantity.Add(m + holdName);


                        counting += 1;
                        countless.Content = "Ingredient " + counting + "/" + counts;

                        check.Content = "true";

                    }

                    else
                    {
                        check.Content = "false";
                        MessageBox.Show("Only digits allowed on ingredient and the calories");
                    }

                }

            }

            //The delagate object to return the return the error is the calories have passed the name
            caloriesCalculations<int> theReturnMessageAndCalculation = new caloriesCalculations<int>(calculateTheSumOfCalories);

            //object reference for the calculation of calories
            theReturnMessageAndCalculation(int.Parse(text5));

        }

        // method to capture the number of recipe
        public void stepsNumberCount(string numberOfIngredeint, Grid capturingNumberOfSteps, System.Windows.Controls.Label stepCount)
        {

            if (numberOfIngredeint != "" && numberOfIngredeint.Any(char.IsNumber))
            {
                capturingNumberOfSteps.Visibility = Visibility.Visible;
                stepCount.Content = incrementOfSteps + "/" + numberOfIngredeint;
                stepCounting = int.Parse(numberOfIngredeint);


            }
            else if (numberOfIngredeint != "" && numberOfIngredeint != "" && !numberOfIngredeint.Any(char.IsNumber))
            {
                // error handling;
                MessageBox.Show("Please enter a number ", "Words or letter Entry", MessageBoxButton.OK);
            }
            else
            {


                // error handling;
                MessageBox.Show("Please fill in the space", "Blank Entry", MessageBoxButton.OK);
            }

        }

        //storing steps
        internal void stepsStoring(string numberOfIngredeint, System.Windows.Controls.Label stepCount, string steps, Grid stepGrid, Grid numStep, Grid ingCap, Grid numIngCap)
        {

            if (incrementOfSteps < stepCounting)
            {

                if (steps != "")
                {
                    TheSteps.Add("Step no " + incrementOfSteps + "\n Description : " + steps + holdName);

                    incrementOfSteps += 1;
                    stepCount.Content = incrementOfSteps + "/" + numberOfIngredeint;

                }

                else
                {

                    // error handling;
                    MessageBox.Show("fill in the boxes", "Blank Entry", MessageBoxButton.OK);

                }

            }
            else
            {
                if (incrementOfSteps == stepCounting && steps != "")
                {
                    TheSteps.Add("Step no " + incrementOfSteps + "\n Description : " + steps + holdName);

                    MessageBox.Show("all steps stored");

                    incrementOfSteps = 1;
                    counting = 1;

                    stepGrid.Visibility = Visibility.Hidden;
                    numStep.Visibility = Visibility.Hidden;
                    ingCap.Visibility = Visibility.Hidden;
                    numIngCap.Visibility = Visibility.Hidden;

                }

                else
                {

                    // error handling;
                    MessageBox.Show("fill in the boxes", "Blank Entry", MessageBoxButton.OK);

                }
            }

        }

        //adding recipe names to combo box displaying
        internal void load(ComboBox displayRecipeNames)
        {
            nameOfRecipe.Sort();

            displayRecipeNames.Items.Clear();

            for (int y = 0; y < nameOfRecipe.Count; y++)
            {
                displayRecipeNames.Items.Add(nameOfRecipe[y]);

            }
        }

        //displaying recipe name
        internal void listBoxDisplay(string name, ListView displayOfIngredeintData)
        {

            //display the ingredient data as they are stored
            displayOfIngredeintData.Items.Clear();


            displayOfIngredeintData.Items.Add("            Recipe name:         " + name);

            for (int inputs = 0; inputs < TheIngredients.Count; inputs++)
            {
                //checking if the generics contains the selected recipe name and display on list view if contains the selected recipe name

                if (TheIngredients[inputs].Contains(name) && TheQuantity[inputs].Contains(name) && TheMeasurements[inputs].Contains(name)
                     && ThefoodGroups[inputs].Contains(name) && Thecalories[inputs].Contains(name))

                {
                    //display the recipe content e.g the ingredients
                    displayOfIngredeintData.Items.Add("The name of ingredient: " + TheIngredients[inputs].Replace(name, ""));
                    displayOfIngredeintData.Items.Add("The quantity: " + TheQuantity[inputs].Replace(name, ""));
                    displayOfIngredeintData.Items.Add("The measurement: " + TheMeasurements[inputs].Replace(name, ""));
                    displayOfIngredeintData.Items.Add("The food group: " + ThefoodGroups[inputs].Replace(name, ""));
                    displayOfIngredeintData.Items.Add("The calories: " + Thecalories[inputs].Replace(name, ""));
                    displayOfIngredeintData.Items.Add("**************************************************************************");

                }
            }
            displayOfIngredeintData.Items.Add("                    STEPS");

            for (int step = 0; step < TheSteps.Count; step++)
            {
                if (TheSteps[step].Contains(name))
                {

                    displayOfIngredeintData.Items.Add(TheSteps[step].Replace(name, ""));

                }
            }
        }

       
        //adding recipe names to combo box for scaling
        internal void scalRecipeName(ComboBox ScalingRecipeNames)
        {
            nameOfRecipe.Sort();

            ScalingRecipeNames.Items.Clear();

            for (int y = 0; y < nameOfRecipe.Count; y++)
            {
                ScalingRecipeNames.Items.Add(nameOfRecipe[y]);

            }
        }

        //displaying scaled recipe

        internal void listBoxScale(string name, ListView ScaledIngredeintData, ComboBox calculationScale, ComboBox ScalingRecipeNames)
        {

            //display the ingredient data as they are stored

            ScaledIngredeintData.Items.Clear();


            ScaledIngredeintData.Items.Add("                                                                   " + name + "                                               ");



            for (int inputs = 0; inputs < TheIngredients.Count; inputs++)
            {



                //display the recipe content e.g the ingredients
                if (TheIngredients[inputs].Contains(name) && TheQuantity[inputs].Contains(name) && TheMeasurements[inputs].Contains(name)
                     && ThefoodGroups[inputs].Contains(name) && Thecalories[inputs].Contains(name))
                {


                    double b = double.Parse(TheQuantity[inputs].Replace(name, ""));
                    double cal = b * double.Parse(calculationScale.Text);

                    TheQuantity[inputs] = "" + cal + name;

                    if (cal >= 8)
                    {

                        if (measure == "table spoon" || measure == "TABLE SPOON" || measure == "tablespoon"
                            || measure == "TABLESPOON" || measure == "table spoons" || measure == "TABLE SPOONS")
                        {
                            TheMeasurements[inputs] = "cup" + name;

                            TheQuantity[inputs] = "1" + name;
                        }
                        else
                        {

                            TheQuantity[inputs] = "" + cal + name;
                        }

                    }
                    ScaledIngredeintData.Items.Add("The name of ingredient: " + TheIngredients[inputs].Replace(name, ""));
                    ScaledIngredeintData.Items.Add("The quantity: " + TheQuantity[inputs].Replace(name, ""));
                    ScaledIngredeintData.Items.Add("The measurement: " + TheMeasurements[inputs].Replace(name, ""));
                    ScaledIngredeintData.Items.Add("The food group: " + ThefoodGroups[inputs].Replace(name, ""));
                    ScaledIngredeintData.Items.Add("The calories: " + Thecalories[inputs].Replace(name, ""));
                    ScaledIngredeintData.Items.Add("***********************************************************************");

                }
            }

            ScaledIngredeintData.Items.Add("                                                                  STEPS                                                                  ");

            for (int step = 0; step < TheSteps.Count; step++)
            {
                if (TheSteps[step].Contains(name))
                {


                    ScaledIngredeintData.Items.Add(TheSteps[step].Replace(name, ""));

                }
            }
        }

        //adding the recipe names to the combo on the originality grid

        internal void OriginalityRecipeNames(ComboBox OriginalityRecipeNames)
        {
            nameOfRecipe.Sort();

            OriginalityRecipeNames.Items.Clear();

            for (int y = 0; y < nameOfRecipe.Count; y++)
            {
                OriginalityRecipeNames.Items.Add(nameOfRecipe[y]);

            }
        }

        //method of returning scaled quantity to original
        internal void originalQuantityValue(string nameToReset)
        {

            //output using the ingredient generic
            for (int reset = 0; reset < TheIngredients.Count; reset++)
            {

                //compare or check
                if (TheIngredients[reset].Contains(nameToReset))
                {
                    TheQuantity[reset] = OriginalQuantity[reset];
                }
            }
        }

        //add name of recipe to the combo box
        internal void clearRecipeName(ComboBox clearRecipeName)
        {
            nameOfRecipe.Sort();

            clearRecipeName.Items.Clear();

            for (int y = 0; y < nameOfRecipe.Count; y++)
            {
                clearRecipeName.Items.Add(nameOfRecipe[y]);

            }
        }

        // Method to check if the user clicks yes for clear then it will clear
        internal void YesClear(string text, ComboBox clearRecipeName)
        {

            text = clearRecipeName.Text;

            for (int clearRec = 0; clearRec < nameOfRecipe.Count; clearRec++)
            {
                if (nameOfRecipe.Contains(text))
                {

                    nameOfRecipe.Remove(nameOfRecipe[clearRec]);
                }
            }

            for (int RecipeToBeCleared = 0; RecipeToBeCleared < TheIngredients.Count; RecipeToBeCleared++)
            {

                //setting a condition that will check if the recipe name is found in the all the generics

                if (TheIngredients[RecipeToBeCleared].Contains(text) && TheQuantity[RecipeToBeCleared].Contains(text)
                     && TheMeasurements[RecipeToBeCleared].Contains(text)
                     && Thecalories[RecipeToBeCleared].Contains(text))
                {

                    //removing the the choosen recipe content

                    TheIngredients.Remove(TheIngredients[RecipeToBeCleared]);
                    TheQuantity.Remove(TheQuantity[RecipeToBeCleared]);
                    TheMeasurements.Remove(TheMeasurements[RecipeToBeCleared]);
                    Thecalories.Remove(Thecalories[RecipeToBeCleared]);
                    ThefoodGroups.Remove(ThefoodGroups[RecipeToBeCleared]);



                }
            }

            for (int stepClear = 0; stepClear < TheSteps.Count; stepClear++)
            {

                if (TheSteps[stepClear].Contains(text))
                {

                    TheSteps.Remove(TheSteps[stepClear]);

                    MessageBox.Show("Data is cleared");
                }


            }


        }

        //method to calculate the calories and display error message
        public int calculateTheSumOfCalories(int calculateTheCalories)
        {

            //Thecalories

            addTheCalories += calculateTheCalories;

            // checking if the user calories didn't exceed 300
            if (addTheCalories > 300)
            {
                MessageBox.Show("You have exceeded the maximum number of calories which is 300 The calories you have are  " + addTheCalories + "  this is not good for you your health ");

            }

            if (countCalculate == captureCalories)
            {
                // printing the the total number of calories


                MessageBox.Show("All calories added: " + addTheCalories);


            }

            //returning the calculation
            return addTheCalories;
        }

        //the filter display
        internal void filterDisplay(string  name)
        {
           
            for (int inputs = 0; inputs < ThefoodGroups.Count; inputs++)
            {
                //checking if the generics contains the selected recipe name and display on list view if contains the selected recipe name

                if ( ThefoodGroups[inputs].Contains(name) )

                {
                    //display the recipe content e.g the ingredients
                    addingForFilter.Add(ThefoodGroups[inputs].Replace(name, ""));
                    
                }
            }
            
        }
    }
}