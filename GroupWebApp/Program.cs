using Microsoft.EntityFrameworkCore;
using GroupWebApp.Storage.Entities;
using GroupWebApp.Logic.Categories;
using GroupWebApp.Logic.SubCategories;
using GroupWebApp.Logic.Recipes;
using GroupWebApp.Logic.NationalKitchens;
using GroupWebApp.Logic.TypesOfPreparation;
using GroupWebApp.Logic.Ingredients;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;


// Add services to the container.
services.AddControllersWithViews();

// Add Database Context.
var connectionString = builder.Configuration.GetConnectionString("DbConnection");
services.AddDbContext<RecipeContext>(param => param.UseSqlServer(connectionString));
services.AddScoped<ICategoryManager, CategoryManager>();
services.AddScoped<ISubCategoryManager, SubCategoryManager>();
services.AddScoped<IRecipeManager, RecipeManager>();
services.AddScoped<INationalKitchenManager, NationalKitchenManager>();
services.AddScoped<ITypeOfPreparationManager, TypeOfPreparationManager>();
services.AddScoped<IIngredientManager, IngredientManager>();



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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Categories}/{action=Main}/{id?}");
app.MapControllerRoute(
    name: "Sub",
    pattern: "{controller=SubCategories}/{action=Main}/{id}");
app.MapControllerRoute(
    name: "NK",
    pattern: "{controller=Recipes}/{action=SortNK}/{id}");
app.MapControllerRoute(
    name: "TOP",
    pattern: "{controller=Recipes}/{action=SortTOP}/{id}");
app.MapControllerRoute(
    name: "ING",
    pattern: "{controller=Recipes}/{action=SortByIngredient}/{id}");
app.MapControllerRoute(
    name: "INGR",
    pattern: "{controller=Ingredients}/{action=Main}/{id?}");
app.MapControllerRoute(
    name: "TofPr",
    pattern: "{controller=TypesOfPreparation}/{action=Main}/{id?}");
app.MapControllerRoute(
    name: "NatKit",
    pattern: "{controller=NationalKitchen}/{action=Main}/{id?}");

app.Run();
