using Almacen.DAL;
using Almacen.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configura la cadena de conexi�n a la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar Mov_InventarioDAL
builder.Services.AddScoped<Mov_InventarioDAL>(); // Aseg�rate de que esta l�nea est� presente

// Registrar MovimientoService
builder.Services.AddScoped<MovimientoService>();

// A�adir servicios a la aplicaci�n
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurar el middleware de la aplicaci�n
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movimiento}/{action=Index}/{id?}");

app.Run();
