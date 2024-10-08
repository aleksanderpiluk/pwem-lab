var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/about", () => "About page...");
app.MapGet("/contact", () => "Contact page...");
app.MapGet("/product/{id}", (int id) => $"Product ID: {id}");

app.Run();
