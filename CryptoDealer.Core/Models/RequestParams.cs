namespace CryptoDealer.Core.Models
{
    public class RequestParams
    {
        public string Endpoint { get; set; } = default!;
        public string? Market { get; set; }
        public int? Limit { get; set; }
        public long? Start { get; set; }
        public long? End { get; set; }
        public string? TradeIdFrom { get; set; }
        public string? TradeIdTo { get; set; }

        public RequestParams(string endpoint, string market, int? limit, long? start, long? end, string? tradeIdFrom, string? tradeIdTo)
        {
            Endpoint = endpoint;
            Market = market;
            Limit = limit;
            Start = start;
            End = end;
            TradeIdFrom = tradeIdFrom;
            TradeIdTo = tradeIdTo;
        }
    }
}
