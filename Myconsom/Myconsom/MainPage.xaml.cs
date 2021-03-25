using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using Myconsom.Models;

namespace Myconsom
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
           
        }

        private async void Register(object sender, EventArgs e)
        {
            DateTime dt =  datePicker.Date;
            int electHp = Convert.ToInt32(NewElectHp.Text);
            int electHc = Convert.ToInt32(NewElectHc.Text);
            int gaz = Convert.ToInt32(NewGaz.Text);
            double eau = Convert.ToDouble(NewEau.Text);
            Reference ref1;


            if (electHc != 0 && electHp != 0 && gaz != 0 && eau != 0)
            {
                 ref1 = new Reference
                {
                    Date = dt,
                    Elect_Hp = electHp,
                    Elect_Hc = electHc,
                    Gaz = gaz,
                    Eau = Math.Round(eau,2),
                };
                try
                {
                    await App.Database.SavereferenceAsync(ref1);

                    await DisplayAlert("Information", "Valeurs enregistrés avec succes", "OK");
                    NewElectHc.Text = string.Empty;
                    NewElectHp.Text = string.Empty;
                    NewGaz.Text = string.Empty;
                    NewEau.Text = string.Empty;
                }
                catch (Exception)
                {

                    await DisplayAlert("Alert", "Erreur lors d'enregistrement des valeurs ! ! Réessayez", "OK");
                }
            }else
            {
               await  DisplayAlert("Alert", "Veuillez saisir des valeurs différentes de zéro !!" , "OK");
            }
            //await App.Database.SavereferenceAsync(ref1);
            // await Navigation.PopAsync();


        }

        private async void Consult(object sender, EventArgs e)
        {
            //DisplayAlert("Consultation", "consulter", "OK!!!");
            await Navigation.PushAsync(new ConsultPage());

        }
    }
}
