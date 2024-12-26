var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.MapControllerRoute(
    name: "M01",
    pattern: "{controller}/{action}/{id?}",
    defaults: new { controller = "TMResearch", action = "M01" }
    );

app.MapControllerRoute(
    name: "M01",
    pattern: "{V2}/{controller}/{action}/{id?}",
    defaults: new { controller = "TMResearch" }
    );
app.MapControllerRoute(
    name: "M01",
    pattern: "{V3}/{controller}/{id?}/{action}",
    defaults: new { controller = "TMResearch" }
    );

app.MapControllerRoute(
    name: "M02",
    pattern: "V3/{controller}/{id?}/{action}",
    defaults: new { controller = "TMResearch" }
    );
app.MapControllerRoute(
    name: "M02",
    pattern: "V2/{controller}/{action}",
    defaults: new { controller = "TMResearch",action = "M02"}
    );


app.MapControllerRoute(
    name: "M03",
    pattern: "V3/{controller}/{id?}/{action}",
    defaults: new { controller = "TMResearch", action = "M03" }
    );

app.MapControllerRoute(
    name: "MXX",
    pattern: "{*url}",
    defaults: new { controller = "TMResearch", action = "MXX" }
    );

//app.MapControllerRoute(
//    name: "TMResearch1",
//    pattern: "",
//    defaults: new {  controller = "TMResearch", action = "MO1" }
//    );





app.Run();
