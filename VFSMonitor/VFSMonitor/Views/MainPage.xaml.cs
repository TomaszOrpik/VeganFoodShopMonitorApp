using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFSMonitor.Views;
using Xamarin.Forms;

namespace VFSMonitor
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Global_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AveragePage("all"));
        }

        private void Users_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UsersListView());
        }

        private void Sessions_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListViewPage("all"));
        }
    }
}
