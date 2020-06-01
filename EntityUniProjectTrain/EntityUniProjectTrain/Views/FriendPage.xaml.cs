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
    public partial class FriendPage : ContentPage
    {
        string dbPath;

        public FriendPage()
        {
            InitializeComponent();

            // Для виклику методу GetDatabasePath на різних ОС
            // DependencyService потрібний для платформо-залежних реалізацій
            dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.DBFILENAME);
        }

        private async void SaveNote(object sender, EventArgs e)
        {
            var notation = (Notation)BindingContext;
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