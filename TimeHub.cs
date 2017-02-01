using Microsoft.AspNet.SignalR;
using System;

namespace SignalRBroadcastSample
{
    public class TimeHub : Hub
    {
        private readonly TimerHelper _timerHelper;

        public TimeHub() : this(TimerHelper.Instance) { }

        public TimeHub(TimerHelper stockTicker)
        {
            _timerHelper = stockTicker;
        }

        public void GetTime()
        {
            Clients.All.updateTime(DateTime.Now.ToLongTimeString());
        }
    }    
}