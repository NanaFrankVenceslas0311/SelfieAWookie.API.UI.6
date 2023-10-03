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


builder.Services.AddTransient<ISelfieRepository>();// Ici � chaque fois que l'on rencontre un constructeur il va faire un new ce qui est int�r�ssant,
                                                                            // car il va nous permettre de d�cider de la dur�e de vie d'un objet lorsque c'est de l'injection - d�pendance

builder.Services.AddScoped<ISelfieRepository>(); // Scoped est li� � toute la demande, ie � chaque fois,
                                                                          // d�s qu'il y'a une 1�re requ�te, tant que la requ�te existe et si on retrouve
                                                                          // � plusieurs demandes dans diff�rents constructeurs, on gardera cette demande (cette instance)

builder.Services.AddSingleton(typeof(DefaultSelfieRepository));// Pour dire que � chaque fois que nous allons rencontrer
                                                               // dans le constructeur ce type l� (DefaultSelfieRepository),
                                                               // et bien tu dois instancier une seule fois, et � chaque fois qu'il
                                                               // y'aura une nouvelle demande de ce type l�, tu redonneras la m�me instance => COMME EN STATIQUE





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
