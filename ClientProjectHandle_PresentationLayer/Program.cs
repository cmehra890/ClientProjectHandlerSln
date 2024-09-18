using ClientProjectHandle_BusinessLogicLayer.BLL;
using ClientProjectHandle_BusinessLogicLayer.IBLL;
using ClientProjectHandle_PresentationLayer.Filters.ActionFilters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc(options => 
{
	options.Filters.Add<SessionCheckActionFilter>();
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => 
{ 
	options.IdleTimeout = TimeSpan.FromMinutes(30);
	options.Cookie.IsEssential = true;
	options.Cookie.HttpOnly = true;
});

builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
builder.Services.AddScoped<ILoginBLL, LoginBLL>();
builder.Services.AddScoped<IClientBLL, ClientBLL>();
builder.Services.AddScoped<IAdminBLL, AdminBLL>();
//builder.Services.AddScoped<>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapGet("/ess",() => {
	new HttpContextAccessor().HttpContext.Session.Clear();
});

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Client}/{action=Index}/{id?}");

app.Run();
