using System;
using System.Collections.Generic;
using IBApi;
using TwsDLL;

namespace TwsDemo
{
    internal class Tws
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
}