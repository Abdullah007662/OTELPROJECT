using OteLProjectBusinessLayer.Conteiner;
using OteLProjectDataAccessLayer.Concrete;
using OtelWebApi.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Veritaban� ba�lam�n� DI konteynerine ekler
builder.Services.AddDbContext<Context>();

// Dependency Injection yap�land�rmas�. "ConteinerDependencies" metodu servis ba��ml�l�klar�n� ekler.
builder.Services.ConteinerDependencies();
/*
    .NET 7.0 ve �st� i�in dikkat edilmesi gerekenler:
    - Paketlerin ayn� versiyonda y�kl� olmas� gerekir.
    - DTO (Data Transfer Object) dosyalar� ile uyumlu Dependency Injection yap�land�rmas� yap�lmal�d�r.
*/

builder.Services.AddAutoMapper(typeof(AutoMappingConfig));
// AutoMapper yap�land�rmas�n� ekler. Bu, veri nesneleri aras�nda d�n���m yapmay� kolayla�t�r�r.

// CORS (Cross-Origin Resource Sharing) yap�land�rmas�.
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("Otel Api Cors", opts =>
    {
        opts.AllowAnyOrigin()  // Herhangi bir kaynaktan gelen isteklere izin verir.
            .AllowAnyHeader()  // Herhangi bir ba�l�k t�r�ne izin verir.
            .AllowAnyMethod(); // Herhangi bir HTTP metoduna (GET, POST, PUT, DELETE vb.) izin verir.
    });
});

// Controller hizmetlerini ekler ve JSON serile�tirme i�in Newtonsoft.Json yap�land�rmas�n� ekler.
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
/*
    - `AddNewtonsoftJson`: JSON serile�tirme ve ayr��t�rma i�lemleri i�in Newtonsoft.Json kullan�l�r.
    - `ReferenceLoopHandling.Ignore`: JSON serile�tirme s�ras�nda nesneler aras�nda d�ng�sel referanslar varsa bunlar� yoksayar.
        �rnek: Entity Framework kullan�rken, bir ana tablo ve alt tablolar aras�nda kar��l�kl� referans varsa,
        bu ayar d�ng�sel referans hatas�n� �nler.
*/

// Swagger yap�land�rmas�
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Uygulaman�n �al��ma zaman�ndaki HTTP pipeline yap�land�rmas�.
if (app.Environment.IsDevelopment())
{
    // Geli�tirme ortam�nda Swagger kullan�m� i�in middleware ekler.
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Belirtilen CORS politikas�n� etkinle�tirir.
app.UseCors("Otel Api Cors");

// Yetkilendirme (Authorization) middleware'i.
app.UseAuthorization();

// Statik dosyalar�n sunulmas�n� etkinle�tirir.
app.UseStaticFiles();

// T�m controller rotalar�n� e�ler.
app.MapControllers();

// Uygulamay� �al��t�r�r.
app.Run();
