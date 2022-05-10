using ControleDeVendas;

DatabasePrograma db = new DatabasePrograma();
Cliente c = new Cliente();
c.Id = 5;
c.Nome = "Not";
c.Email = "Not@demo.com";
c.Telefone = 123456789;
c.Nif = 123456789;
dynamic data = db.DeleteCliente(c);



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
