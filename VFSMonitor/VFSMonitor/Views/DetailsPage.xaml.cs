using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entry = Microcharts.Entry;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microcharts;
using VFSMonitor.Models;
using VFSMonitor.ModelViews;
using System.ComponentModel;

namespace VFSMonitor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(false)]
    public partial class DetailsPage : ContentPage
    {
        private DetailsViewModel viewModel;
        public DetailsPage(Session item)
        {
            InitializeComponent();
            //(BindingContext as DetailsViewModel).session = item;
            viewModel = new DetailsViewModel(item);
            BindingContext = viewModel;

            PagesChart.Chart = new PieChart { Entries = viewModel.pagesChart };
            BuyedChart.Chart = new RadialGaugeChart { Entries = viewModel.buyedItemsChart };
            listStack.HeightRequest = 75*item.CartItems.Count;
        }

        private void Export_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Export To Excel", viewModel.SaveToExcelControl(), "OK");
        }
    }
}