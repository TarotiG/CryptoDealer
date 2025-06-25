public class TransactionHistory
{
    [JsonProperty("items")]
    public List<Transaction> Items { get; set; } = new List<Transaction>();

    [JsonProperty("currentPage")]
    public int CurrentPage { get; set; }

    [JsonProperty("totalPages")]
    public int TotalPages { get; set; }

    [JsonProperty("maxItems")]
    public int MaxItems { get; set; }
}

public class Transaction
{
    [JsonProperty("transactionId")]
    public string TransactionId { get; set; } = default!;

    [JsonProperty("executedAt")]
    public DateTime ExecutedAt { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; } = null!;

    [JsonProperty("priceCurrency")]
    public string PriceCurrency { get; set; } = default!;

    [JsonProperty("priceAmount")]
    public decimal PriceAmount { get; set; }

    [JsonProperty("sentCurrency")]
    public string SentCurrency { get; set; } = default!;

    [JsonProperty("sentAmount")]
    public decimal SentAmount { get; set; }

    [JsonProperty("receivedCurrency")]
    public string ReceivedCurrency { get; set; } = default!;

    [JsonProperty("receivedAmount")]
    public decimal ReceivedAmount { get; set; }

    [JsonProperty("feesCurrency")]
    public string FeesCurrency { get; set; } = default!;

    [JsonProperty("feesAmount")]
    public decimal FeesAmount { get; set; }

    [JsonProperty("address")]
    public string Address { get; set; } = default!;
}

