using HotelBooking.Components.DataModels;
using HotelBooking.Components.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string conStr = builder.Configuration.GetSection("ConnectionStrings")["DefaultConnection"] ?? string.Empty;

builder.Services.AddDbContext<HotelBookingContext>(options => options.UseSqlServer(conStr));
builder.Services.AddTransient<IHotelService, HotelService>();
builder.Services.AddTransient<IResetService, ResetService>();
builder.Services.AddTransient<IRoomService, RoomService>();
builder.Services.AddTransient<IBookingService, BookingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); 
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
