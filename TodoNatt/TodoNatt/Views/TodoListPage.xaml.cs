using System.Collections.ObjectModel;
using System.Windows.Input;
using TodoNatt.Models;

namespace TodoNatt.Views
{
    public partial class TodoListPage : ContentPage
    {
        public ObservableCollection<TodoItem> Items { get; set; } = new();
        public ICommand LoadItemsCommand { get; }

        public TodoListPage()
        {
            InitializeComponent();
            BindingContext = this;

            LoadItemsCommand = new Command(async () => await LoadItemsAsync());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadItemsAsync();
        }

        async Task LoadItemsAsync()
        {
            RefreshView.IsRefreshing = true;

            Items.Clear();
            var items = await App.Database.GetItemsAsync();
            foreach (var item in items)
            {
                Items.Add(item);
            }

            RefreshView.IsRefreshing = false;
        }

        async void OnItemSelected(object sender, EventArgs e)
        {
            if ((sender as Grid)?.BindingContext is not TodoItem item)
                return;

            var navigationParameter = new Dictionary<string, object>
            {
                { "Item", item }
            };
            await Shell.Current.GoToAsync(nameof(TodoItemPage), navigationParameter);
        }

        async void OnAddClicked(object sender, EventArgs e)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "Item", new TodoItem() }
            };
            await Shell.Current.GoToAsync(nameof(TodoItemPage), navigationParameter);
        }
    }
}
