
  Step 1: Open VSCode
- Launch Visual Studio Code on your computer.

 Step 2: Create a New File
- Go to `File > New File` from the menu, or use the shortcut `Ctrl+N` to create a new file.


This C# code is a console application for managing recipes. Let's go through the code and understand its functionality:
Classes:
1. Ingredient: Represents an ingredient in a recipe. It has properties like Name, Quantity, Unit, Calories, and FoodGroup.
2. Recipe: Represents a recipe. It contains a RecipeID, a list of Ingredients, a list of Steps, and a delegate for notifying calorie exceedance. It has methods for adding ingredients, adding steps, displaying the recipe, scaling the recipe, resetting ingredient quantities, clearing the recipe, calculating total calories, and checking for calorie exceedance.
3. RecipeManager: Manages a list of recipes. It provides methods for adding a recipe, displaying all recipes, and displaying a recipe by its name.


Main Method (Program. Main()):c
1. Initialization: It initializes a RecipeManager object and displays a welcome message.
2. Menu Loop: It presents a menu to the user with options to add a recipe, display all
 Step 3: Write Your README
- Start typing the content for your README. A README typically includes information like:
  Step 1: Open VSCode
- Launch Visual Studio Code on your computer.

 Step 2: Create a New File
- Go to `File > New File` from the menu, or use the shortcut `Ctrl+N` to create a new file.


This C# code is a console application for managing recipes. Let's go through the code and understand its functionality:
Classes:
1. Ingredient: Represents an ingredient in a recipe. It has properties like Name, Quantity, Unit, Calories, and FoodGroup.
2. Recipe: Represents a recipe. It contains a RecipeID, a list of Ingredients, a list of Steps, and a delegate for notifying calorie exceedance. It has methods for adding ingredients, adding steps, displaying the recipe, scaling the recipe, resetting ingredient quantities, clearing the recipe, calculating total calories, and checking for calorie exceedance.
3. RecipeManager: Manages a list of recipes. It provides methods for adding a recipe, displaying all recipes, and displaying a recipe by its name.
Main Method (Program. Main()):
1. Initialization: It initializes a RecipeManager object and displays a welcome message.
2. Menu Loop: It presents a menu to the user with options to add a recipe, display all
 Step 3: Write Your README
- Start typing the content for your README. A README typically includes information like:
  - Name of the Recipe_Manager
  - Installation Instructions
  - Usage
  - Contributing Guidelines
  - License

 Step 4: Save the File as README.md
- Go to `File > Save As`, or use the shortcut `Ctrl+S`.
- Name your file `README.md` to ensure it is recognized as a Markdown file.

 Step 5: Open Integrated Terminal in VSCode
- Use the shortcut `Ctrl+`` to open the integrated terminal.

 Step 6: Initialize a Git Repository
- Type `git init` to initialize a new git repository.

 Step 7: Add README.md to the Repository
- Type `git add README.md` to stage your README file for commit.

 Step 8: Commit the File
- Type `git commit -m "Add README"` to commit the file with a message.

 Step 9: Link Your GitHub Repository
-[e, link your local repository to GitHub with `git remote add origin YOUR_REPOSITORY_URL`.](https://github.com/ST10368662/Recipe_Manager)


 Step 10: Push to GitHub
- Type `git push -u origin master` to push your commits to GitHub.

 Step 11: Verify Upload
- Go to your GitHub repository and refresh the page. You should now see your README.md file uploaded.



  Step 1: Open VSCode
- Launch Visual Studio Code on your computer.

 Step 2: Create a New File
- Go to `File > New File` from the menu, or use the shortcut `Ctrl+N` to create a new file.


This C# code is a console application for managing recipes. Let's go through the code and understand its functionality:
Classes:
1. Ingredient: Represents an ingredient in a recipe. It has properties like Name, Quantity, Unit, Calories, and FoodGroup.
2. Recipe: Represents a recipe. It contains a RecipeID, a list of Ingredients, a list of Steps, and a delegate for notifying calorie exceedance. It has methods for adding ingredients, adding steps, displaying the recipe, scaling the recipe, resetting ingredient quantities, clearing the recipe, calculating total calories, and checking for calorie exceedance.
3. RecipeManager: Manages a list of recipes. It provides methods for adding a recipe, displaying all recipes, and displaying a recipe by its name.
Main Method (Program. Main()):
1. Initialization: It initializes a RecipeManager object and displays a welcome message.
2. Menu Loop: It presents a menu to the user with options to add a recipe, display all
 Step 3: Write Your README
- Start typing the content for your README. A README typically includes information like:
  - Name of the Recipe_Manager
  - Installation Instructions
  - Usage
  - Contributing Guidelines
  - License

Open the project:

Open the solution file (RecipeManagement.sln) in Visual Studio.
Build the project:

Build the project using Visual Studio to restore dependencies and compile the code.
Run the application:

Start debugging (F5) to run the application.
Usage
Capturing Recipe Name and Ingredients:

Enter the recipe name and the number of ingredients.
Fill in the details for each ingredient, including name, quantity, measurement, calories, and food group.
Click "Capture" to store the ingredient details.
Capturing Steps:

After capturing ingredients, enter the number of steps.
Fill in each step description.
Click "Capture" to store each step.
Displaying Recipes:

Select a recipe from the combo box to display its details, including ingredients and steps.
Scaling Ingredients:

Select a recipe and a scaling factor to adjust the quantities of the ingredients.
Clearing Recipes:

Select a recipe to clear from the stored list.
Filtering by Food Groups:

Enter a food group to filter and display recipes containing ingredients from that food group.
Classes and Methods
capturing Class
Fields:

name of Recipe: Stores names of the recipes.
The Ingredients: Stores ingredient names.
The Quantity: Stores quantities of ingredients.
The Measurements: Stores measurement units of ingredients.
The calories: Stores calories for each ingredient.
The food Groups: Stores food group information.
The Steps: Stores steps of the recipe.
Original Quantity: Stores original quantities before scaling.
adding For Filter: Stores filtered food groups.
Methods:

count: Captures recipe name and number of ingredients.
captures: Captures ingredient details.
steps Number Count: Captures number of steps.
steps Storing: Stores step descriptions.
load: Loads recipe names into a combo box.
list Box Display: Displays recipe details in a ListView.
scal Recipe Name: Loads recipe names for scaling.
listBox Scale: Displays scaled recipe details.
Originality Recipe Names: Loads recipe names for resetting to original quantities.
original Quantity Value: Resets ingredient quantities to original values.
clear Recipe Name: Loads recipe names for clearing.
Yes Clear: Clears selected recipe.
calculate The Sum Of Calories: Calculates and sums the calories of ingredients.
filter Display: Filters recipes by food groups.
Error Handling
The application includes error handling for common issues such as:
Empty input fields.
Non-numeric input in numeric fields.
Exceeding calorie limits.
Appropriate error messages are displayed using message boxes to guide the user in correcting the input.
 
 
 Step 4: Save the File as README.md
- Go to `File > Save As`, or use the shortcut `Ctrl+S`.
- Name your file `README.md` to ensure it is recognized as a Markdown file.

 Step 5: Open Integrated Terminal in VSCode
- Use the shortcut `Ctrl+`` to open the integrated terminal.

 Step 6: Initialize a Git Repository
- Type `git init` to initialize a new git repository.

 Step 7: Add README.md to the Repository
- Type `git add README.md` to stage your README file for commit.

 Step 8: Commit the File
- Type `git commit -m "Add README"` to commit the file with a message.

 Step 9: Link Your GitHub Repository
-[e, link your local repository to GitHub with `git remote add origin YOUR_REPOSITORY_URL`.](https://github.com/ST10368662/Recipe_Manager)


 Step 10: Push to GitHub
- Type `git push -u origin master` to push your commits to GitHub.

 Step 11: Verify Upload
- Go to your GitHub repository and refresh the page. You should now see your README.md file uploaded.



  - Name of the Recipe_Manager
  - Installation Instructions
  - Usage
  - Contributing Guidelines
  - License

 Step 4: Save the File as README.md
- Go to `File > Save As`, or use the shortcut `Ctrl+S`.
- Name your file `README.md` to ensure it is recognized as a Markdown file.

 Step 5: Open Integrated Terminal in VSCode
- Use the shortcut `Ctrl+`` to open the integrated terminal.

 Step 6: Initialize a Git Repository
- Type `git init` to initialize a new git repository.

 Step 7: Add README.md to the Repository
- Type `git add README.md` to stage your README file for commit.

 Step 8: Commit the File
- Type `git commit -m "Add README"` to commit the file with a message.

 Step 9: Link Your GitHub Repository
-[e, link your local repository to GitHub with `git remote add origin YOUR_REPOSITORY_URL`.](https://github.com/ST10368662/Recipe_Manager)


 Step 10: Push to GitHub
- Type `git push -u origin master` to push your commits to GitHub.

 Step 11: Verify Upload
- Go to your GitHub repository and refresh the page. You should now see your README.md file uploaded.


