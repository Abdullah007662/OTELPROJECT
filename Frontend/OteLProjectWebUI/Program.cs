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

// FluentValidation yapýlandýrmasý
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

// Validatörlerin bulunduðu assembly'i belirttik
builder.Services.AddValidatorsFromAssemblyContaining<CreateGuestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateGuestValidator>();

// Ayrýca spesifik validatörleri manuel ekleyebiliriz
builder.Services.AddTransient<IValidator<CreateGuestDTO>, CreateGuestValidator>();
builder.Services.AddTransient<IValidator<UpdateGuestDTO>, UpdateGuestValidator>();

// MVC ve Razor Pages hizmetleri
builder.Services.AddControllersWithViews();

// MVC yapýlandýrmasý için AddMvc metodu çaðrýlýyor
builder.Services.AddMvc(config =>
{
    // 1. Yetkilendirme politikasý oluþturuluyor
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser() // Sadece kimliði doðrulanmýþ kullanýcýlar için eriþim izni
        .Build(); // Politika oluþturuldu

    // 2. Bu politikayý tüm MVC iþlemleri için bir filtre olarak ekliyoruz
    config.Filters.Add(new AuthorizeFilter(policy));
    // Not: Bu filtre global bir yetkilendirme saðlar, tüm Controller'lar ve Action'lar bu politikayý uygular.
});
// Kullanýcý çerezleriyle ilgili yapýlandýrma
builder.Services.ConfigureApplicationCookie(options =>
{
    // Çerezin yalnýzca HTTP üzerinden eriþilebilir olmasýný saðlar.
    options.Cookie.HttpOnly = true;

    // Çerezin geçerlilik süresini belirler. Burada 5 dakika olarak ayarlanmýþtýr.
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    // Kullanýcý oturum açmadýðýnda yönlendirileceði sayfa.
    options.LoginPath = "/Login/Index";
    // Not: "/Login/Index", oturum açma iþlemlerinin olduðu sayfa için rota belirler.
});


// Uygulamanýn oluþturulmasý
var app = builder.Build();

// Eðer uygulama geliþtirme ortamýnda deðilse (production ise)
if (!app.Environment.IsDevelopment())
{
    // Hatalarý ele alacak bir genel hata sayfasýna yönlendirme.
    app.UseExceptionHandler("/Home/Error");
}

// HTTP durum kodlarý için özel hata sayfasýna yönlendirme
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");
// Örnek: Kullanýcý 404 hata kodu aldýðýnda "/ErrorPage/Error404" sayfasý görüntülenir,
// hata kodu "?code=404" parametresi ile birlikte iletilir.

// HTTPS yönlendirmesi saðlar (HTTP isteklerini HTTPS'e zorlar).
app.UseHttpsRedirection();

// Statik dosyalarýn (CSS, JS, resimler vb.) sunulmasýný etkinleþtirir.
app.UseStaticFiles();

// Yönlendirme iþlemleri için middleware ekler.
app.UseRouting();

// Kimlik doðrulama iþlemlerini etkinleþtirir.
app.UseAuthentication();

// Yetkilendirme (Authorization) iþlemlerini etkinleþtirir.
app.UseAuthorization();

// Varsayýlan rota þablonunu belirler.
// Örnek: "/Home/Index" adresine yönlendirme yapýlýr.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseAuthentication();
app.UseAuthorization();

// Uygulamayý baþlatýr.
app.Run();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
