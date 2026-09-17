using TodoNatt.Models;

namespace TodoNatt.Views
{
    [QueryProperty(nameof(Item), "Item")]
    public partial class TodoItemPage : ContentPage
    {
        TodoItem item;
        public TodoItem Item
        {
            get => item;
            set
            {
                item = value;
                BindingContext = item;
            }
        }

        public TodoItemPage()
        {
            InitializeComponent();
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Item.Name))
            {
                await DisplayAlert("Requerido", "Por favor ingresa un nombre para la tarea.", "OK");
                return;
            }

            await App.Database.SaveItemAsync(Item);
            await Shell.Current.GoToAsync("..");
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            if (Item.ID != 0)
            {
                await App.Database.DeleteItemAsync(Item);
            }
            await Shell.Current.GoToAsync("..");
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}