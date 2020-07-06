using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFSMonitor.ModelViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VFSMonitor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AveragePage : ContentPage
    {
        public AveragePage(string userId)
        {
            InitializeComponent();

            BindingContext = new AverageViewModel(userId);
        }
    }
}