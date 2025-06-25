public class Order
{
    [JsonProperty("orderId")]
    public string Id { get; set; } = default!;

    [JsonProperty("clientOrderId")]
    public string ClientOrderId { get; set; } = default!;

    [JsonProperty("market")]
    public string Market { get; set; } = default!;

    [JsonProperty("created")]
    public long Created { get; set; }

    [JsonProperty("updated")]
    public long Updated { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; } = default!;

    [JsonProperty("side")]
    public string Side { get; set; } = default!;

    [JsonProperty("orderType")]
    public string OrderType { get; set; } = default!;

    [JsonProperty("amount")]
    public string Amount { get; set; } = default!;

    [JsonProperty("amountRemaining")]
    public string AmountRemaining { get; set; } = default!;

    [JsonProperty("price")]
    public string Price { get; set; } = default!;

    [JsonProperty("amountQuote")]
    public string AmountQuote { get; set; } = default!;

    [JsonProperty("amountQuoteRemaining")]
    public string AmountQuoteRemaining { get; set; } = default!;

    [JsonProperty("onHold")]
    public string OnHold { get; set; } = default!;

    [JsonProperty("onHoldCurrency")]
    public string OnHoldCurrency { get; set; } = default!;

    [JsonProperty("triggerPrice")]
    public string TriggerPrice { get; set; } = default!;

    [JsonProperty("triggerAmount")]
    public string TriggerAmount { get; set; } = default!;

    [JsonProperty("triggerType")]
    public string TriggerType { get; set; } = default!;

    [JsonProperty("triggerReference")]
    public string TriggerReference { get; set; } = default!;

    [JsonProperty("filledAmount")]
    public string FilledAmount { get; set; } = default!;

    [JsonProperty("filledAmountQuote")]
    public string FilledAmountQuote { get; set; } = default!;

    [JsonProperty("feePaid")]
    public string FeePaid { get; set; } = default!;

    [JsonProperty("feeCurrency")]
    public string FeeCurrency { get; set; } = default!;

    [JsonProperty("fills")]
    public List<Fill>? Fills { get; set; }

    [JsonProperty("selfTradePrevention")]
    public string SelfTradePrevention { get; set; } = "cancelNewest";

    [JsonProperty("visible")]
    public bool Visible { get; set; }

    [JsonProperty("timeInForce")]
    public string TimeInForce { get; set; } = default!;

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
    public string? Id { get; set; }
    public long Timestamp { get; set; }
    public string? Amount { get; set; }
    public string? Price { get; set; }
    public string? Taker { get; set; }
    public string? Fee { get; set; }
    public string? FeeCurrency { get; set; }
    public string? Settled { get; set; }
}