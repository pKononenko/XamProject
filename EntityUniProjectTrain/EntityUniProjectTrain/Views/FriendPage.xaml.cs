using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EntityUniProjectTrain
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FriendPage : ContentPage
    {
        string dbPath;

        public FriendPage(bool visibility)
        {
            InitializeComponent();
            
            // Для виклику методу GetDatabasePath на різних ОС
            // DependencyService потрібний для платформо-залежних реалізацій
            dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.DBFILENAME);

            DeadlineDate.MinimumDate = DateTime.Today;
            DeadlineTime.Time = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, 0);

            picker.IsEnabled = visibility;
        }

        /*private void pickerDateSelected(object sender, DateChangedEventArgs e)
        {
            datePickerPicked = e.NewDate;
        }

        private void pickerTimeSelected(object sender, PropertyChangedEventArgs args)
        {
            var timePicked = args.Time;
            timePickerPicked = timePicked;
        }*/

        private async void SaveNote(object sender, EventArgs e)
        {
            DateTime datePickerPicked = DeadlineDate.Date;
            TimeSpan timePickerPicked = DeadlineTime.Time;

            var notation = (Notation)BindingContext;
            notation.Deadline = new DateTime(datePickerPicked.Year, datePickerPicked.Month, datePickerPicked.Day, timePickerPicked.Hours, timePickerPicked.Minutes, 0);

            if (!String.IsNullOrEmpty(notation.NotationName) && !String.IsNullOrEmpty(notation.NotationType))
            {
                using (EntityTodoDatabase db = new EntityTodoDatabase(dbPath))
                {
                    if (notation.NotationId == 0)
                    {
                        db.Notations.Add(notation);
                    }
                    else
                    {
                        db.Notations.Update(notation);
                    }
                    db.SaveChanges();
                }
                await this.Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Попередження", "Вкажіть ім'я та тип", "Ок");
            }
        }

        private void pickerSelectedIndex(object sender, EventArgs e)
        {
            var notation = (Notation)BindingContext;

            if (notation.NotationType == "Note" || notation.NotationType == null)
            {
                EventTaskVisible.IsVisible = false;
            }
            else
            {
                EventTaskVisible.IsVisible = true;
            }
        }

        private async void DeleteNote(object sender, EventArgs e)
        {
            var notation = (Notation)BindingContext;
            try
            {
                using (EntityTodoDatabase db = new EntityTodoDatabase(dbPath))
                {
                    db.Notations.Remove(notation);
                    db.SaveChanges();
                }
                await this.Navigation.PopAsync();
            }
            catch
            {
                bool answer = await DisplayAlert("Попередження", "Видалення не можливе (задачі або події не існує)", "Продовжити", "Вийти");
                if (!answer)
                {
                    await this.Navigation.PopAsync();
                }
            }
        }
    }
}