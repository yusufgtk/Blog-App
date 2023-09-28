using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blogsite.data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NumberOfClicks = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Teknoloji" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Bilim" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedAt", "ImageUrl", "NumberOfClicks", "Title" },
                values: new object[] { 1, 1, "Apple, son zamanlarda iPhone modellerinde kameraya yönelik adımlar atıyor. iPhone 15 serisi de bu konuda bir istisna olmadı. iPhone 15 Pro ve Pro Max modelleri ProMotion özelliği sayesinde 120Hz ekran sunuyor olsa da, standart modeller hala 60Hz yenileme hızını destekliyor. Ancak Apple, iPhone 16 ailesinde bunu değiştirebilir.iPhone 16 serisi 120Hz ekrana geçiyor iddiası Apple’ın yüksek yenileme hızına sahip ProMotion ekran teknolojisi şu anda sadece iPhone 15 Pro’larda kullanılıyor. Yeni bir söylenti ise bu özelliğin önümüzdeki yıl iPhone 16’da standart olarak görücüye çıkabileceğini gösteriyor. Yani tüm modeller 120Hz yenileme hızına ulaşacak. Öte yandan bir başka ekran analisti ise Apple’ın ProMotion’ı standart iPhone serisine getirmek için bir yıl daha bekleyeceğini söyledi. Bu, 120Hz yenileme hızına sahip modellerin iPhone 17 ile sunulabileceği anlamına geliyor. Ayrıca bir başka sızıntıda, şu anda sadece Pro Max modelinde bulunan 5x zoom sensörünün, tüm iPhone 16 modellerinde olacağı bildirildi. Daha iyi uzun menzilli istiyor ve Pro Max telefona çok para harcamak istemiyorsanız, iPhone 16 ailesini şimdiden bekleyebilirsiniz. Android tarafında ise 120Hz ekranlar orta seviye cihazlarda bile standart hale gelmiş durumda. 300-500 dolar seviyesindeki birçok model 120Hz OLED ekran kullanıyor. Peki siz bu konu hakkında ne düşünüyorsunuz? Görüşlerinizi yorumlar kısmından bizlerle paylaşmayı unutmayın!", new DateTime(2023, 9, 26, 0, 0, 0, 0, DateTimeKind.Local), "img1.jpg", 0, "iPhone 15 yapamadı: Apple, iPhone 16 ile bir devri kapatacak!" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedAt", "ImageUrl", "NumberOfClicks", "Title" },
                values: new object[] { 2, 1, "Bu haftanın başlarında, İsviçreli öğrenci mühendislerden oluşan bir ekibin 0-100 km/saat hıza ulaşan en hızlı elektrikli araç için yeni bir dünya rekoru kırdığını öğrendik. Bugünün hikayesinde de elektrikli araç menzil rekoru, Münih Teknik Üniversitesi öğrencileri tarafından tasarlanıp üretilen başka bir elektrikli araç tarafından kırıldı. Elektrikli araç menzil rekorunu üniversite öğrencileri kırdı Muc22 adı verilen araba, verimlilik için üretildi. Münih havaalanında yapılan altı günlük bir testte, tek şarjla yeni bir mesafe rekoru kırdı. Öyle ki tek şarjla 2574 km yol katetti. Daha az şarjla pil kapasitesi birçok plug-in hibritten daha fazla: yalnızca 15,5 kWh. Muc22’nin özellikleri oldukça etkileyici. Öncelikle, aerodinamik EV’nin azami hızı yalnızca 42 km/saat olup ağırlığı sürücü olmadan yalnızca 170 kg. Hava akışı açısından optimize edilmiş karoser, kaplanmış arka tekerleklere ve yalnızca 0,159’luk bir sürtünme katsayısına sahip. Ekip 2022’de arabayı tanıttığında, bir çift 440 W elektrik motoruna sahipti. ancak Muc22’de 400 W bulunuyor. 400 W’lık sayı, bugün satışta olan en güçsüz elektrikli araç olan Mazda MX-30’dan 268 kat daha az güçlü. Rekor denemesi, Münih Havalimanı’ndaki boş bir hangarda hava şartlarından kaynaklanan herhangi bir müdahalenin önüne geçilerek gerçekleştirildi. Önceki rekor 1.609 km idi. Ancak ekip bu mesafeye yalnızca dört gün sonra ulaştı ve akü henüz boşalmadığından araba yoluna devam etti. Nihai mesafeleri mevcut rekoru yüzde 60 oranında kırarak elektrik enerjisi tüketiminde 0,6 kWh/100 km’ye ulaştı. Bağlamda, bugün satışta olan en verimli EV’ler Hyundai Ioniq 6 ve Lucid Air’dir ve bunların her biri 14,8 kWh/100 km elektrik enerjisi tüketen bir versiyona sahip. Hatta bu enerji tüketiminin normal üretimdeki otomobillerde daha da artması bekleniyor. Bu kapsamda Münih Teknik Üniversitesi öğrencilerinin çok başarılı bir iş çıkardığı tartışılmaz bir gerçek. Ekip, Muc22’den sonraki hedeflerinin ondan çok daha iyisini üretmek olduğunu belirtti. Peki siz bu konu hakkında neler düşünüyorsunuz? Düşüncelerinizi yorumlar kısmından bizlerle paylaşabilirsiniz.", new DateTime(2023, 9, 26, 0, 0, 0, 0, DateTimeKind.Local), "img2.jpg", 0, "Tek şarjla Türkiye’den Almanya: Elektrikli araç menzil rekoru kırıldı!" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedAt", "ImageUrl", "NumberOfClicks", "Title" },
                values: new object[] { 3, 2, "Solar Orbiter, şimdiye kadar Güneş’e gönderilen en karmaşık bilimsel laboratuvar olma unvanını taşıyor. Bilim adamları, Solar Orbiter’ın altı uzaktan algılama cihazı ve dört gömülü cihazından elde edilen gözlemleri birleştirerek bazı derin sorulara yanıt bulmayı umuyorlar. Şimdi de tam 65 yıldır süregelen bir Güneş gizemi, ESA’nın bu uzay aracı sayesinde çözülüyor. Güneş gizemi ne anlama geliyor? Söz konusu gizem Güneş’in atmosferinin neden bu kadar sıcak olduğudur. Bu “koronal ısınma sorunu” gökbilimcileri uzun süredir şaşırtıyor. Ancak Parker Solar Probe (NASA’nın uzay sondası) ile Solar Orbiter arasındaki ortak operasyon sonunda bu gizeme bir cevap sağlayabilir. Avrupa Uzay Ajansı’nın (ESA) yeni bir gönderisine göre Solar Orbiter, Güneş’i biraz farklı bir açıdan gözlemleyebilmesini sağlamak için yakın zamanda konumu değiştirildi ve Parker Solar Probe ile bir senkronize iş birliğine tabi tutuldu. ESA, bunun Solar Orbiter’ın Parker Solar Probe’un aldığı ölçümlerle senkronize olmasını sağladığını ve bunun daha önce yapılan hiçbir şeye benzemeyen çığır açan bir ölçüm sağladığını söylüyor. Güneş’in korona olarak bilinen atmosferi son derece sıcaktır. Güneşimizin çok büyük bir yıldız olduğu, ancak atmosferin kabaca bir milyon santigrat derece ölçüldüğü göz önüne alındığında, belki bu yetersiz bir ifade gibi görünebilir. Güneş’in atmosferinin sıcak olduğu bariz gerçeğine rağmen, neden bu kadar sıcak olduğunun gizemi bilim adamlarını şaşırtıyor. Çünkü Güneş’in yüzeyi aslında sadece 6.000 santigrat derece. Böylece korona bir şekilde yüzeyden 150 kat daha sıcak. Bu koronal ısınma sorunu, Güneş’i inceleme görevlerinin merkezinde yer alıyor. Bu görevler ayrı ayrı ilgi çekici bilgiler sağlarken, birlikte çalışırken daha da derinlemesine ölçümler sağlayabilirler ve bu da sonunda bu ilgi çekici gizemi çözmemize yardımcı olabilir. Enerjinin Güneş atmosferindeki plazmaya aktarılmasına yönelik bir yöntemin olduğu inancı var. Ancak bilim insanları bunun tam olarak ne olduğunu hiçbir zaman söyleyemediler. Artık Solar Orbit, kendisini yeniden konumlandırdığına göre, sonunda daha fazla yanıt alabilmemiz mümkün. Şimdiye kadarki en başarılı güneş görevi riske atılsa da bu gizemi çözmek için değeceğini söyleyebiliriz. Peki siz bu konu hakkında neler düşünüyorsunuz? Düşüncelerinizi yorumlar kısmından bizlerle paylaşabilirsiniz.", new DateTime(2023, 9, 26, 0, 0, 0, 0, DateTimeKind.Local), "img3.jpg", 0, "65 yıllık Güneş gizemi çözülüyor!" });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_CategoryId",
                table: "Blogs",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
