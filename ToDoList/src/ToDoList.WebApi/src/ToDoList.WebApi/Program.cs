var builder = WebApplication.CreateBuilder(args);
{
    //Configure DI
    builder.Services.AddControllers();
}
var app = builder.Build();
{
    //COnfigure Middleware (HTTP request pipeline)
    app.MapControllers();
}


app.MapGet("/", () => "Hello World!");

app.Run();
