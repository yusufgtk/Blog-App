using blogsite.business.Abstract;
using blogsite.business.Concrete;
using blogsite.data.Abstract;
using blogsite.data.Concrete;
using blogsite.webapp.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationContext>(options=>options.UseSqlite("Data Source=C:\\Users\\yusuf\\OneDrive\\Masaüstü\\Blog Site\\BlogSite.db"));

builder.Services.AddIdentity<User,IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

builder.Services.AddScoped<IBlogRepository,BlogRepository>();
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<INewRepository,NewRepository>();

builder.Services.AddScoped<IBlogService,BlogManager>();
builder.Services.AddScoped<ICategoryService,CategoryManager>();
builder.Services.AddScoped<INewService,NewManager>();


builder.Services.Configure<IdentityOptions>(options=>{
        //Password
    options.Password.RequireDigit=true;//Parolanun içerisinde sayı olsun mu?
    options.Password.RequireLowercase=true;//Parolanun içerisinde küçük harf olsun mu?
    options.Password.RequireUppercase=false;//Parolanun içerisinde büyük harf olsun mu?
    options.Password.RequiredLength=6;//Parola Minimum kaç karakter olsun?
    options.Password.RequireNonAlphanumeric=false;//Parolanın içerisinde özel karakter olsun mu?

        //Lockout
    options.Lockout.AllowedForNewUsers=true;//Şifreyi yanlış girme sayısını doldurunca kilitlensin mi?
    options.Lockout.MaxFailedAccessAttempts=5;//Şifreyi en fazla kaçkere yanlış girebilsin?
    options.Lockout.DefaultLockoutTimeSpan=TimeSpan.FromMinutes(5);//Kilitlenen hesap ne kadar süre sonra açılsın?

        //User
    //options.User.AllowedUserNameCharacters="";//User adında İstediğini karakterleri yazın?
    options.User.RequireUniqueEmail=true;//user ların e-mail adresleri benzersiz mi olsun?
    options.SignIn.RequireConfirmedEmail=false;//user mailini onaylatması zorunlu olsun mu?
    options.SignIn.RequireConfirmedPhoneNumber=false;//user telefon no onaylatması zorunlu olsun mu?
});
    //Cookie Ayarları
builder.Services.ConfigureExternalCookie(options=>{
    options.LoginPath="/account/login";//Kullanıcı login değilse nereye yonlendirilsin?
    options.LogoutPath="/account/logout";//Kullanıcı çıkış yaptığında nereye yönlendirilsin?
    options.AccessDeniedPath="/account/accessdenied";//Yekilendirme Admin,seller,costumer vb... Yani yetkisi hangi sayfaya yönlendirilsin?
    options.SlidingExpiration=false;//İstek yaptığında cookie süresi tazelensin mi?
    options.ExpireTimeSpan=TimeSpan.FromMinutes(60);//Cookie nekadar süre sonra silinsin? 
    //Güvenlik
    options.Cookie=new CookieBuilder
    {
        HttpOnly=true,//Sadece Http isteklerini kabul et
        Name=".MorShop.Security.Cookie",//Cookie nin Adı
        SameSite=SameSiteMode.Strict //bu özellik Cookie çalındığında başka bir cihazdan kullanılmasını önler
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
