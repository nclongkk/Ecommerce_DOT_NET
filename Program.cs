var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(10);
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
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
// app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// app.Use((context, next) =>
// {
//     var userId = context.Session.GetString("user_id");
//     if (userId == null)
//     {
//         //call home index controller
//         context.Response.Redirect("/");

//     }
//     Console.WriteLine("user_id: " + userId);
//     return next.Invoke();
// });

app.MapControllerRoute(
    name: "auth",
    pattern: "auth/{action=Login}",
    defaults: new { controller = "Auth", action = "Login" });
app.MapControllerRoute(
    name: "auth",
    pattern: "auth/{action=Register}",
    defaults: new { controller = "Auth", action = "Register" });
// app.MapControllerRoute(
//     name: "user",
//     pattern: "user/{id?}",
//     defaults: new { controller = "User", action = "Index" });
app.MapControllerRoute(
    name: "post",
    pattern: "post/{action=MostUpvoted}",
    defaults: new { controller = "Post", action = "MostUpvoted" });

app.MapControllerRoute(
    name: "post",
    pattern: "post/{id?}",
    defaults: new { controller = "Post", action = "Index" });
app.MapControllerRoute(
    name: "bookmark",
    pattern: "bookmark/{id?}",
    defaults: new { controller = "Bookmark", action = "Index" });
app.MapControllerRoute(
    name: "bookmark",
    pattern: "bookmark/{action=Add}",
    defaults: new { controller = "Bookmark", action = "Add" });
app.MapControllerRoute(
    name: "bookmark",
    pattern: "bookmark/{action=Delete}/{id?}",
    defaults: new { controller = "Bookmark", action = "Delete" });

// pattern: "{controller=User}/{action=Index}/{id?}");

app.Run();
