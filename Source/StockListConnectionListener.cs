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
using System.Windows.Media;

namespace SilverlightDemo
{
    class StocklistConnectionListener : IConnectionListener
    {
        private Page page;
        private int phase;

        public StocklistConnectionListener(Page page, int phase)
        {
            this.phase = phase;
            this.page = page;
        }

        public void OnConnectionEstablished()
        {
            this.page.StatusChanged(this.phase, "Connected to Lightstreamer Server...", null);
        }

        public void OnSessionStarted(bool isPolling)
        {
            if (isPolling)
            {
                this.page.StatusChanged(this.phase, "Lightstreamer is pushing (smart polling mode)...", Page.POLLING);
            }
            else
            {
                this.page.StatusChanged(this.phase, "Lightstreamer is pushing (streaming mode)...", Page.STREAMING);
            }
           
        }

        public void OnNewBytes(long b) { }

        public void OnDataError(PushServerException e)
        {
            this.page.StatusChanged(this.phase, "Data error: " + e.Message, null);
        }

        public void OnActivityWarning(bool warningOn)
        {
            if (warningOn)
            {
                this.page.StatusChanged(this.phase, "Connection stalled", Page.STALLED);
            }
            else
            {
                this.page.StatusChanged(this.phase, "Connection no longer stalled", Page.STREAMING);
            }
        }

        private void onDisconnection(String status)
        {
            this.page.StatusChanged(this.phase, status, Page.DISCONNECTED);
            this.page.Start(this.phase);
        }

        public void OnClose()
        {
            this.onDisconnection("Connection closed");
        }

        public void OnEnd(int cause)
        {
            this.onDisconnection("Connection forcibly closed");
        }

        public void OnFailure(PushServerException e)
        {
            this.onDisconnection("Server failure: " + e.Message);
        }

        public void OnFailure(PushConnException e)
        {
            this.onDisconnection("Connection failure: " + e.Message);
        }

 
    }

}
