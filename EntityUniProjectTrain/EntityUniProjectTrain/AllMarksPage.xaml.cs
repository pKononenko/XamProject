using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EntityUniProjectTrain
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllMarksPage : ContentPage
    {
        public AllMarksPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            string dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.DBFILENAME);
            using (EntityTodoDatabase db = new EntityTodoDatabase(dbPath))
            {
                friendsList.ItemsSource = db.Marks.ToList();
            }

            base.OnAppearing();
        }

        private async void CreateItem(object sender, EventArgs e)
        {
            Notation friend = new Notation();
            FriendPage friendPage = new FriendPage();
            friendPage.BindingContext = friend;
            await Navigation.PushAsync(friendPage);
        }

        private async void CreateMarkItem(object sender, EventArgs e)
        {
            Mark mark = new Mark();
            MarkPage markPage = new MarkPage();
            markPage.BindingContext = mark;
            await Navigation.PushAsync(markPage);
        }
    }
}