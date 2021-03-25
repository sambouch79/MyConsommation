using Myconsom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Myconsom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultPage : ContentPage
    {
        public ConsultPage()
        {
            InitializeComponent();
        }

        private async void Goback_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(false);
        }
        private async Task<List<DonnesComparaison> > GetConsult()
        {
            List<Reference> references = await App.Database.GetReferenceAsync();
            List<Reference> sorted1 = references.OrderByDescending(o => o.Date).ToList();
            List<DonnesComparaison> ListComparaison = new List<DonnesComparaison>();
            for (int i = 0; i < sorted1.Count-1; i++)
            { 
                int idC = sorted1[i].ID;
                TimeSpan dl = sorted1[i ].Date-sorted1[i+1].Date;
                double delay = Convert.ToDouble(dl.TotalDays);
                int reshp = sorted1[i ].Elect_Hp - sorted1[i+1].Elect_Hp;
                int reshc= sorted1[i ].Elect_Hc - sorted1[i+1].Elect_Hc;
                int resgaz = sorted1[i ].Gaz- sorted1[i+1].Gaz;
                double reseau = sorted1[i ].Eau- sorted1[i+1].Eau;
                double hpJ;
                double hcJ;
                double gazJ;
                double eauJ;
                if (delay != 0)
                {
                     hpJ = reshp / delay ;
                     hcJ = reshc / delay;
                     gazJ = resgaz / delay;
                     eauJ = reseau / delay;
                }
                else
                {
                     hpJ = reshp ;
                     hcJ = reshc ;
                     gazJ = resgaz ;
                     eauJ = reseau ;
                }
             
                int hp = sorted1[i].Elect_Hp;
                int hc = sorted1[i].Elect_Hc;
                int g = sorted1[i].Gaz;
                double e = sorted1[i].Eau;
                DateTime d = sorted1[i].Date;
                DonnesComparaison donnes = new DonnesComparaison()
                {
                    IdComp = idC,
                    HpJour =Math.Round( hpJ,2) ,
                    HcJour = Math.Round(hcJ ,2),
                    gazJour = Math.Round(gazJ,2),
                    EauJour =Math.Round( eauJ,2),
                    Elect_Hc = hc,
                    Elect_Hp = hp,
                    Gaz = g,
                    Eau = Math.Round(e,2),
                    Date = d,
                };
                Console.WriteLine ($"{donnes.Date} {donnes.Eau} {donnes.EauJour}");
                ListComparaison.Add(donnes);

            }


            return ListComparaison;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //List<Reference> references = await App.Database.GetReferenceAsync();
            List<DonnesComparaison> listeDonnes =await  GetConsult();

            // List<Reference> sorted = references.OrderByDescending(o=> o.ID).ToList();
            List<DonnesComparaison> sorted = listeDonnes.OrderByDescending(o => o.Date).ToList();

            ConsommationList.ItemsSource = sorted;
        }
    }
}