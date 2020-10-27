using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Poznamky.Models;


namespace Poznamky
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetNotesAsync();
        }

        async void OnNoteAdd(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NotePage
            {
                BindingContext = new Note()
            });
        }
        async void OnNoteSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new NotePage
                {
                    BindingContext = e.SelectedItem as Note
                });
            }
        }
    }
}
