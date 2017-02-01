using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Threading;

namespace SignalRBroadcastSample
{
    public class TimerHelper
    {
        private Timer _timeUpdater;

        private readonly static Lazy<TimerHelper> _instance = new Lazy<TimerHelper>(() => new TimerHelper(GlobalHost.ConnectionManager.GetHubContext<TimeHub>().Clients));

        public static TimerHelper Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private IHubConnectionContext<dynamic> Clients
        {
            get;
            set;
        }

        private TimerHelper(IHubConnectionContext<dynamic> clients)
        {
            Clients = clients;
            if (_timeUpdater == null)
            {
                _timeUpdater = new Timer(UpdateTime, null, 5000, 5000);
            }
        }

        public void UpdateTime(object state)
        {
            Clients.All.updateTime(DateTime.Now.ToLongTimeString());
        }
    }
}