// using System;
// using System.Text;
// using System.Security.Cryptography;
// using System.Threading.Tasks;
// using RestSharp;

public class ApiClientService
{
  public RestClient Client { get; set; }
  private string ApiKey { get; set; }
  private string ApiSecret { get; set; }
  private string Signature { get; set; }
  

  public ApiClientService()
  {
    FileReader fileReader = new();
    ApiKey = fileReader.ReadApiKey().Trim();
    ApiSecret = fileReader.ReadApiSecret().Trim();
    Client = new RestClient("https://api.bitvavo.com/v2");
  }

  public static string CreateSignature(string _apiSecret, string timestamp, string method, string endpoint, string body="")
  {    
    // Stap 1: Bouw de pre-sign string op volgens Bitvavo-specificaties
    string preSign = timestamp + method.ToUpper() + endpoint + body;

    // Stap 2: Converteer secret en preSign naar byte-arrays
    // byte[] keyBytes = Encoding.UTF8.GetBytes(_apiSecret);
    byte[] keyBytes = Convert.FromBase64String(_apiSecret);
    byte[] messageBytes = Encoding.UTF8.GetBytes(preSign);

    // Stap 3: Bereken de HMAC-SHA256 hash
    using (var hmac = new HMACSHA256(keyBytes))
    {
        byte[] hashBytes = hmac.ComputeHash(messageBytes);

        // Stap 4: Zet om naar hex-string (lowercase)
        return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
    }
  }

  public RestRequest AuthenticateClient(string method, string endpoint, string body="")
  {
    string Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
    string Signature = ApiClientService.CreateSignature(ApiSecret, Timestamp, method, endpoint, body);

    var request = new RestRequest(endpoint, method.ToUpper() switch
    {
        "GET" => Method.Get,
        "POST" => Method.Post,
        "PUT" => Method.Put,
        "DELETE" => Method.Delete,
        _ => throw new ArgumentException("Ongeldige HTTP-methode")
    });
    
    request.AddHeader("Content-Type", "application/json");
    request.AddHeader("Bitvavo-Access-Key" , ApiKey);
    request.AddHeader("Bitvavo-Access-Signature", Signature);
    request.AddHeader("Bitvavo-Access-Timestamp", Timestamp);
    request.AddHeader("Bitvavo-Access-Window", "60000");

    if (!string.IsNullOrEmpty(body) && method != "GET" && method != "DELETE")
    {
        request.AddStringBody(body, DataFormat.Json);
    }

    return request;
  }

  public async Task<string> CreateGETRequest(string endpoint)
  {
    var request = AuthenticateClient("GET", endpoint);
    var response = await Client.ExecuteAsync(request);
    return response.Content;
  }

  public async Task<string> CreatePOSTRequest(string endpoint, string body)
  {
    var request = AuthenticateClient("POST", endpoint, body);
    var response = await Client.ExecuteAsync(request);
    return response.Content;
  }

  public async Task<string> CreatePUTRequest(string endpoint, string body)
  {
    var request = AuthenticateClient("PUT", endpoint, body);
    var response = await Client.ExecuteAsync(request);
    return response.Content;
  }
  
  public async Task<string> CreateDELETERequest(string endpoint)
  {
    var request = AuthenticateClient("DELETE", endpoint);
    var response = await Client.ExecuteAsync(request);
    return response.Content;
  }
}