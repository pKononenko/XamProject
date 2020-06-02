using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EntityUniProjectTrain
{
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage

    {
        public MainPage()
        {
            InitializeComponent();
            Detail = new NavigationPage(new DayPage());
            IsPresented = true;
        }

        /*private async void CreateItem(object sender, EventArgs e)
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
        }*/

        private void OpenAllNotations(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new AllNotationsPage());
            IsPresented = false;
        }
    
        private void OpenAllMarks(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new AllMarksPage());
            IsPresented = false;
        }
    
        private void OpenDay(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new DayPage());
            IsPresented = false;
        }

    }
}
