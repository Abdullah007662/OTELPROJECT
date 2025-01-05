using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    // JWT genelde cok kullanılır ama postman da cok kullanırlar gücenlik amacıyla kullanılır random bir header ve data kısmı verir size özgü.
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        // Bu aralıkta parametrelerkimizi geçecegiz
        ValidIssuer = "http://localhost", // Kullanıcılar
        ValidAudience = "http://localhost", //Dinleyiciler
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("aspnetcoreapiapikeymustbelonger")),// Jwt den gelen dogrulanıcak olan degerimiz ne oldugunu karsılar
        ValidateIssuerSigningKey = true,// Yukarıdakilerin çözümünü yap komutu
        ValidateLifetime =true,//Bu token in hayatta jkalma süresi yani gecerli oldugu süreyi girdik
        ClockSkew=TimeSpan.Zero



    }; 

});
builder.Services.AddAuthorization(auth =>
{
    auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
        .RequireAuthenticatedUser().Build());
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();
app.UseAuthorization();

app.MapControllers();

app.Run();
