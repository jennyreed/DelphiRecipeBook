using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;


namespace DelphiRecipeBook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipePage : ContentPage
    {
        public RecipePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetRecipeAsync();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(recipeEntry.Text) &&
                !string.IsNullOrWhiteSpace(authorEntry.Text) &&
                !string.IsNullOrWhiteSpace(ingrEntry.Text) &&
                !string.IsNullOrWhiteSpace(stepEntry.Text))
            {
                await App.Database.SaveRecipeAsync(new Recipe
                {
                    RecipeName = recipeEntry.Text,
                    Author = authorEntry.Text,
                    Ingredients = ingrEntry.Text,
                    Steps = stepEntry.Text,
                });

                await DisplayAlert("Success", "Person added Successfully", "OK");

                recipeEntry.Text = authorEntry.Text = ingrEntry.Text = stepEntry.Text = string.Empty;
                collectionView.ItemsSource = await
                    App.Database.GetRecipeAsync();
            }

        }

        Recipe lastSelection;
        void collectionView_SelectionChanged(object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            lastSelection = e.CurrentSelection[0] as Recipe;
            recipeEntry.Text = lastSelection.RecipeName;
            authorEntry.Text = lastSelection.Author;
            ingrEntry.Text = lastSelection.Ingredients;
            stepEntry.Text = lastSelection.Steps;
        }



        async void dltButton_Clicked(object sender, EventArgs e)
        {
            if (lastSelection != null)
            {

                await App.Database.DeleteRecipeAsync(lastSelection);

                collectionView.ItemsSource = await
                    App.Database.GetRecipeAsync();

                recipeEntry.Text = "";
                authorEntry.Text = "";
                ingrEntry.Text = "";
                stepEntry.Text = "";
            }

        }

        async void upButton_Clicked(object sender, EventArgs e)
        {
            if (lastSelection != null)
            {
                lastSelection.RecipeName = recipeEntry.Text;
                lastSelection.Author = authorEntry.Text;
                lastSelection.Ingredients = ingrEntry.Text;
                lastSelection.Steps = stepEntry.Text;

                await App.Database.UpdateRecipeAsync(lastSelection);

                collectionView.ItemsSource = await
                    App.Database.GetRecipeAsync();
            }
        }
    }
}
