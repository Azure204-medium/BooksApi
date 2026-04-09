using Books.Domain.Entities;
using Books.Infra.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.Metrics;
using System.Text;
using System.Text.Json;

/// <summary>
/// Provides extension methods for seeding the database with initial data.
/// </summary>
public static class DbSeeder
{

    public async static Task Seed(this IServiceProvider serviceProvider)
    {
        if (serviceProvider == null)
        {
            throw new ArgumentNullException(nameof(serviceProvider));
        }
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        await context.Database.MigrateAsync();
        if (context.Database != null)
        {
            if (!await context.Books.AnyAsync())
            {
                var jsonPath = Path.Combine(
                     Directory.GetCurrentDirectory(),
                     "Seeders",
                     "Books.json");
                var jsonData = await File.ReadAllTextAsync(jsonPath);
                var books = JsonSerializer.Deserialize<List<Book>>(jsonData, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                if (books?.Any() == true)
                {
                    await context.Books.AddRangeAsync(books);
                    await context.SaveChangesAsync();
                }

            }

        }

    }

}