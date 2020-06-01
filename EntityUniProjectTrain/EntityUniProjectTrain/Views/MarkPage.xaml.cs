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
    public partial class MarkPage : ContentPage
    {
        string dbPath;

        public MarkPage()
        {
            InitializeComponent();

            // Для виклику методу GetDatabasePath на різних ОС
            // DependencyService потрібний для платформо-залежних реалізацій
            dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.DBFILENAME);
        }

        private async void SaveNote(object sender, EventArgs e)
        {
            var mark = (Mark)BindingContext;
            if (!String.IsNullOrEmpty(mark.MarkTitle) && !String.IsNullOrEmpty(mark.MarkType))
            {
                using (EntityTodoDatabase db = new EntityTodoDatabase(dbPath))
                {
                    if (mark.MarkId == 0)
                    {
                        db.Marks.Add(mark);
                    }
                    else
                    {
                        db.Marks.Update(mark);
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
            var mark = (Mark)BindingContext;
            try
            {
                using (EntityTodoDatabase db = new EntityTodoDatabase(dbPath))
                {
                    db.Marks.Remove(mark);
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