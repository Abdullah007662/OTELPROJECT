using FluentValidation.AspNetCore;
using OteLProjectDataAccessLayer.Concrete;
using OteLProjectEntityLayer.Concrete;
using OteLProjectWebUI.Mapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentValidation;
using OteLProjectWebUI.Dtos.GuestDTO;
using OteLProjectWebUI.ValidationRules.GuestValidationRules;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();
builder.Services.AddHttpClient();
builder.Services.AddAutoMapper(typeof(AutoMappingConfig));

// FluentValidation yap�land�rmas�
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

// Validat�rlerin bulundu�u assembly'i belirttik
builder.Services.AddValidatorsFromAssemblyContaining<CreateGuestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateGuestValidator>();

// Ayr�ca spesifik validat�rleri manuel ekleyebiliriz
builder.Services.AddTransient<IValidator<CreateGuestDTO>, CreateGuestValidator>();
builder.Services.AddTransient<IValidator<UpdateGuestDTO>, UpdateGuestValidator>();

// MVC ve Razor Pages hizmetleri
builder.Services.AddControllersWithViews();

// MVC yap�land�rmas� i�in AddMvc metodu �a�r�l�yor
builder.Services.AddMvc(config =>
{
    // 1. Yetkilendirme politikas� olu�turuluyor
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser() // Sadece kimli�i do�rulanm�� kullan�c�lar i�in eri�im izni
        .Build(); // Politika olu�turuldu

    // 2. Bu politikay� t�m MVC i�lemleri i�in bir filtre olarak ekliyoruz
    config.Filters.Add(new AuthorizeFilter(policy));
    // Not: Bu filtre global bir yetkilendirme sa�lar, t�m Controller'lar ve Action'lar bu politikay� uygular.
});
// Kullan�c� �erezleriyle ilgili yap�land�rma
builder.Services.ConfigureApplicationCookie(options =>
{
    // �erezin yaln�zca HTTP �zerinden eri�ilebilir olmas�n� sa�lar.
    options.Cookie.HttpOnly = true;

    // �erezin ge�erlilik s�resini belirler. Burada 5 dakika olarak ayarlanm��t�r.
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    // Kullan�c� oturum a�mad���nda y�nlendirilece�i sayfa.
    options.LoginPath = "/Login/Index";
    // Not: "/Login/Index", oturum a�ma i�lemlerinin oldu�u sayfa i�in rota belirler.
});


// Uygulaman�n olu�turulmas�
var app = builder.Build();

// E�er uygulama geli�tirme ortam�nda de�ilse (production ise)
if (!app.Environment.IsDevelopment())
{
    // Hatalar� ele alacak bir genel hata sayfas�na y�nlendirme.
    app.UseExceptionHandler("/Home/Error");
}

// HTTP durum kodlar� i�in �zel hata sayfas�na y�nlendirme
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");
// �rnek: Kullan�c� 404 hata kodu ald���nda "/ErrorPage/Error404" sayfas� g�r�nt�lenir,
// hata kodu "?code=404" parametresi ile birlikte iletilir.

// HTTPS y�nlendirmesi sa�lar (HTTP isteklerini HTTPS'e zorlar).
app.UseHttpsRedirection();

// Statik dosyalar�n (CSS, JS, resimler vb.) sunulmas�n� etkinle�tirir.
app.UseStaticFiles();

// Y�nlendirme i�lemleri i�in middleware ekler.
app.UseRouting();

// Kimlik do�rulama i�lemlerini etkinle�tirir.
app.UseAuthentication();

// Yetkilendirme (Authorization) i�lemlerini etkinle�tirir.
app.UseAuthorization();

// Varsay�lan rota �ablonunu belirler.
// �rnek: "/Home/Index" adresine y�nlendirme yap�l�r.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseAuthentication();
app.UseAuthorization();

// Uygulamay� ba�lat�r.
app.Run();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
