public class Order
{
    [JsonProperty("orderId")]
    public string Id { get; set; }
    [JsonProperty("clientOrderId")]
    public string ClientOrderId { get; set; }
    [JsonProperty("market")]
    public string Market { get; set; }
    [JsonProperty("created")]
    public long Created { get; set; }
    [JsonProperty("updated")]
    public long Updated { get; set; }
    [JsonProperty("status")]
    public string Status { get; set; }
    [JsonProperty("side")]
    public string Side { get; set; }
    [JsonProperty("orderType")]
    public string OrderType { get; set; }
    [JsonProperty("amount")]
    public string Amount { get; set; }
    [JsonProperty("amountRemaining")]
    public string AmountRemaining { get; set; }
    [JsonProperty("price")]
    public string Price { get; set; }
    [JsonProperty("amountQuote")]
    public string AmountQuote { get; set; }
    [JsonProperty("amountQuoteRemaining")]
    public string AmountQuoteRemaining { get; set; }
    [JsonProperty("onHold")]
    public string OnHold { get; set; }
    [JsonProperty("onHoldCurrency")]
    public string OnHoldCurrency { get; set; }
    [JsonProperty("triggerPrice")]
    public string TriggerPrice { get; set; }
    [JsonProperty("triggerAmount")]
    public string TriggerAmount { get; set; }
    [JsonProperty("triggerType")]
    public string TriggerType { get; set; }
    [JsonProperty("triggerReference")]
    public string TriggerReference { get; set; }
    [JsonProperty("filledAmount")]
    public string FilledAmount { get; set; }
    [JsonProperty("filledAmountQuote")]
    public string FilledAmountQuote { get; set; }
    [JsonProperty("feePaid")]
    public string FeePaid { get; set; }
    [JsonProperty("feeCurrency")]
    public string FeeCurrency { get; set; }
    [JsonProperty("fills")]
    public List<Fill> Fills { get; set; }
    [JsonProperty("selfTradePrevention")]
    public string SelfTradePrevention { get; set; } = "cancelNewest";
    [JsonProperty("visible")]
    public bool Visible { get; set; }
    [JsonProperty("timeInForce")]
    public string TimeInForce { get; set; }
    // [JsonProperty("postOnly")]
    // public bool PostOnly { get; set; }
    [JsonProperty("operatorId")]
    public int OperatorId { get; set; }

    // Constructor voor een market order
    public Order(string Market, string Side, string OrderType, int OperatorId, string Amount)
    {
        this.Market = Market;
        this.Side = Side;
        this.OrderType = OrderType;
        this.OperatorId = OperatorId;
        this.Amount = Amount;
    }
}

public class Fill
{
    public string Id { get; set; }
    public long Timestamp { get; set; }
    public string Amount { get; set; }
    public string Price { get; set; }
    public string Taker { get; set; }
    public string Fee { get; set; }
    public string FeeCurrency { get; set; }
    public string Settled { get; set; }
}