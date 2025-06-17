Goede keuze! PostgreSQL is een krachtige en veelzijdige database. Hier is hoe je PostgreSQL kunt integreren in je .NET-consoleapplicatie met **Entity Framework Core**:

### 1. Installeer de juiste NuGet-packages
Voeg de PostgreSQL-provider toe aan je project:

```sh
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
```

### 2. Databasecontext configureren
Pas je `DbContext`-klasse aan om PostgreSQL te gebruiken:

```csharp
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseNpgsql("Host=localhost;Database=mydb;Username=myuser;Password=mypassword");
}
```

Vervang `localhost`, `mydb`, `myuser` en `mypassword` door jouw PostgreSQL-configuratie.

### 3. Database migreren
Voer de volgende commando's uit om de database en tabellen te creëren:

```sh
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 4. Data toevoegen en ophalen
Gebruik de `AppDbContext` om gegevens in je database te plaatsen en op te halen:

```csharp
using var context = new AppDbContext();
context.Products.Add(new Product { Name = "Smartphone", Price = 599.99m });
context.SaveChanges();

var products = context.Products.ToList();
foreach (var product in products)
{
    Console.WriteLine($"Product: {product.Name}, Prijs: {product.Price}");
}
```

Met deze stappen heb je een PostgreSQL-database gekoppeld aan je .NET-consoleapplicatie. Wil je ook werken met geavanceerde functies zoals **LINQ-query's, transacties of async/await**? Laat het me weten! 🚀

