﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EntityUniProjectTrain
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DayPage : ContentPage
    {
        public DayPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            string dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.DBFILENAME);
            using (EntityTodoDatabase db = new EntityTodoDatabase(dbPath))
            {
                todayFriendsList.ItemsSource = db.Notations.Where(x => x.DateOfCreation >= DateTime.Today).OrderByDescending(x => x.DateOfCreation).ToList();
            }
            base.OnAppearing();
        }

        // Обробка вибору елементу
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Notation selectedFriend = (Notation)e.SelectedItem;
            FriendPage friendPage = new FriendPage(false);
            friendPage.BindingContext = selectedFriend;
            await Navigation.PushAsync(friendPage);
        }

        // Обробка натиснення на кнопку
        private async void CreateItem(object sender, EventArgs e)
        {
            Notation friend = new Notation();
            FriendPage friendPage = new FriendPage(true);
            friendPage.BindingContext = friend;
            await Navigation.PushAsync(friendPage);
        }

        private async void CreateMarkItem(object sender, EventArgs e)
        {
            Mark mark = new Mark();
            MarkPage markPage = new MarkPage(true);
            markPage.BindingContext = mark;
            await Navigation.PushAsync(markPage);
        }
    }
}