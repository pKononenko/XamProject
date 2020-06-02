using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EntityUniProjectTrain
{
    // Ініціалізація стартової сторінки та БД
    public partial class App : Application
    {
        public const string DBFILENAME = "notationsapp.db";

        public App()
        {
            InitializeComponent();

            // Для виклику методу GetDatabasePath на різних ОС
            // DependencyService потрібний для платформо-залежних реалізацій
            string dbPath = DependencyService.Get<IPath>().GetDatabasePath(DBFILENAME);

            using (var db = new EntityTodoDatabase(dbPath))
            {
                // Виконати дії, якщо БД не існує
                db.Database.EnsureCreated(); // ~create or ignore
                if (db.Notations.Count() == 0)
                {
                    db.Notations.Add(new Notation { NotationName = "Buba",  NotationType = "Note", DateOfCreation = DateTime.Now, NotationText = "asdfasdfsadfasfsdf" }); // ~insert
                    db.SaveChanges(); // ~commit
                }
            }

            // MainPage = new NavigationPage(new MainPage());
            // var nav = new NavigationPage(new MainPage());
            MainPage MainPageInstance = EntityUniProjectTrain.MainPage.GetInstance();
            var nav = new NavigationPage(MainPageInstance);
            nav.BarBackgroundColor = (Color)App.Current.Resources["primaryIndianRed"];
            nav.BarTextColor = Color.White;
            MainPage = nav;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
