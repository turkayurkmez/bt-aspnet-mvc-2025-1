using EShopLite.Application;
using EShopLite.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddApplication();
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddInfrastructure(connectionString);


builder.Services.AddCors(option => option.AddPolicy("allow", builder => { 
      builder.AllowAnyOrigin();
    //Farklı origin'ler:,
    /*
     * 1. http://www.trendyol.com
     * 2. https://www.trendyol.com
     * 3. https://users.trendyol.com
     * 4. https://users.trendyol.com:1246
     */
}));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option => option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = "server",
                    ValidateAudience = true,
                    ValidAudience = "client",

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bu-cumle-guclu-ve-onemli_ve_cok_kritik"))

                });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}



app.UseHttpsRedirection();
app.UseCors("allow");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
