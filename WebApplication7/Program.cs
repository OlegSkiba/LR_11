using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication7;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Додавання фільтрів до опцій MVC
builder.Services.AddMvc(options =>
{
    options.Filters.Add(new LogActionFilter("log.txt")); // Додавання фільтру для логування дій
    options.Filters.Add(new UniqueUsersFilter("unique_users.txt")); // Додавання фільтру для підрахунку унікальних користувачів
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
