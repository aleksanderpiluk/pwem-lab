using Library.Services;
using Library.Repositories;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddHttpContextAccessor();

// Tu ten serwis odpowiada za pobierania danych z plików json
builder.Services.AddScoped<JsonService>();
// Ten serwis korzysta z tego poprzedniego i operuje na Bibliotece ogólnie
// Pewnie dobrze byłoby to rozdzielić na książki i wyporzyczenia odzielnie
// Bo aktualnie jest razem
builder.Services.AddScoped(provider =>
{
	var jsonService = provider.GetRequiredService<JsonService>();

	return new LibraryRepository(jsonService);
});
// To do mvc 
builder.Services.AddControllersWithViews();
// TO jest potrzebne do działania sesji
builder.Services.AddDistributedMemoryCache();

// Tutaj konfigurujemy sesje
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(30);
	options.Cookie.HttpOnly = true;
	options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

// app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Tu uruchamiamy sesje usera trzymajaca "logowanie"
app.UseSession();



app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
