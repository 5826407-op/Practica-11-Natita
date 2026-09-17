using TodoNatt.Data;

namespace TodoNatt
{
    public partial class App : Application
    {
        static TodoItemDatabase database;

        public static TodoItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new TodoItemDatabase();
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}