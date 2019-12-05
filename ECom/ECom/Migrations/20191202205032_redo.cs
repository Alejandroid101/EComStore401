using Microsoft.EntityFrameworkCore.Migrations;

namespace ECom.Migrations
{
    public partial class redo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sku = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Color = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    CartId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => new { x.CartId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_CartItems_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Color", "Description", "Image", "Name", "Price", "Sku", "Year" },
                values: new object[,]
                {
                    { 1, "White", "The Ferrari 488 (Type F142M) is a mid-engine sports car produced by the Italian automobile manufacturer Ferrari. The car is an update to the 458 with notable exterior and performance changes. The car is powered by a 3.9 - litre twin - turbocharged V8 engine, smaller in displacement but generating a higher power output than the 458's naturally aspirated engine. The 488 GTB was named 'The Supercar of the Year 2015' by car magazine Top Gear, as well as becoming Motor Trend's 2017 'Best Driver's Car'. ", "/assets/ferrari.jpg", "Ferrari 488 Spider", 280900.00m, "TGYHBVCD", 2019 },
                    { 2, "Grey", "An icon cannot be reinvented, it can only be challenged. And only Aventador could surpass itself. This Lamborghini Aventador is a mid-engine sports car produced by the Italian automotive manufacturer Lamborghini. In keeping with Lamborghini tradition, the Aventador is named after a fighting bull.", "/assets/lambo.jpg", "Lamborghini Aventador S", 417826.00m, "FLOMIJER", 2019 },
                    { 3, "White", "The Rolls-Royce Ghost is a British full-size luxury car manufactured by Rolls-Royce Motor Cars. The 'Ghost' nameplate, named in honour of the Silver Ghost, a car first produced in 1906, was announced in April 2009 at the Auto Shanghai show. During development, the Ghost was known as the 'RR04'.", "/assets/ghost.jpg", "Rolls-Royce Ghost", 351900.00m, "PQASKFGV", 2019 },
                    { 4, "Grey", "The Porsche 911 is a two-door, 2+2 high performance rear-engined sports car made since in 1963 by Porsche AG of Stuttgart, Germany. It has a rear-mounted flat-six engine and all round independent suspension. It has undergone continuous development, though the basic concept has remained unchanged.", "/assets/911.jpg", "Porsche 911", 113300.00m, "MVNCBRTY", 2019 },
                    { 5, "Black", "A handcrafted 621-hp biturbo V12 teams with a road-scanning, curve-tilting, fully active suspension in the AMG S 65. It's more than luxurious, and more than powerful. It's a sensation of majesty and magic no other sedan can match.", "/assets/benz.jpg", "Mercedes Benz S65", 230400.00m, "LOFJKMDR", 2019 },
                    { 6, "White", "The BMW i8 is a plug-in hybrid sports car developed by BMW. The i8 is part of BMW's electric fleet 'Project i' being marketed as a new sub-brand, BMW i. The BMW i8 accelerates from 0 to 100 km / h(62 mph) in 4.4 seconds and has an electronic limited top speed of 250 km / h(155 mph).", "/assets/bmw.jpg", "BMW i8", 147500.00m, "ASGTEFJN", 2019 },
                    { 7, "White", "The Tesla Roadster is an upcoming all-electric battery-powered four-seater sports car made by Tesla, Inc. Tesla has said it will be capable of 0 to 97 km/h (0 to 60 mph) in 1.9 seconds, quicker than any street legal production car to date at its announcement in November 2017. The Roadster is the successor to Tesla's first production car, which was the 2008 Roadster.", "/assets/tesla.jpg", "Tesla Roadster", 200000.00m, "QSDEWFTG", 2020 },
                    { 8, "Grey", "The Jaguar F-type is a quintessential sports car, with a head-turning design and high-octane performance. This Jaguar two-seater takes form as either a sleek coupe or a stunning convertible. Along with a snarling supercharged V-6, the 2020 F-type offers a more affordable turbocharged four-cylinder engine.", "/assets/jag.jpg", "Jaguar F-TYPE", 61600.00m, "POLEDFRT", 2019 },
                    { 9, "Light Grey", "The Audi R8 is a mid-engine, 2-seater sports car, which uses Audi's trademark quattro permanent all-wheel drive system. It was introduced by the German car manufacturer Audi AG in 2006. The car is exclusively designed, developed, and manufactured by Audi AG's private subsidiary company manufacturing high performance automotive parts, Audi Sport GmbH (formerly quattro GmbH), and is based on the Lamborghini Gallardo and presently the Huracán platform.", "/assets/audi.jpg", "Audi R8", 169900.00m, "JGNMHKTE", 2019 },
                    { 10, "Black", "The Bentley Bentayga is a mid-size, front-engine, all-wheel drive, five-door luxury crossover marketed by Bentley, beginning with model year 2016. Its body is manufactured at the Volkswagen Zwickau-Mosel plant, then painted by Paintbox Editions in Banbury, and finally assembled at the company's Crewe factory.", "/assets/bentley.jpg", "Bentley Bentayga", 165000.00m, "BGHVDPWO", 2019 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
