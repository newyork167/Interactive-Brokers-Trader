using System;
using System.Collections.Generic;
using IBApi;

namespace TwsDLL
{
    public class TwsStatic
    {
        public static Contract CreateContract(String symbol, String secType = "STK", String exchange = "SMART",
            String currency = "USD")
        {
            var newContract = new Contract
            {
                Symbol = symbol,
                SecType = secType,
                Exchange = exchange,
                Currency = currency
            };

            return newContract;
        }

        public static void StartMarketData(EWrapperImpl ewrapper, int id, Contract contract,
            List<TagValue> mktDataOptions = null)
        {
            ewrapper.ClientSocket.reqMktData(id, contract, "", false, mktDataOptions);
        }

        public static void CancelMarketData(EWrapperImpl ewrapper, int id)
        {
            ewrapper.ClientSocket.cancelMktData(id);
        }

        public static bool Connect(EWrapperImpl ewrapper, String address, int port, int connectionId)
        {
            ewrapper.ClientSocket.eConnect(address, port, connectionId);
            return ewrapper.ClientSocket.IsConnected();
        }

        public static void Disconnect(EWrapperImpl ewrapper)
        {
            ewrapper.ClientSocket.eDisconnect();
        }

        public static bool IsConnected(EWrapperImpl ewrapper)
        {
            return ewrapper.ClientSocket.IsConnected();
        }
    }

    public class Tws
    {
        public enum TickPrice
        {
            Bid = 1,
            Ask = 2,
            Last = 4,
            High = 6,
            Low = 7,
            Close = 9
        }

        public enum TickSize
        {
            BidSize = 0,
            AskSize = 3,
            LastSize = 5,
            Volume = 8
        }

        public EWrapperImpl IbClient = new EWrapperImpl();

        public Tws()
        {
        }

        public Tws(EWrapperImpl ibClient)
        {
            IbClient = ibClient;
        }

        /// <summary>
        ///     Create new contract for use later
        /// </summary>
        /// <param name="symbol">Ticker symbol</param>
        /// <param name="secType">Security type; Default: STK</param>
        /// <param name="exchange">Exchange type; Default: SMART</param>
        /// <param name="currency">Currency type; Default: USD</param>
        /// <returns>New Contract object</returns>
        public void StartMarketData(int id, Contract contract,
            List<TagValue> mktDataOptions = null)
        {
            IbClient.ClientSocket.reqMktData(id, contract, "", false, mktDataOptions);
        }


        public void CancelMarketData(int id)
        {
            IbClient.ClientSocket.cancelMktData(id);
        }


        public bool Connect(String address, int port, int connectionId)
        {
            IbClient.ClientSocket.eConnect(address, port, connectionId);
            return IbClient.ClientSocket.IsConnected();
        }


        public void Disconnect()
        {
            IbClient.ClientSocket.eDisconnect();
        }


        public bool IsConnected()
        {
            return IbClient.ClientSocket.IsConnected();
        }
    }
}