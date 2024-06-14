using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts;

namespace poe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //object
        capturing details = new capturing();

        public SeriesCollection SeriesCollection { get;  set; }

        public MainWindow()
        {
            InitializeComponent();
        }

       

        //when clicking the capture button on the menu
        private void CaptureIngrideint_Click(object sender, RoutedEventArgs e)
        {
            mainGrid.Visibility = Visibility.Hidden;
            captureIngredeint_Grid.Visibility = Visibility.Visible;
            display_Grid.Visibility = Visibility.Hidden;
            scale_Grid.Visibility = Visibility.Hidden;
            orginality_Grid.Visibility = Visibility.Hidden;
            clear_Grid.Visibility = Visibility.Hidden;

        }

        //on the capture page, the capturing of recipe name and number of ingredeints
        private void ToCaptureRecipeData_Click(object sender, RoutedEventArgs e)
        {

            details.count(captureRecipeName.Text, ingrendeintCount.Text, TheNameOfRecipe, countingIngredeints, IngredeintData, captureIngredient);

            captureRecipeName.Clear();
            ingrendeintCount.Clear();
        }

        //capturing the ingredients data
        private void capture_Click(object sender, RoutedEventArgs e)
        {

            details.captures(Nameingredients.Text, quanitityIngredeint.Text, measurementIngredeint.Text, foodgroupIngedient.Text, caloriesIngredeint.Text, countingIngredeints, captureIngredient, check);

            //if the check label content is true then the ingredient data gets cleared

            if (check.Content == "true")
            {
                Nameingredients.Clear();
                quanitityIngredeint.Clear();
                measurementIngredeint.Clear();
                foodgroupIngedient.SelectedValue = "";
                caloriesIngredeint.Clear();

            }

            if (captureIngredient.Content == "Steps")
            {

                stepsGrid.Visibility = Visibility.Visible;

            }


        }

        //captuing the number of steps
        private void numberOfSteps_Click(object sender, RoutedEventArgs e)
        {
            details.stepsNumberCount(theNumberOfSteps.Text, captureSteps, stepCount);


        }

        //storing the steps
        private void StepsCapture_click(object sender, RoutedEventArgs e)
        {

            details.stepsStoring(theNumberOfSteps.Text, stepCount, stepContent.Text, captureSteps, stepsGrid, captureIngredeint_Grid, IngredeintData);


            stepContent.Clear();
            theNumberOfSteps.Clear();

            mainGrid.Visibility = Visibility.Visible;


        }

        //displaying the recipe
        private void Display_Click(object sender, RoutedEventArgs e)
        {
            captureIngredeint_Grid.Visibility = Visibility.Hidden;
            display_Grid.Visibility = Visibility.Visible;
            scale_Grid.Visibility = Visibility.Hidden;
            orginality_Grid.Visibility = Visibility.Hidden;
            clear_Grid.Visibility = Visibility.Hidden;


            details.load(displayRecipeNames);

        }

        //viewing the recipe
        private void ViewRecipe_Click(object sender, RoutedEventArgs e)
        {
            details.listBoxDisplay(displayRecipeNames.Text, DisplayOfIngredeintData);
          
        }

        //clearing the list view where the recipes displays
        private void clearListView_Click(object sender, RoutedEventArgs e)
        {
            DisplayOfIngredeintData.Items.Clear();
        }

        //back to menu button when on display page
        private void BackToMenuOnDisplay_Click(object sender, RoutedEventArgs e)
        {
            display_Grid.Visibility = Visibility.Hidden;
            mainGrid.Visibility = Visibility.Visible;

            DisplayOfIngredeintData.Items.Clear();
        }

        //scaling recipe
        private void Scale_click(object sender, RoutedEventArgs e)
        {
            captureIngredeint_Grid.Visibility = Visibility.Hidden;
            display_Grid.Visibility = Visibility.Hidden;
            scale_Grid.Visibility = Visibility.Visible;
            orginality_Grid.Visibility = Visibility.Hidden;
            clear_Grid.Visibility = Visibility.Hidden;

            details.scalRecipeName(ScalingRecipeNames);

        }

        //viewing the scaled recipe
        private void viewScale_Click(object sender, RoutedEventArgs e)
        {
            details.listBoxScale(ScalingRecipeNames.Text, ScaledIngredeintData, CaluculationScale, ScalingRecipeNames);
           

        }

        //clearing the recipe on listview, where the recipe displays
        private void CloseScaledeRecipe_Click(object sender, RoutedEventArgs e)
        {
            ScaledIngredeintData.Items.Clear();
        }

        //back to menu when on the scale page
        private void BackToMenuOnScale_Click(object sender, RoutedEventArgs e)
        {
            scale_Grid.Visibility = Visibility.Hidden;
            mainGrid.Visibility = Visibility.Visible;
            ScaledIngredeintData.Items.Clear();
        }

        //setting value to it original

        private void originality_click(object sender, RoutedEventArgs e)
        {
            captureIngredeint_Grid.Visibility = Visibility.Hidden;
            display_Grid.Visibility = Visibility.Hidden;
            scale_Grid.Visibility = Visibility.Hidden;
            orginality_Grid.Visibility = Visibility.Visible;
            clear_Grid.Visibility = Visibility.Hidden;

            details.OriginalityRecipeNames(OriginalityRecipeNames);
        }

        //button to set to values original
        private void setToOriginal_click(object sender, RoutedEventArgs e)
        {

            details.originalQuantityValue(quanitityIngredeint.Text);

            //message box to tell the user if their data has been reset

            MessageBox.Show("The data is reset to original for chosen recipe");

        }

        //back to menu button when on originality page
        private void BackToMenuOnOriginality_Click(object sender, RoutedEventArgs e)
        {
            orginality_Grid.Visibility = Visibility.Hidden;
            mainGrid.Visibility = Visibility.Visible;
        }

        //clearing the recipe
        private void clear_click(object sender, RoutedEventArgs e)
        {
            captureIngredeint_Grid.Visibility = Visibility.Hidden;
            display_Grid.Visibility = Visibility.Hidden;
            scale_Grid.Visibility = Visibility.Hidden;
            orginality_Grid.Visibility = Visibility.Hidden;
            clear_Grid.Visibility = Visibility.Visible;

            details.clearRecipeName(clearRecipeName);

        }

        //the erase button click
        private void Erase_click(object sender, RoutedEventArgs e)
        {
            Sure.Visibility = Visibility.Visible;
            Yes.Visibility = Visibility.Visible;
            No.Visibility = Visibility.Visible;

        }

        //the yes click button
        private void Yes_click(object sender, RoutedEventArgs e)
        {
            details.YesClear(clearRecipeName.Text, clearRecipeName);
            MessageBox.Show("Data has be cleared");
        }

        //on clear, if user selects no then no data will be cleared 
        private void No_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Data is not cleared");
        }

        //back to menu when on the clear page
        private void BackToMenuOnClear_Click(object sender, RoutedEventArgs e)
        {
            clear_Grid.Visibility = Visibility.Hidden;
            Sure.Visibility = Visibility.Hidden;
            Yes.Visibility = Visibility.Hidden;
            No.Visibility = Visibility.Hidden;
            mainGrid.Visibility = Visibility.Visible;
        }

        //if user choose to exit on the menu
        private void exit_click(object sender, RoutedEventArgs e)
        {

            Close();

        }

        //add to filter button function
        private void addToFilter_Click(object sender, RoutedEventArgs e)
        {
            details.filterDisplay(displayRecipeNames.Text );
            MessageBox.Show("Recipe added to filter now view it");
        }

        //viewing the filter button function
        private void filterView_Click(object sender, RoutedEventArgs e)
        {
            mainGrid.Visibility = Visibility.Hidden;
            captureIngredeint_Grid.Visibility = Visibility.Hidden;
            display_Grid.Visibility = Visibility.Hidden;
            scale_Grid.Visibility = Visibility.Hidden;
            orginality_Grid.Visibility = Visibility.Hidden;
            clear_Grid.Visibility = Visibility.Hidden;
            PIE.Visibility = Visibility.Visible;


            int one = 0;
            int two = 0;
            int three = 0;
            int four = 0;
            int five = 0;
            int six = 0;
            int seven = 0; 
            int eight = 0;



            for (int u = 0; u < details.addingForFilter.Count; u++)
            {


                if (details.addingForFilter[u].Equals("Starchy foods"))
                {
                    one += 1;
                }
                else if (details.addingForFilter[u].Equals("Vegetables and fruits"))
                {
                    two += 1;
                }
                else if (details.addingForFilter[u].Equals("Dry beans, peas, lentils and soya"))
                {
                    three += 1;
                }
                else if (details.addingForFilter[u].Equals("Chicken, fish, meat and eggs"))
                {
                    four += 1;
                }
                else if (details.addingForFilter[u].Equals("Milk and dairy products"))
                {
                    five += 1;
                }
                else if (details.addingForFilter[u].Equals("Fats and oil"))
                {
                    six += 1;
                }
                else if (details.addingForFilter[u].Equals("Water"))
                {
                    seven += 1;
                }
                else if (details.addingForFilter[u].Equals("NOT SURE")) {
                    eight += 1; 
                }

            }

            SeriesCollection = new SeriesCollection
            {


                new PieSeries
                {

                    Title = "Starchy foods",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(one) },
                    DataLabels = true
                },
                  new PieSeries
                {

                    Title = "Vegetables and fruits",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(two) },
                    DataLabels = true
                },
                    new PieSeries
                {

                    Title = "Dry beans, peas, lentils and soya",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(three) },
                    DataLabels = true
                },
                      new PieSeries
                {

                    Title = "Chicken, fish, meat and eggs",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(four)},

                    DataLabels = true
                },
                      new PieSeries
                      {
                          Title = "Milk and dairy products",
                         Values = new ChartValues<ObservableValue> { new ObservableValue(five)},

                    DataLabels = true
                      },

                        new PieSeries
                      {
                          Title = "Fats and oil",
                         Values = new ChartValues<ObservableValue> { new ObservableValue(six)},

                    DataLabels = true
                      },
                          new PieSeries
                      {
                          Title = "Water",
                         Values = new ChartValues<ObservableValue> { new ObservableValue(seven)},

                    DataLabels = true
                      },
                            new PieSeries
                      {
                          Title = "NOT SURE",
                         Values = new ChartValues<ObservableValue> { new ObservableValue(eight)},

                    DataLabels = true
                      }



            };

            DataContext = this;


        }
        //back to menu on the display filter button
        private void backToDisplay_Click(object sender, RoutedEventArgs e)
        {
            PIE.Visibility = Visibility.Hidden;
            display_Grid.Visibility = Visibility.Visible;

            details.addingForFilter.Clear();
            DataContext = null;

        }
    }
}
