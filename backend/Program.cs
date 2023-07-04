using backend;
using backend.Model;
using Security_jwt;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MainPolicy",
        policy =>
        {
            policy
                .AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IJwtService>(p =>
    new JwTService(new PasswordProvider("sla"))
);

builder.Services.AddTransient<IForumRepository, ForumRepository>();
builder.Services.AddTransient<IRepository<Position>, PositionRepository>();
builder.Services.AddTransient<IRepository<Subscribed>, SubscribedRepository>();

builder.Services.AddScoped<DiscordiaContext>();
//TODOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
// builder.Services.AddSingleton<IRepository<Person>, FakeUserRepo>();


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

app.UseCors();

app.Run();
