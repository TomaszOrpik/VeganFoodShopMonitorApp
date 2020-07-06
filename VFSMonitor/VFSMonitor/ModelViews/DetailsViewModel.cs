using Microcharts;
using System;
using System.Collections.Generic;
using System.Text;
using VFSMonitor.Models;

namespace VFSMonitor.ModelViews
{
    class DetailsViewModel : BaseViewModel
    {

        public List<ChartEntry> pagesChart = new List<ChartEntry>();
        public List<ChartEntry> buyedItemsChart = new List<ChartEntry>();

        public DetailsViewModel(Session session)
        {
            userId = session.UserId;
            sessionId =session.SessionId;
            userIp = session.UserIp;
            visitCounter = session.VisitCounter;
            visitDate = session.VisitDate;
            device = session.Device;
            browser = session.Browser;
            location = session.Location;
            reffer = session.Reffer;
            fillPagesChart(session.Pages);
            cartItems = session.CartItems;
            fillBuyedItemsChart(session.BuyedItems);
            didLogged = session.DidLogged;
            didContacted = session.DidContacted;

        }

        private void fillPagesChart(IList<Page> pages)
        {
            foreach(Page page in pages)
            {
                var random = new Random();
                var color = String.Format("#{0:X6}", random.Next(0x1000000));

                ChartEntry entry = new ChartEntry(page.TimeOn)
                {
                    Label = page.Name,
                    ValueLabel = page.TimeOn.ToString(),
                    Color = SkiaSharp.SKColor.Parse(color)
                };
                pagesChart.Add(entry);
            }
        }

        private void fillBuyedItemsChart(IList<BuyedItem> items)
        {
            foreach(BuyedItem item in items)
            {
                var random = new Random();
                var color = String.Format("#{0:X6}", random.Next(0x1000000));

                ChartEntry entry = new ChartEntry(item.ItemQuantity)
                {
                    Label = item.ItemName,
                    ValueLabel = item.ItemQuantity.ToString(),
                    Color = SkiaSharp.SKColor.Parse(color)
                };
                buyedItemsChart.Add(entry);
            }
        }

        private Session _session;
        public Session session
        {
            get => _session;
            set
            {
                SetProperty(ref _session, value);
            }
        }

        private string _userId;
        public string userId
        {
            get => _userId;
            set => SetProperty(ref _userId, value);
        }
        private string _sessionId;
        public string sessionId
        {
            get => _sessionId;
            set => SetProperty(ref _sessionId, value);
        }
        private string _userIp;
        public string userIp
        {
            get => _userIp;
            set => SetProperty(ref _userIp, value);
        }
        private int _visitCounter;
        public int visitCounter
        {
            get => _visitCounter;
            set => SetProperty(ref _visitCounter, value);
        }
        private string _visitDate;
        public string visitDate
        {
            get => _visitDate;
            set => SetProperty(ref _visitDate, value);
        }
        private string _device;
        public string device
        {
            get => _device;
            set => SetProperty(ref _device, value);
        }
        private string _browser;
        public string browser
        {
            get => _browser;
            set => SetProperty(ref _browser, value);
        }
        private string _location;
        public string location
        {
            get => _location;
            set => SetProperty(ref _location, value);
        }
        private string _reffer;
        public string reffer
        {
            get => _reffer;
            set => SetProperty(ref _reffer, value);
        }
        private IList<Page> _pages;
        public IList<Page> pages
        {
            get => _pages;
            set => SetProperty(ref _pages, value);
        }
        private IList<CartItem> _cartItems;
        public IList<CartItem> cartItems
        {
            get => _cartItems;
            set => SetProperty(ref _cartItems, value);
        }
        private IList<BuyedItem> _buyedItems;
        public IList<BuyedItem> buyedItems
        {
            get => _buyedItems;
            set => SetProperty(ref _buyedItems, value);
        }
        private bool _didLogged;
        public bool didLogged
        {
            get => _didLogged;
            set => SetProperty(ref _didLogged, value);
        }
        private bool _didContacted;
        public bool didContacted
        {
            get => _didContacted;
            set => SetProperty(ref _didContacted, value);
        }
    }
}
