// See https://aka.ms/new-console-template for more information
// Importing necessary namespace
using System;

// Definition of the Ingredient class
public class Ingredient
{
    // Properties to store ingredient details
    public string Name { get; set; }
    public double Quantity { get; set; }
    public string Unit { get; set; }
    public double OriginalQuantity { get; private set; }

    // Constructor to initialize Ingredient object
    public Ingredient(string name, double quantity, string unit)
    {
        Name = name;
        Quantity = quantity;
        Unit = unit;
        OriginalQuantity = quantity; // Store original quantity for reset
    }
}

// Definition of the Recipe class
public class Recipe
{
    // Properties to store recipe details
    public string Name { get; set; }
    public Ingredient[] Ingredients { get; set; }
    public string[] Steps { get; set; }

    // Constructor to initialize Recipe object with provided ingredient and step counts
    public Recipe(int ingredientCount, int stepCount)
    {
        // Initialize ingredient and step arrays based on provided count
        Ingredients = new Ingredient[ingredientCount];
        Steps = new string[stepCount];
    }

    // Method to add ingredient to the recipe
    public void AddIngredient(string name, double quantity, string unit)
    {
        // Find first empty slot in the ingredient array and add the ingredient
        for (int i = 0; i < Ingredients.Length; i++)
        {
            if (Ingredients[i] == null)
            {
                Ingredients[i] = new Ingredient(name, quantity, unit);
                return;
            }
        }
    }

    // Method to add step to the recipe
    public void AddStep(string description)
    {
        // Find first empty slot in the steps array and add the step description
        for (int i = 0; i < Steps.Length; i++)
        {
            if (Steps[i] == null)
            {
                Steps[i] = description;
                return;
            }
        }
    }

    // Method to display the recipe details
    public void DisplayRecipe()
    {
        Console.WriteLine("Recipe: {0}", Name);
        Console.WriteLine("Ingredients:");
        foreach (var ingredient in Ingredients)
        {
            if (ingredient != null)
            {
                Console.WriteLine("- {0} {1} {2}", ingredient.Quantity, ingredient.Unit, ingredient.Name);
            }
        }
        Console.WriteLine("Steps:");
        for (int i = 0; i < Steps.Length; i++)
        {
            if (Steps[i] != null)
            {
                Console.WriteLine("{0}. {1}", i + 1, Steps[i]);
            }
        }
    }

    // Method to scale the recipe by a given factor
    public void ScaleRecipe(double factor)
    {
        // Update quantity of each ingredient by multiplying with the factor
        foreach (var ingredient in Ingredients)
        {
            if (ingredient != null)
            {
                ingredient.Quantity *= factor;
            }
        }
    }

    // Method to reset quantities of all ingredients to their original values
    public void ResetQuantities()
    {
        // Reset quantity of each ingredient to its original value
        foreach (var ingredient in Ingredients)
        {
            if (ingredient != null)
            {
                ingredient.Quantity = ingredient.OriginalQuantity;
            }
        }
    }
}

// Main class
class Program
{
    static void Main(string[] args)
    {
        Recipe recipe = null;

        // Main program loop
        while (true)
        {
            // Display menu options
            Console.WriteLine("\n***Recipe Manager***\n");
            Console.WriteLine("1. Create New Recipe");
            Console.WriteLine("2. Display Recipe");
            Console.WriteLine("3. Scale Recipe");
            Console.WriteLine("4. Reset Quantities");
            Console.WriteLine("5. Clear Recipe");
            Console.WriteLine("6. Exit\n");

            // Read user input
            string choice = Console.ReadLine();

            // Process user choice
            switch (choice)
            {
                case "1":
                    // Create a new recipe
                    CreateRecipe(out recipe);
                    break;
                case "2":
                    // Display recipe details
                    if (recipe != null)
                    {
                        recipe.DisplayRecipe();
                    }
                    else
                    {
                        Console.WriteLine("No recipe created yet.\n");
                    }
                    break;
                case "3":
                    // Scale the recipe
                    if (recipe != null)
                    {
                        Console.Write("Enter the scaling factor: \n");
                        string scaleFactorInput = Console.ReadLine();
                        if (double.TryParse(scaleFactorInput, out double scaleFactor))
                        {
                            recipe.ScaleRecipe(scaleFactor);
                        }
                        else
                        {
                            Console.WriteLine("Invalid scaling factor.\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No recipe to scale.\n");
                    }
                    break;
                case "4":
                    // Reset ingredient quantities
                    if (recipe != null)
                    {
                        recipe.ResetQuantities();
                    }
                    else
                    {
                        Console.WriteLine("No recipe to reset.\n");
                    }
                    break;
                case "5":
                    // Clear the recipe
                    recipe = null;
                    Console.WriteLine("Recipe cleared.\n");
                    break;
                case "6":
                    // Exit the program
                    Console.WriteLine("Bye Bye.\n");
                    return;
            }
        }
    }

    // Method to create a new recipe
    private static void CreateRecipe(out Recipe recipe)
    {
        Console.Write("Enter the recipe name: ");
        string name = Console.ReadLine();

        Console.Write("Enter the number of ingredients: ");
        string ingredientCountInput = Console.ReadLine();
        if (int.TryParse(ingredientCountInput, out int ingredientCount))
        {
            Console.Write("Enter the number of steps: ");
            string stepCountInput = Console.ReadLine();
            if (int.TryParse(stepCountInput, out int stepCount))
            {
                recipe = new Recipe(ingredientCount, stepCount);
                recipe.Name = name;

                // Add ingredients to the recipe
                for (int i = 0; i < ingredientCount; i++)
                {
                    Console.WriteLine("Enter ingredient #{0} details:", i + 1);
                    Console.Write("Name: ");
                    string ingredientName = Console.ReadLine();
                    Console.Write("Quantity: ");
                    string ingredientQuantityInput = Console.ReadLine();
                    double ingredientQuantity;
                    if (double.TryParse(ingredientQuantityInput, out ingredientQuantity))
                    {
                        Console.Write("Unit: ");
                        string ingredientUnit = Console.ReadLine();
                        recipe.AddIngredient(ingredientName, ingredientQuantity, ingredientUnit);
                    }
                    else
                    {
                        Console.WriteLine("Invalid ingredient quantity.");
                        i--;
                    }
                }

                // Add steps to the recipe
                for (int i = 0; i < stepCount; i++)
                {
                    Console.Write("Enter step #{0} description: ", i + 1);
                    string stepDescription = Console.ReadLine();
                    recipe.AddStep(stepDescription);
                }










            }
            else
            {
                Console.WriteLine("Invalid number of steps.");
                recipe = null;
            }
        }
        else
        {
            Console.WriteLine("Invalid number of ingredients.");
            recipe = null;
        }
    }
}

