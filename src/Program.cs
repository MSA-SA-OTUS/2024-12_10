using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

var is_error = false;


app.MapGet("/ping", () =>
{
    return is_error ? Results.StatusCode(503) : Results.Text("App_8081");

});

app.MapGet("/set_error/{v}", (int v) =>
{
    is_error = v == 0 ? false : true;
    return "OK";

});

app.MapGet("/ip", () =>
{
    string hostName = Dns.GetHostName();
    string myIP = Dns.GetHostEntry(hostName).AddressList[0].ToString();
    return myIP;

});

app.Run("http://[::]:8081");


