using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();
string parmA, parmB;

//ex1
    app.MapGet("/SDS", (string ParmA, string ParmB) =>
    {
        return Results.Text($"GET-Http-SDS:ParmA = {ParmA},ParmB = {ParmB}", "text/plain");
    });

//ex2
app.MapPost("/SDS", (HttpContext context) =>
{
    var req = context.Request;
    var res = context.Response;
    string ParmA = req.Query["ParmA"];
    string ParmB = req.Query["ParmB"];

    return Results.Text($"POST-Http-SDS:ParmA = {ParmA},ParmB = {ParmB}", "text/plain");
});
//ex3
app.MapPut("/SDS", (HttpContext context) =>
{
    var req = context.Request;
    var res = context.Response;
    string parmA = req.Query["parmA"];
    string parmB = req.Query["parmB"];


    return Results.Text($"P-Http-SDS:ParmA = {parmA},ParmB = {parmB}", "text/plain");
});

//ex4
app.MapPost("/zad4/sds", async (context) =>
    {
        var res = context.Response;
        var req = context.Request;
        using StreamReader reader = new StreamReader(req.Body);
        string data = await reader.ReadToEndAsync();
        JObject jsonObject = JObject.Parse(data);
        res.ContentType = "text/plain";
        res.Headers.ContentEncoding = "utf-8";
        int result = Convert.ToInt32(jsonObject["num1"]) + Convert.ToInt32(jsonObject["num2"]);
        await res.WriteAsync(result.ToString());
    }
);
//ex5
app.MapMethods("/zad5/sds", new[] { "GET", "POST" },
    async (context) =>
    {
        var res = context.Response;
        var req = context.Request;
        if (req.Method == HttpMethods.Get)
        {
            res.ContentType = "text/html";
            res.Headers.ContentEncoding = "utf-8";

            var htmlSumForm = await File.ReadAllTextAsync("wwwroot/dima5.html");
            await res.WriteAsync(htmlSumForm);
        }
        if (req.Method == HttpMethods.Post)
        {
            int parm1 = Int32.Parse(req.Form["parm1"]);
            int parm2 = Int32.Parse(req.Form["parm2"]);
            res.Headers.ContentEncoding = "utf-8";
            await res.WriteAsync($"{parm1 * parm2}");
        }
    });
//ex6
app.MapMethods("/zad6/sds", new[] { "GET", "POST" }, async context =>
{
    var res = context.Response;
    var req = context.Request;

    if (req.Method == HttpMethods.Get)
    {
        res.ContentType = "text/html";
        try
        {
            // Возвращает страницу dima6.html
            var htmlPage = await File.ReadAllTextAsync("wwwroot/dima6.html");
            await res.WriteAsync(htmlPage);
        }
        catch (FileNotFoundException)
        {
            res.StatusCode = StatusCodes.Status404NotFound;
            await res.WriteAsync("HTML file not found.");
        }
    }
    else if (req.Method == HttpMethods.Post)
    {
        try
        {
            var form = req.Form;
            int x = int.Parse(form["x"]);
            int y = int.Parse(form["y"]);
            res.ContentType = "text/html";
            await res.WriteAsync($"<h2>Result: {x * y}</h2>");
        }
        catch
        {
            res.StatusCode = StatusCodes.Status400BadRequest;
            await res.WriteAsync("<h2>Invalid input. Please enter valid numbers for x and y.</h2>");
        }
    }
    else
    {
        res.StatusCode = StatusCodes.Status405MethodNotAllowed;
        await res.WriteAsync("Method not allowed.");
    }
});

app.Run();