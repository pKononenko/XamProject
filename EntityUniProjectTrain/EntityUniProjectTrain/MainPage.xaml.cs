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
    // public partial class MainPage : ContentPage
    // {
    //     private MainPage()
    //     {
    //         InitializeComponent();
    //     }
    //
    //     private static MainPage _instance;
    //     // Обробка змін при появі
    //
    //     public static MainPage GetInstance()
    //     {
    //         if (_instance == null)
    //         {
    //             _instance = new MainPage();
    //         }
    //         return _instance;
    //     }
    //
    //     protected override void OnAppearing()
    //     {
    //         string dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.DBFILENAME);
    //         using (EntityTodoDatabase db = new EntityTodoDatabase(dbPath))
    //         {
    //             friendsList.ItemsSource = db.Notations.OrderByDescending(x => x.DateOfCreation).ToList();
    //         }
    //         base.OnAppearing();
    //     }
    //
    //     // Обробка вибору елементу
    //     private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    //     {
    //         Notation selectedFriend = (Notation)e.SelectedItem;
    //         FriendPage friendPage = new FriendPage();
    //         friendPage.BindingContext = selectedFriend;
    //         await Navigation.PushAsync(friendPage);
    //     }
    //
    //     // Обробка натиснення на кнопку
    //     private async void CreateItem(object sender, EventArgs e)
    //     {
    //         Notation friend = new Notation();
    //         FriendPage friendPage = new FriendPage();
    //         friendPage.BindingContext = friend;
    //         await Navigation.PushAsync(friendPage);
    //     }
    //
    //     private async void CreateMarkItem(object sender, EventArgs e)
    //     {
    //         Mark mark = new Mark();
    //         MarkPage markPage = new MarkPage();
    //         markPage.BindingContext = mark;
    //         await Navigation.PushAsync(markPage);
    //     }
    // }
    public partial class MainPage : MasterDetailPage

    {
    private MainPage()
    {
        InitializeComponent();
        Detail = new NavigationPage(new AllNotationsPage());
        IsPresented = true;
    }

    private static MainPage _instance;
    // Обробка змін при появі

    public static MainPage GetInstance()
    {
        if (_instance == null)
        {
            _instance = new MainPage();
        }

        return _instance;
    }

    protected override void OnAppearing()
    {
        string dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.DBFILENAME);
        using (EntityTodoDatabase db = new EntityTodoDatabase(dbPath))
        {
            friendsList.ItemsSource = db.Notations.OrderByDescending(x => x.DateOfCreation).ToList();
        }

        base.OnAppearing();
    }

    // Обробка вибору елементу
    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        Notation selectedFriend = (Notation) e.SelectedItem;
        FriendPage friendPage = new FriendPage();
        friendPage.BindingContext = selectedFriend;
        await Navigation.PushAsync(friendPage);
    }

    // Обробка натиснення на кнопку
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
