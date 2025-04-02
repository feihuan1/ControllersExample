using ControllersExample.Controllers;

var builder = WebApplication.CreateBuilder(args);

//// this is how we enable this controller// it will add the controller memtioned in <>
//builder.Services.AddTransient<Homecontroller>();

// step 1, add controller in to program.cs
// this will add all controllers, asp will auto detect all class surfix with "Controller" in solution and add it
builder.Services.AddControllers();

var app = builder.Build();

//// enable endpoints
//app.UseRouting();
//app.UseEndpoints(endpoits =>
//{
//    // add endpoints one by one
//    //endpoits.Map("url1", async (context) =>
//    //{
//    //  some logic...
//    //});

//    endpoits.MapControllers();
//});

// this will automatically call UseRoute and UseEndPoints 
app.MapControllers();

// this starts the server, end of middleware
app.Run();
