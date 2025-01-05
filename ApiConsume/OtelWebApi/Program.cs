using OteLProjectBusinessLayer.Conteiner;
using OteLProjectDataAccessLayer.Concrete;
using OtelWebApi.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Veritabaný baðlamýný DI konteynerine ekler
builder.Services.AddDbContext<Context>();

// Dependency Injection yapýlandýrmasý. "ConteinerDependencies" metodu servis baðýmlýlýklarýný ekler.
builder.Services.ConteinerDependencies();
/*
    .NET 7.0 ve üstü için dikkat edilmesi gerekenler:
    - Paketlerin ayný versiyonda yüklü olmasý gerekir.
    - DTO (Data Transfer Object) dosyalarý ile uyumlu Dependency Injection yapýlandýrmasý yapýlmalýdýr.
*/

builder.Services.AddAutoMapper(typeof(AutoMappingConfig));
// AutoMapper yapýlandýrmasýný ekler. Bu, veri nesneleri arasýnda dönüþüm yapmayý kolaylaþtýrýr.

// CORS (Cross-Origin Resource Sharing) yapýlandýrmasý.
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("Otel Api Cors", opts =>
    {
        opts.AllowAnyOrigin()  // Herhangi bir kaynaktan gelen isteklere izin verir.
            .AllowAnyHeader()  // Herhangi bir baþlýk türüne izin verir.
            .AllowAnyMethod(); // Herhangi bir HTTP metoduna (GET, POST, PUT, DELETE vb.) izin verir.
    });
});

// Controller hizmetlerini ekler ve JSON serileþtirme için Newtonsoft.Json yapýlandýrmasýný ekler.
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
/*
    - `AddNewtonsoftJson`: JSON serileþtirme ve ayrýþtýrma iþlemleri için Newtonsoft.Json kullanýlýr.
    - `ReferenceLoopHandling.Ignore`: JSON serileþtirme sýrasýnda nesneler arasýnda döngüsel referanslar varsa bunlarý yoksayar.
        Örnek: Entity Framework kullanýrken, bir ana tablo ve alt tablolar arasýnda karþýlýklý referans varsa,
        bu ayar döngüsel referans hatasýný önler.
*/

// Swagger yapýlandýrmasý
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Uygulamanýn çalýþma zamanýndaki HTTP pipeline yapýlandýrmasý.
if (app.Environment.IsDevelopment())
{
    // Geliþtirme ortamýnda Swagger kullanýmý için middleware ekler.
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Belirtilen CORS politikasýný etkinleþtirir.
app.UseCors("Otel Api Cors");

// Yetkilendirme (Authorization) middleware'i.
app.UseAuthorization();

// Statik dosyalarýn sunulmasýný etkinleþtirir.
app.UseStaticFiles();

// Tüm controller rotalarýný eþler.
app.MapControllers();

// Uygulamayý çalýþtýrýr.
app.Run();
