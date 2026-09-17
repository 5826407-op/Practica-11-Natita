using TodoNatt.Views;

namespace TodoNatt
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TodoListPage), typeof(TodoListPage));
            Routing.RegisterRoute(nameof(TodoItemPage), typeof(TodoItemPage));
        }
    }
}