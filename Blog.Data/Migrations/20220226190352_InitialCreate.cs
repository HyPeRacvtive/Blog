using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Descripton = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "VARBINARY(500)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Descreption = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ViewsCount = table.Column<int>(type: "int", nullable: false),
                    CommentCount = table.Column<int>(type: "int", nullable: false),
                    SeoAuthor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SeoDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SeoTags = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note" },
                values: new object[,]
                {
                    { 1, "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 967, DateTimeKind.Local).AddTicks(4927), "C# Programlama Dili İLe İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 967, DateTimeKind.Local).AddTicks(4936), "C#", "C# Blog Kategorisi" },
                    { 2, "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 967, DateTimeKind.Local).AddTicks(4945), "C++ Programlama Dili İLe İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 967, DateTimeKind.Local).AddTicks(4946), "C++", "C++ Blog Kategorisi" },
                    { 3, "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 967, DateTimeKind.Local).AddTicks(4950), "JavaScript Programlama Dili İLe İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 967, DateTimeKind.Local).AddTicks(4951), "JavaScript", "JavaScript Blog Kategorisi" },
                    { 4, "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 967, DateTimeKind.Local).AddTicks(4955), "Pyton Programlama Dili İLe İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 967, DateTimeKind.Local).AddTicks(4957), "Pyton", "Pyton Blog Kategorisi" },
                    { 5, "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 967, DateTimeKind.Local).AddTicks(4961), "Kotlin Programlama Dili İLe İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 967, DateTimeKind.Local).AddTicks(4962), "Kotlin", "Kotlin Blog Kategorisi" },
                    { 6, "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 967, DateTimeKind.Local).AddTicks(4966), "Asp.Net Programlama Dili İLe İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 967, DateTimeKind.Local).AddTicks(4968), "Asp.Net", "Asp.Net Blog Kategorisi" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Descripton", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note" },
                values: new object[,]
                {
                    { 1, "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 979, DateTimeKind.Local).AddTicks(3438), "Tüm Haklara Sahiptir", true, false, "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 979, DateTimeKind.Local).AddTicks(3447), "Admin", "Admin Rolüdür" },
                    { 2, "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 979, DateTimeKind.Local).AddTicks(3459), "Admin Kadar Olmasada Var Biraz Hakkı işte", true, false, "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 979, DateTimeKind.Local).AddTicks(3461), "Moderatör", "Moderatör Rolüdür" },
                    { 3, "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 979, DateTimeKind.Local).AddTicks(3465), "Hiç Hakka Sahip Değildir. Öyle Arada Gelir Gider.", true, false, "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 979, DateTimeKind.Local).AddTicks(3466), "User", "User Rolsüzlüğüdür" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Descreption", "Email", "FirstName", "IsActive", "IsDeleted", "LastName", "ModifiedByName", "ModifiedDate", "Note", "PasswordHash", "Picture", "RoleId", "UserName" },
                values: new object[,]
                {
                    { 1, "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 977, DateTimeKind.Local).AddTicks(6802), "Bu Programın Yazarı", "mehmetgon@hotmail.com", "Mehmet", true, false, "Gön", "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 977, DateTimeKind.Local).AddTicks(6813), "Admin Kullanıcısı", new byte[] { 48, 49, 57, 50, 48, 50, 51, 97, 55, 98, 98, 100, 55, 51, 50, 53, 48, 53, 49, 54, 102, 48, 54, 57, 100, 102, 49, 56, 98, 53, 48, 48 }, "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSX4wVGjMQ37PaO4PdUVEAliSLi8-c2gJ1zvQ&usqp=CAU", 1, "hyperprince" },
                    { 4, "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 977, DateTimeKind.Local).AddTicks(7032), "Bu Programın Yazarının Oğlu", "mfg@outlook.com", "Muhammet Fettah", true, false, "Gön", "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 977, DateTimeKind.Local).AddTicks(7033), "Babadan Torpilli Admin", new byte[] { 52, 56, 49, 56, 102, 49, 50, 98, 97, 99, 49, 52, 52, 53, 56, 51, 48, 54, 51, 54, 52, 57, 97, 100, 52, 57, 100, 101, 100, 52, 54, 54 }, "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSX4wVGjMQ37PaO4PdUVEAliSLi8-c2gJ1zvQ&usqp=CAU", 1, "mfg" },
                    { 2, "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 977, DateTimeKind.Local).AddTicks(7018), "Bu Programın Yazarının arkadaşı", "ilkkanml@outlook.com", "Vehbi İlkkan", true, false, "Memili", "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 977, DateTimeKind.Local).AddTicks(7019), "Moderatör Kullanıcısı", new byte[] { 52, 97, 99, 98, 52, 98, 99, 50, 50, 52, 97, 99, 98, 98, 101, 51, 99, 50, 98, 102, 100, 99, 97, 97, 51, 57, 97, 52, 51, 50, 52, 101 }, "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSX4wVGjMQ37PaO4PdUVEAliSLi8-c2gJ1zvQ&usqp=CAU", 2, "ilkkanml" },
                    { 3, "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 977, DateTimeKind.Local).AddTicks(7025), "Bu Programın Yazarının Arkadaşının Eşi", "aym@outlook.com", "Açelya", true, false, "Yüce Memili", "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 977, DateTimeKind.Local).AddTicks(7026), "Normal Üye Kullanıcısı", new byte[] { 101, 53, 49, 57, 101, 55, 48, 52, 99, 50, 51, 101, 97, 102, 48, 56, 55, 56, 55, 102, 98, 56, 102, 57, 51, 99, 54, 98, 101, 100, 51, 50 }, "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSX4wVGjMQ37PaO4PdUVEAliSLi8-c2gJ1zvQ&usqp=CAU", 3, "aym" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "CommentCount", "Content", "CreatedByName", "CreatedDate", "Date", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "SeoAuthor", "SeoDescription", "SeoTags", "Thumbnail", "Title", "UserId", "ViewsCount" },
                values: new object[,]
                {
                    { 1, 1, 1, "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.", "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 964, DateTimeKind.Local).AddTicks(8193), new DateTime(2022, 2, 26, 22, 3, 51, 964, DateTimeKind.Local).AddTicks(7457), true, false, "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 964, DateTimeKind.Local).AddTicks(8563), "C# 9.0 ve .NET 5 Yenilikleri", "Mehmet GÖN", "C# 9.0 ve .NET 5 Yenilikleri", "C#,C# 9, .NET 5, .NET Framework, .NET Core", "Default.jpg", "C# 9.0 ve .NET 5 Yenilikleri", 1, 100 },
                    { 5, 5, 1, "Lorem Ipsum pasajlarının birçok çeşitlemesi vardır. Ancak bunların büyük bir çoğunluğu mizah katılarak veya rastgele sözcükler eklenerek değiştirilmişlerdir. Eğer bir Lorem Ipsum pasajı kullanacaksanız, metin aralarına utandırıcı sözcükler gizlenmediğinden emin olmanız gerekir. İnternet'teki tüm Lorem Ipsum üreteçleri önceden belirlenmiş metin bloklarını yineler. Bu da, bu üreteci İnternet üzerindeki gerçek Lorem Ipsum üreteci yapar. Bu üreteç, 200'den fazla Latince sözcük ve onlara ait cümle yapılarını içeren bir sözlük kullanır. Bu nedenle, üretilen Lorem Ipsum metinleri yinelemelerden, mizahtan ve karakteristik olmayan sözcüklerden uzaktır.", "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 964, DateTimeKind.Local).AddTicks(9385), new DateTime(2022, 2, 26, 22, 3, 51, 964, DateTimeKind.Local).AddTicks(9384), true, false, "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 964, DateTimeKind.Local).AddTicks(9387), "Asp.net Yenilikleri", "Mehmet GÖN", "Asp.net Yenilikleri", "Asp.net Yenilikleri,Modern Asp.net,Asp.net", "Default.jpg", "Asp.net Yenilikleri", 1, 346 },
                    { 4, 4, 1, "Lorem Ipsum pasajlarının birçok çeşitlemesi vardır. Ancak bunların büyük bir çoğunluğu mizah katılarak veya rastgele sözcükler eklenerek değiştirilmişlerdir. Eğer bir Lorem Ipsum pasajı kullanacaksanız, metin aralarına utandırıcı sözcükler gizlenmediğinden emin olmanız gerekir. İnternet'teki tüm Lorem Ipsum üreteçleri önceden belirlenmiş metin bloklarını yineler. Bu da, bu üreteci İnternet üzerindeki gerçek Lorem Ipsum üreteci yapar. Bu üreteç, 200'den fazla Latince sözcük ve onlara ait cümle yapılarını içeren bir sözlük kullanır. Bu nedenle, üretilen Lorem Ipsum metinleri yinelemelerden, mizahtan ve karakteristik olmayan sözcüklerden uzaktır.", "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 964, DateTimeKind.Local).AddTicks(9376), new DateTime(2022, 2, 26, 22, 3, 51, 964, DateTimeKind.Local).AddTicks(9375), true, false, "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 964, DateTimeKind.Local).AddTicks(9378), "Pyton Yenilikleri", "Mehmet GÖN", "Pyton Yenilikleri", "Pyton Yenilikleri,Modern Pyton,Pyton", "Default.jpg", "Pyton Yenilikleri", 4, 521 },
                    { 2, 2, 1, "Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır. Ayrıca arama motorlarında 'lorem ipsum' anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir. Yıllar içinde, bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir.", "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 964, DateTimeKind.Local).AddTicks(9362), new DateTime(2022, 2, 26, 22, 3, 51, 964, DateTimeKind.Local).AddTicks(9360), true, false, "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 964, DateTimeKind.Local).AddTicks(9363), "C++ 11 ve 19 Yenilikleri", "Mehmet GÖN", "C++ 11 ve 19 Yenilikleri", "C++ 11, C++ 19, C++ Yenilikleri", "Default.jpg", "C++ 11 ve 19 Yenilikleri", 2, 300 },
                    { 3, 3, 1, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.", "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 964, DateTimeKind.Local).AddTicks(9369), new DateTime(2022, 2, 26, 22, 3, 51, 964, DateTimeKind.Local).AddTicks(9368), true, false, "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 964, DateTimeKind.Local).AddTicks(9371), "JavaScript Yenilikleri", "Mehmet GÖN", "JavaScript Yenilikleri", "JavaScript Yenilikleri,Modern JavaScript,JavaScript,ES2019,ES2020", "Default.jpg", "JavaScript ES2019 ve ES2020 Yenilikleri", 3, 258 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ArticleId", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "Text" },
                values: new object[,]
                {
                    { 1, 1, "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 981, DateTimeKind.Local).AddTicks(2251), true, false, "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 981, DateTimeKind.Local).AddTicks(2260), "C# Makale Yorumu", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed urna enim, lacinia porttitor egestas et, interdum et risus. Integer tincidunt tempus rutrum. Duis tristique tortor tellus, quis rhoncus nulla sollicitudin at. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nullam in odio dictum, tempus eros sit amet, fringilla justo. Maecenas eu arcu tortor. Donec congue massa a placerat varius. Cras felis dolor, cursus et ullamcorper vitae, fermentum a nisl. Aliquam erat volutpat." },
                    { 5, 5, "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 981, DateTimeKind.Local).AddTicks(2359), true, false, "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 981, DateTimeKind.Local).AddTicks(2361), "Asp.net Makale Yorumu", "Donec ex erat, varius vitae arcu ac, euismod sagittis lectus. Fusce feugiat quam in dui malesuada, in tincidunt nunc tincidunt. Mauris ultrices ligula sit amet laoreet feugiat. Nulla laoreet rutrum libero, sit amet lobortis leo. Aenean posuere ipsum condimentum lacus faucibus, at tempor metus cursus. Aenean mauris nibh, volutpat id ultrices id, varius ut magna. Donec a ligula sed eros vestibulum porta sit amet et leo. Pellentesque eu orci lectus. Aenean semper vitae nisl quis semper. Suspendisse in nunc lacus. Vestibulum volutpat lectus tellus, sed sollicitudin felis elementum non. Aenean malesuada congue orci sed placerat. Nullam feugiat tellus sit amet tellus accumsan fermentum. Vestibulum euismod, nisl eu porttitor rhoncus, ligula metus hendrerit est, at blandit augue massa quis ante. Morbi ac mi at lectus fringilla bibendum." },
                    { 4, 4, "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 981, DateTimeKind.Local).AddTicks(2354), true, false, "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 981, DateTimeKind.Local).AddTicks(2355), "Pyton Makale Yorumu", "Vestibulum at porta orci. Aenean efficitur justo elit, ut dictum erat lobortis eu. Donec lacinia nibh turpis, sed blandit massa mattis vitae. Sed ex justo, pellentesque in tellus eget, rhoncus venenatis nibh. Cras feugiat nibh enim, et pulvinar quam feugiat et. Morbi ut tellus a mauris dapibus pharetra pharetra at metus. Aenean magna nisl, sodales sed dignissim in, dapibus eu mauris. In cursus magna vitae est accumsan pretium. Donec vitae dui nisi. Cras in risus nec turpis fringilla \"imperdiet\" vel et purus. Integer tristique vitae nunc laoreet porttitor. Sed arcu nisi, feugiat eget vulputate eget, tempus sed turpis. Sed ac ligula in odio pretium dignissim ut a ligula. Praesent mattis et neque at rhoncus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam non magna vestibulum, posuere ante eget, tempus odio." },
                    { 2, 2, "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 981, DateTimeKind.Local).AddTicks(2272), true, false, "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 981, DateTimeKind.Local).AddTicks(2274), "C++ Makale Yorumu", "Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nulla aliquam leo nisl, ac tempus velit volutpat sed. Mauris mattis tellus non lobortis viverra. Etiam a efficitur nisl. Curabitur id accumsan sem. Suspendisse potenti. Nam luctus tempor nisi, quis elementum magna sodales sit amet. Curabitur vel rutrum urna. Mauris felis purus, tempor vitae congue vel, rutrum eu magna. Nullam pulvinar, arcu sit amet euismod tincidunt, leo lorem dictum turpis, eget tristique nunc dui vel sem." },
                    { 3, 3, "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 981, DateTimeKind.Local).AddTicks(2348), true, false, "InitialCreate", new DateTime(2022, 2, 26, 22, 3, 51, 981, DateTimeKind.Local).AddTicks(2349), "JavaScript Makale Yorumu", "Nulla facilisi. Vestibulum eget porta lorem, ac placerat nibh. Nullam lectus massa, consequat et ligula eget, interdum hendrerit lectus. Sed varius tincidunt ligula, vel tempus lacus sollicitudin fringilla. Donec in commodo risus. Maecenas ornare eros vitae metus posuere congue. Pellentesque tincidunt vulputate malesuada." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ArticleId",
                table: "Comments",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
