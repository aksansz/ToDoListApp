using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using OpenAI.Extensions;
using ToDoListApp.Interfaces;
using ToDoListApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Getting ConnectionString loaded automatically from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//Add Database Connection
builder.Services.AddDbContext<TodoListDbContext>(options =>
                    options.UseNpgsql(connectionString));

string baseAddress = builder.Configuration.GetValue<string>("BaseUrl");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });
// builder.Services.AddHttpClient("ApiClient", client =>
// {
//    client.BaseAddress = new Uri(builder.Configuration["ApiBaseAddress"]);
// });


builder.Services.AddOpenAIService(settings => 
{ 
    settings.ApiKey = builder.Configuration["OpenAI:ApiKey"];
});

// Add services to the container.
builder.Services.AddScoped<IPlannerService, PlannerService>();
builder.Services.AddControllers();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


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

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
