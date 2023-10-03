using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using SelfieAWookies.Core.Selfies.Domain;
using SelfieAWookies.Core.Selfies.Infrastructures.Data;
using SelfieAWookies.Core.Selfies.Infrastructures.Repositories;
using Microsoft.Extensions.DependencyInjection;
using SelfieAWookie.API.UI._6.Controllers.ExtensionMethods;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<SelfiesContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("SelfiesDatabase"), SqlOptions =>
    {
       
    });
  
});

builder.Services.AddInjections(); // En pointant on observe que c'est bel et bien une extension


builder.Services.AddTransient<ISelfieRepository>();// Ici à chaque fois que l'on rencontre un constructeur il va faire un new ce qui est intéréssant,
                                                                            // car il va nous permettre de décider de la durée de vie d'un objet lorsque c'est de l'injection - dépendance

builder.Services.AddScoped<ISelfieRepository>(); // Scoped est lié à toute la demande, ie à chaque fois,
                                                                          // dès qu'il y'a une 1ère requête, tant que la requête existe et si on retrouve
                                                                          // à plusieurs demandes dans différents constructeurs, on gardera cette demande (cette instance)

builder.Services.AddSingleton(typeof(DefaultSelfieRepository));// Pour dire que à chaque fois que nous allons rencontrer
                                                               // dans le constructeur ce type là (DefaultSelfieRepository),
                                                               // et bien tu dois instancier une seule fois, et à chaque fois qu'il
                                                               // y'aura une nouvelle demande de ce type là, tu redonneras la même instance => COMME EN STATIQUE





builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
