using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VFSMonitor.Intefaces;
using VFSMonitor.Interfaces;
using VFSMonitor.Models;
using VFSMonitor.Views;
using Xamarin.Forms;

namespace VFSMonitor.ModelViews
{
    class ListViewModel : BaseViewModel
    {
        private IMonitorApiGetSessions monitorApiGetSessions;
        private IMonitorApiUserSessions monitorApiUserSessions;
        private List<Session> _SessionsList;
        public List<Session> SessionsList
        {
            get => _SessionsList;
            set => SetProperty(ref _SessionsList, value);
        }
        private List<Session> _UniqueUserSessionsList;
        public List<Session> UniqueUserSessionsList
        {
            get => _UniqueUserSessionsList;
            set => SetProperty(ref _UniqueUserSessionsList, value);
        }
        private bool _IsBusy;
        public bool IsBusy
        {
            get => _IsBusy;
            set => SetProperty(ref _IsBusy, value);
        }
        private bool _BtnVisible;
        public bool BtnVisible
        {
            get => _BtnVisible;
            set => SetProperty(ref _BtnVisible, value);
        }
        private string _Title;
        public string Title
        {
            get => _Title;
            set => SetProperty(ref _Title, value);
        }

        public ListViewModel(string userId)
        {
            GetSessions(userId);
        }

        async void GetSessions(string userId)
        {
            IsBusy = true;
            if (userId == "all")
            {
                BtnVisible = false;
                Title = "SESSIONS";
                monitorApiGetSessions = RestService.For<IMonitorApiGetSessions>(App.url);
                SessionsList = await monitorApiGetSessions.GetSessions();
            }
            else
            {
                BtnVisible = true;
                Title = userId;
                monitorApiUserSessions = RestService.For<IMonitorApiUserSessions>(App.url);
                SessionsList = await monitorApiUserSessions.GetUserSessions(userId);
            }
            UniqueUserSessionsList = SessionsList.GroupBy(x => x.UserId).Select(x => x.First()).ToList();
            IsBusy = false;

        }
    }
}
