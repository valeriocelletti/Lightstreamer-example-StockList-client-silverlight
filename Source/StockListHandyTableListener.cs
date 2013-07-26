#region License
/*
* Copyright 2013 Weswit Srl
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/
#endregion License

using System;
using System.Windows.Controls;
using System.Threading;

using Lightstreamer.DotNet.Client;
using System.Collections.Generic;

namespace SilverlightDemo
{

    class StocklistHandyTableListener : IHandyTableListener
    {
        private Page page;
        private int phase;
        private List<Stock> gridModel;

        public StocklistHandyTableListener(Page page, int phase, List<Stock> gridModel)
        {
            this.phase = phase;
            this.page = page;
            this.gridModel = gridModel;
        }

        public void OnUpdate(int itemPos, string itemName, IUpdateInfo update)
        {
            Stock stock = gridModel[itemPos - 1];
            stock.StockName = update.GetNewValue("stock_name");
            stock.LastPrice = update.GetNewValue("last_price");
            stock.Time = update.GetNewValue("time");
            stock.PctChange = update.GetNewValue("pct_change");
            stock.BidQuantity = update.GetNewValue("bid_quantity");
            stock.Bid = update.GetNewValue("bid");
            stock.Ask = update.GetNewValue("ask");
            stock.AskQuantity = update.GetNewValue("ask_quantity");
            stock.Min = update.GetNewValue("min");
            stock.Max = update.GetNewValue("max");
            stock.RefPrice = update.GetNewValue("ref_price");
            stock.OpenPrice = update.GetNewValue("open_price");

            this.page.setData(this.phase, stock);
        }

        public void OnRawUpdatesLost(int itemPos, string itemName, int lostUpdates)
        {
            this.page.StatusChanged(this.phase,"Lost " + lostUpdates + " updates for " + itemPos,null);
        }

        public void OnSnapshotEnd(int itemPos, string itemName)
        {
            this.page.StatusChanged(this.phase, "End of snapshot for " + itemPos, null);
        }

        public void OnUnsubscr(int itemPos, string itemName)
        {
        }

        public void OnUnsubscrAll()
        {
            this.page.StatusChanged(this.phase,  "Unsubscr table", null);
        }
    }

}

