using Application.DAOInterface;
using JsonDataAccess.DAOImpl;
using JsonDataAccess.FileContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserDAO, UserDAOImpl>();
builder.Services.AddScoped<UserFileContext>();
builder.Services.AddScoped<ForumFileContext>();
builder.Services.AddScoped<IForumDAO, ForumDAOImpl>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();