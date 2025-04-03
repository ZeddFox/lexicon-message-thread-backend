using Microsoft.AspNetCore.Mvc;
using lexicon_message_thread_backend.HttpModels;
using lexicon_message_thread_backend;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapPost("/send", (Message message) =>
{
    


    return Results.Ok(new
    {
        status = "Message sent successfully."
    });
});

app.MapGet("/update", () =>
{
    return Results.Ok(new
    {
        //messageList = messageList
    });
});

app.Run();
