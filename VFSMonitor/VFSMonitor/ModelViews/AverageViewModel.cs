using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using VFSMonitor.Intefaces;
using VFSMonitor.Models;

namespace VFSMonitor.ModelViews
{
    class AverageViewModel : BaseViewModel
    {
        private IMonitorApiGlobal monitorApiGlobal;
        private IMonitorApiUserAverage monitorApiUserAverage;

        public AverageViewModel(string userId)
        {
            GetGlobal(userId);
        }

        async void GetGlobal(string userId)
        {
            IsBusy = true;
            IsVisible = false;
            if (userId == "all")
            {
                Title = "GLOBAL";
                IsExtraDataVisible = false;
                monitorApiGlobal = RestService.For<IMonitorApiGlobal>(App.url);
                AverageData = await monitorApiGlobal.GetGlobal();
                MostUsedDevice = AverageData.MostUsedDevice;
                MostUsedBrowser = AverageData.MostUsedBrowser;
                MostPopularLocation = AverageData.MostPopularLocation;
                MostPopularReffer = AverageData.MostPopularReffer;
                AverageTimeOnPages = AverageData.AverageTimeOnPages;
                AvItemBuy = AverageData.AverageItemsBuy;
                MostlyLogged = AverageData.MostlyLogged;
            }
            else
            {
                Title = userId;
                IsExtraDataVisible = true;
                monitorApiUserAverage = RestService.For<IMonitorApiUserAverage>(App.url);
                UserAverageData = await monitorApiUserAverage.GetUserAverage(userId);
                UserId = UserAverageData.UserId;
                UserIp = UserAverageData.UserIp;
                MostUsedDevice = UserAverageData.MostUsedDevice;
                MostUsedBrowser = UserAverageData.MostUsedBrowser;
                MostPopularLocation = UserAverageData.MostPopularLocation;
                MostPopularReffer = UserAverageData.MostPopularReffer;
                AverageTimeOnPages = UserAverageData.AverageTimeOnPages;
                AverageCartAction = UserAverageData.AverageCartAction;
                AvItemBuy = UserAverageData.AverageItemsBuy;
                MostlyLogged = UserAverageData.MostlyLogged;
            }
            IsVisible = false;
            IsBusy = false;

        }

        private string _Title;
        public string Title
        {
            get => _Title;
            set => SetProperty(ref _Title, value);
        }
        private GlobalAverageData _AverageData;
        public GlobalAverageData AverageData
        {
            get => _AverageData;
            set => SetProperty(ref _AverageData, value);
        }
        private UserAverageData _UserAverageData;
        public UserAverageData UserAverageData
        {
            get => _UserAverageData;
            set => SetProperty(ref _UserAverageData, value);
        }
        private bool _IsBusy;
        public bool IsBusy
        {
            get => _IsBusy;
            set => SetProperty(ref _IsBusy, value);
        }
        private bool _IsVisible;
        public bool IsVisible
        {
            get => _IsVisible;
            set => SetProperty(ref _IsVisible, value);
        }

        private string _UserId;
        public string UserId
        {
            get => _UserId;
            set => SetProperty(ref _UserId, value);
        }
        private string _UserIp;
        public string UserIp
        {
            get => _UserIp;
            set => SetProperty(ref _UserIp, value);
        }
        private string _MostUsedDevice;
        public string MostUsedDevice
        {
            get => _MostUsedDevice;
            set => SetProperty(ref _MostUsedDevice, value);
        }
        private string _MostUsedBrowser;
        public string MostUsedBrowser
        {
            get => _MostUsedBrowser;
            set => SetProperty(ref _MostUsedBrowser, value);
        }
        private string _MostPopularLocation;
        public string MostPopularLocation
        {
            get => _MostPopularLocation;
            set => SetProperty(ref _MostPopularLocation, value);
        }
        private string _MostPopularReffer;
        public string MostPopularReffer
        {
            get => _MostPopularReffer;
            set => SetProperty(ref _MostPopularReffer, value);
        }
        private decimal _AverageTimeOnPages;
        public decimal AverageTimeOnPages
        {
            get => _AverageTimeOnPages;
            set => SetProperty(ref _AverageTimeOnPages, value);
        }
        private string _AverageCartAction;
        public string AverageCartAction
        {
            get => _AverageCartAction;
            set => SetProperty(ref _AverageCartAction, value);
        }
        private decimal _AvItemBuy;
        public decimal AvItemBuy
        {
            get => _AvItemBuy;
            set => SetProperty(ref _AvItemBuy, value);
        }
        private bool _MostlyLogged;
        public bool MostlyLogged
        {
            get => _MostlyLogged;
            set => SetProperty(ref _MostlyLogged, value);
        }
        private bool _IsExtraDataVisible;
        public bool IsExtraDataVisible
        {
            get => _IsExtraDataVisible;
            set => SetProperty(ref _IsExtraDataVisible, value);
        }
    }
}
