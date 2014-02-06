﻿using System.Threading.Tasks;
using Adaptive.ReactiveTrader.Contracts;
using log4net;

namespace Adaptive.ReactiveTrader.Server.SignalR
{
    class BlotterPublisher : IBlotterPublisher
    {
        private readonly IContextHolder _contextHolder;
        private static readonly ILog Log = LogManager.GetLogger(typeof(BlotterPublisher));

        public BlotterPublisher(IContextHolder contextHolder)
        {
            _contextHolder = contextHolder;
        }

        public Task Publish(SpotTrade trade)
        {
            Log.InfoFormat("Broadcast new trade to blotters: {0}", trade);
            return _contextHolder.Context.Group(TradingServiceHub.BlotterGroupName).OnNewTrade(trade);
        }
    }
}