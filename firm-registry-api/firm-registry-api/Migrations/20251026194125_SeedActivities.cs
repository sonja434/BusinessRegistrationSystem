using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace firm_registry_api.Migrations
{
    /// <inheritdoc />
    public partial class SeedActivities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActivitySectorId",
                table: "ActivityGroups",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ActivitySectors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivitySectors", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ActivitySectors",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "A", "Poljoprivreda, šumarstvo i ribarstvo" },
                    { 2, "B", "Rudarstvo" },
                    { 3, "C", "Prerađivačka industrija" },
                    { 4, "D", "Snabdevanje električnom energijom, gasom i parom" },
                    { 5, "E", "Snabdevanje vodom i upravljanje otpadnim vodama" },
                    { 6, "F", "Građevinarstvo" },
                    { 7, "G", "Trgovina na veliko i malo i popravka motornih vozila" },
                    { 8, "H", "Saobraćaj i skladištenje" },
                    { 9, "I", "Usluge smeštaja i ishrane" },
                    { 10, "J", "Informisanje i komunikacije" },
                    { 11, "K", "Finansijske delatnosti i delatnost osiguranja" },
                    { 12, "L", "Poslovanje nekretninama" },
                    { 13, "M", "Stručne, naučne, inovacione i tehničke delatnosti" },
                    { 14, "N", "Administrativne i pomoćne uslužne delatnosti" },
                    { 15, "O", "Državna uprava i obavezno socijalno osiguranje" },
                    { 16, "P", "Obrazovanje" },
                    { 17, "Q", "Zdravstvena i socijalna zaštita" },
                    { 18, "R", "Umetnost, zabava i rekreacija" },
                    { 19, "S", "Ostale uslužne delatnosti" },
                    { 20, "T", "Delatnost domaćinstva kao poslodavca" },
                    { 21, "U", "Delatnost eksteritorijalnih organizacija i tela" }
                });

            migrationBuilder.InsertData(
                table: "ActivityGroups",
                columns: new[] { "Id", "ActivitySectorId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Poljoprivredna proizvodnja, lov i uslužne delatnosti" },
                    { 2, 1, "Šumarstvo i seča drveća" },
                    { 3, 1, "Ribarstvo i akvakulture" },
                    { 4, 2, "Eksploatacija uglja" },
                    { 5, 2, "Eksploatacija sirove nafte i prirodnog gasa" },
                    { 6, 2, "Eksploatacija ruda metala" },
                    { 7, 2, "Ostalo rudarstvo" },
                    { 8, 2, "Uslužne delatnosti u rudarstvu" },
                    { 9, 3, "Proizvodnja prehrambenih proizvoda" },
                    { 10, 3, "Proizvodnja pića" },
                    { 11, 3, "Proizvodnja duvanskih proizvoda" },
                    { 12, 3, "Proizvodnja tekstila" },
                    { 13, 3, "Proizvodnja odevnih predmeta" },
                    { 14, 3, "Proizvodnja kože i predmeta od kože" },
                    { 15, 3, "Prerada drveta i proizvodi od drveta, osim nameštaja" },
                    { 16, 3, "Proizvodnja papira i proizvoda od papira" },
                    { 17, 3, "Štampanje i umnožavanje audio i video zapisa" },
                    { 18, 3, "Proizvodnja koksa i derivata nafte" },
                    { 19, 3, "Proizvodnja hemikalija i hemijskih proizvoda" },
                    { 20, 3, "Proizvodnja osnovnih farmaceut. proizvoda i preparata" },
                    { 21, 3, "Proizvodnja proizvoda od gume i plastike" },
                    { 22, 3, "Proizvodnja proizvoda od nemetalnih minerala" },
                    { 23, 3, "Proizvodnja osnovnih metala" },
                    { 24, 3, "Proizvodnja metalnih proizvoda, osim mašina" },
                    { 25, 3, "Proizvodnja računara, elektronskih i optičkih proizv." },
                    { 26, 3, "Proizvodnja električne opreme" },
                    { 27, 3, "Proizvodnja nepomenutih mašina i opreme" },
                    { 28, 3, "Proizvodnja motornih vozila i prikolica" },
                    { 29, 3, "Proizvodnja ostalih saobraćajnih sredstava" },
                    { 30, 3, "Proizvodnja nameštaja" },
                    { 31, 3, "Ostale prerađivačke delatnosti" },
                    { 32, 3, "Popravka i montaža mašina i opreme" },
                    { 33, 4, "Snabdevanje električnom energijom, gasom i parom" },
                    { 34, 5, "Skupljanje, prečišćavanje i distribucija vode" },
                    { 35, 5, "Uklanjanje otpadnih voda" },
                    { 36, 5, "Sakupljanje, tretman i odlaganje otpada" },
                    { 37, 5, "Sanacija, rekultivacija i upravljanje otpadom" },
                    { 38, 6, "Izgradnja zgrada" },
                    { 39, 6, "Izgradnja ostalih građevina" },
                    { 40, 6, "Specijalizovani građevinski radovi" },
                    { 41, 7, "Trgovina na veliko i malo i popravka motornih vozila" },
                    { 42, 7, "Trgovina na veliko, osim trgovine motornim vozilima" },
                    { 43, 7, "Trgovina na malo, osim trgovine motornim vozilima" },
                    { 44, 8, "Kopneni saobraćaj i cevovodni transport" },
                    { 45, 8, "Vodeni saobraćaj" },
                    { 46, 8, "Vazdušni saobraćaj" },
                    { 47, 8, "Skladištenje i prateće aktivnosti u saobraćaju" },
                    { 48, 8, "Poštanske aktivnosti" },
                    { 49, 9, "Smeštaj" },
                    { 50, 9, "Delatnost pripremanja i posluživanja hrane i pića" },
                    { 51, 10, "Izdavačke delatnosti" },
                    { 52, 10, "Kinematografska, televizijska i muzička produkcija" },
                    { 53, 10, "Programske aktivnosti i emitovanje" },
                    { 54, 10, "Telekomunikacije" },
                    { 55, 10, "Računarsko programiranje i konsultantske delatnosti" },
                    { 56, 10, "Informacione uslužne delatnosti" },
                    { 57, 11, "Finansijske usluge, osim osiguranja i penz. fondova" },
                    { 58, 11, "Osiguranje, reosiguranje i penzijski fondovi" },
                    { 59, 11, "Pomoćne delatnosti u finans. uslugama i osiguranju" },
                    { 60, 12, "Poslovanje nekretninama" },
                    { 61, 13, "Pravni i računovodstveni poslovi" },
                    { 62, 13, "Upravljačke delatnosti i savetovanje" },
                    { 63, 13, "Arhitektonske i inženjerske delatnosti" },
                    { 64, 13, "Naučno istraživanje i razvoj" },
                    { 65, 13, "Reklamiranje i istraživanje tržišta" },
                    { 66, 13, "Ostale stručne, naučne i tehničke delatnosti" },
                    { 67, 13, "Veterinarska delatnost" },
                    { 68, 14, "Iznajmljivanje i lizing" },
                    { 69, 14, "Delatnosti zapošljavanja" },
                    { 70, 14, "Delatnost putn. agencija, tur-operatora i rezervacije" },
                    { 71, 14, "Zaštitne i istražne delatnosti" },
                    { 72, 14, "Usluge održavanja objekata i okoline" },
                    { 73, 14, "Kancelarijsko-administrativne i pomoćne delatnosti" },
                    { 74, 15, "Javna uprava i odbrana i obavezno socijalno osiguranje" },
                    { 75, 16, "Obrazovanje" },
                    { 76, 17, "Zdravstvene delatnosti" },
                    { 77, 17, "Socijalna zaštita sa smeštajem" },
                    { 78, 17, "Socijalna zaštita bez smeštaja" },
                    { 79, 18, "Stvaralačke, umetničke i zabavne delatnosti" },
                    { 80, 18, "Delatnost biblioteka, arhiva, muzeja i galerija" },
                    { 81, 18, "Kockanje i klađenje" },
                    { 82, 18, "Sportske, zabavne i rekreativne delatnosti" },
                    { 83, 19, "Delatnost udruženja" },
                    { 84, 19, "Popravka računara i predmeta za ličnu upotrebu" },
                    { 85, 19, "Ostale lične uslužne delatnosti" },
                    { 86, 20, "Domaćinstava koja zapošljavaju poslugu" },
                    { 87, 20, "Domaćinstava koja proizvode robu i usluge za sebe" },
                    { 88, 21, "Delatnost eksteritorijalnih organizacija i tela" }
                });

            migrationBuilder.InsertData(
                table: "ActivityCodes",
                columns: new[] { "Id", "ActivityGroupId", "Code", "Description" },
                values: new object[,]
                {
                    { 1, 1, "1.11", "Gajenje žita (osim pirinča), leguminoza i uljarica" },
                    { 2, 1, "1.12", "Gajenje pirinča" },
                    { 3, 1, "1.13", "Gajenje povrća, korenastih i krtolastih biljaka" },
                    { 4, 1, "1.14", "Gajenje šećerne trske" },
                    { 5, 1, "1.15", "Gajenje duvana" },
                    { 6, 1, "1.16", "Gajenje biljaka za proizvodnju vlakana" },
                    { 7, 1, "1.19", "Gajenje ostalih jednogodišnjih i dvogodišnjih biljaka" },
                    { 8, 1, "1.21", "Gajenje grožđa" },
                    { 9, 1, "1.22", "Gajenje tropskog i suptropskog voća" },
                    { 10, 1, "1.23", "Gajenje agruma" },
                    { 11, 1, "1.24", "Gajenje jabučastog i koštičavog voća" },
                    { 12, 1, "1.25", "Gajenje ostalog žbunastog i jezgrastog voća" },
                    { 13, 1, "1.26", "Gajenje uljnih plodova" },
                    { 14, 1, "1.27", "Gajenje biljaka za pripremanje napitaka" },
                    { 15, 1, "1.28", "Gajenje začinskog, aromatičnog i lekovitog bilja" },
                    { 16, 1, "1.29", "Gajenje ostalih višegodišnjih biljaka" },
                    { 17, 1, "1.3", "Gajenje sadnog materijala" },
                    { 18, 1, "1.41", "Uzgoj muznih krava" },
                    { 19, 1, "1.42", "Uzgoj drugih goveda i bivola" },
                    { 20, 1, "1.43", "Uz¬goj ko¬nja i dru¬gih ko¬pi¬ta¬ra" },
                    { 21, 1, "1.44", "Uzgoj kamila i lama" },
                    { 22, 1, "1.45", "Uzgoj ovaca i koza" },
                    { 23, 1, "1.46", "Uzgoj svinja" },
                    { 24, 1, "1.47", "Uzgoj živine" },
                    { 25, 1, "1.49", "Uzgoj ostalih životinja" },
                    { 26, 1, "1.5", "Mešovita poljoprivredna proizvodnja" },
                    { 27, 1, "1.61", "Uslužne delatnosti u gajenju useva i zasada" },
                    { 28, 1, "1.62", "Pomoćne delatnosti u uzgoju životinja" },
                    { 29, 1, "1.63", "Aktivnosti posle žetve" },
                    { 30, 1, "1.64", "Dorada semena" },
                    { 31, 1, "1.7", "Lov, traperstvo i odgovarajuće uslužne delatnosti" },
                    { 32, 2, "2.1", "Gajenje šuma i ostale šumarske delatnosti" },
                    { 33, 2, "2.2", "Seča drveća" },
                    { 34, 2, "2.3", "Sakupljanje šumskih plodova" },
                    { 35, 2, "2.4", "Uslužne delatnosti u vezi sa šumarstvom" },
                    { 36, 3, "3.11", "Morski ribolov" },
                    { 37, 3, "3.12", "Slatkovodni ribolov" },
                    { 38, 3, "3.21", "Morske akvakulture" },
                    { 39, 3, "3.22", "Slatkovodne akvakulture" },
                    { 40, 4, "5.1", "Eksploatacija kamenog uglja i antracita" },
                    { 41, 4, "5.2", "Eksploatacija lignita i mrkog uglja" },
                    { 42, 5, "6.1", "Eksploatacija sirove nafte" },
                    { 43, 5, "6.2", "Eksploatacija prirodnog gasa" },
                    { 44, 6, "7.1", "Eksploatacija ruda gvožđa" },
                    { 45, 6, "7.21", "Eksploatacija ruda urana i torijuma" },
                    { 46, 6, "7.29", "Eksploatacija ruda obojenih metala" },
                    { 47, 7, "8.11", "Eksploatacija građevinskog i ukrasnog kamena" },
                    { 48, 7, "8.12", "Eksploatacija šljunka, peska, gline i kaolina" },
                    { 49, 7, "8.91", "Eksploatacija minerala" },
                    { 50, 7, "8.92", "Eksploatacija treseta" },
                    { 51, 7, "8.93", "Eksploatacija natrijum-hlorida" },
                    { 52, 7, "8.99", "Eksploatacija ostalih nemetaličnih ruda i minerala" },
                    { 53, 8, "9.1", "Uslužne delatnosti u vezi sa naftom i gasom" },
                    { 54, 8, "9.9", "Uslužne delatnosti u vezi sa ostalim rudama" },
                    { 55, 9, "10.11", "Prerada i konzervisanje mesa" },
                    { 56, 9, "10.12", "Prerada i konzervisanje živinskog mesa" },
                    { 57, 9, "10.13", "Proizvodnja mesnih prerađevina" },
                    { 58, 9, "10.2", "Prerada i konzervisanje ribe, ljuskara i mekušaca" },
                    { 59, 9, "10.31", "Prerada i konzervisanje krompira" },
                    { 60, 9, "10.32", "Proizvodnja sokova od voća i povrća" },
                    { 61, 9, "10.39", "Ostala prerada i konzervisanje voća i povrća" },
                    { 62, 9, "10.41", "Proizvodnja ulja i masti" },
                    { 63, 9, "10.42", "Proizvodnja margarina i sličnih jestivih masti" },
                    { 64, 9, "10.51", "Prerada mleka i proizvodnja sireva" },
                    { 65, 9, "10.52", "Proizvodnja sladoleda" },
                    { 66, 9, "10.61", "Proizvodnja mlinskih proizvoda" },
                    { 67, 9, "10.62", "Proizvodnja skroba i skrobnih proizvoda" },
                    { 68, 9, "10.71", "Proizvodnja hleba, svežeg peciva i kolača" },
                    { 69, 9, "10.72", "Proizvodnja dvopeka, keksa, trajnog peciva i kolača" },
                    { 70, 9, "10.73", "Proizvodnja makarona, rezanaca i sličnih proizvoda" },
                    { 71, 9, "10.81", "Proizvodnja šećera" },
                    { 72, 9, "10.82", "Proizvodnja čokolade i konditorskih proizvoda" },
                    { 73, 9, "10.83", "Prerada čaja i kafe" },
                    { 74, 9, "10.84", "Proizvodnja začina i drugih dodataka hrani" },
                    { 75, 9, "10.85", "Proizvodnja gotovih jela" },
                    { 76, 9, "10.86", "Proizvodnja hranljivih preparata i dijetetske hrane" },
                    { 77, 9, "10.89", "Proizvodnja ostalih prehrambenih proizvoda" },
                    { 78, 9, "10.91", "Proizvodnja gotove hrane za domaće životinje" },
                    { 79, 9, "10.92", "Proizvodnja gotove hrane za kućne ljubimce" },
                    { 80, 10, "11.01", "Destilacija, prečišćavanje i mešanje pića" },
                    { 81, 10, "11.02", "Proizvodnja vina od grožđa" },
                    { 82, 10, "11.03", "Proizvodnja pića i ostalih voćnih vina" },
                    { 83, 10, "11.04", "Proizvodnja nedestilovanih fermentisanih pića" },
                    { 84, 10, "11.05", "Proizvodnja piva" },
                    { 85, 10, "11.06", "Proizvodnja slada" },
                    { 86, 10, "11.07", "Proizvodnja osvežavajućih pića i flaširane vode" },
                    { 87, 11, "12.0", "Proizvodnja duvanskih proizvoda" },
                    { 88, 12, "13.1", "Priprema i predenje tekstilnih vlakana" },
                    { 89, 12, "13.2", "Proizvodnja tkanina" },
                    { 90, 12, "13.3", "Dovršavanje tekstila" },
                    { 91, 12, "13.91", "Proizvodnja pletenih i kukičanih materijala" },
                    { 92, 12, "13.92", "Proizvodnja gotovih tekstilnih proizvoda, osim odeće" },
                    { 93, 12, "13.93", "Proizvodnja tepiha i prekrivača za pod" },
                    { 94, 12, "13.94", "Proizvodnja užadi, kanapa, pletenica i mreža" },
                    { 95, 12, "13.95", "Proizvodnja netkanog tekstila i predmeta, osim odeće" },
                    { 96, 12, "13.96", "Proizvodnja tehničkog i industrijskog tekstila" },
                    { 97, 12, "13.99", "Proizvodnja ostalih tekstilnih predmeta" },
                    { 98, 13, "14.11", "Proizvodnja kožne odeće" },
                    { 99, 13, "14.12", "Proizvodnja radne odeće" },
                    { 100, 13, "14.13", "Proizvodnja ostale odeće" },
                    { 101, 13, "14.14", "Proizvodnja rublja" },
                    { 102, 13, "14.19", "Proizvodnja ostalih odevnih predmeta i pribora" },
                    { 103, 13, "14.2", "Proizvodnja proizvoda od krzna" },
                    { 104, 13, "14.31", "Proizvodnja pletenih i kukičanih čarapa" },
                    { 105, 13, "14.39", "Proizvodnja ostale pletene i kukičane odeće" },
                    { 106, 14, "15.11", "Štavljenje i dorada kože, dorada i bojenje krzna" },
                    { 107, 14, "15.12", "Proizvodnja putnih i ručnih torbi i kaiševa" },
                    { 108, 14, "15.2", "Proizvodnja obuće" },
                    { 109, 15, "16.1", "Rezanje i obrada drveta" },
                    { 110, 15, "16.21", "Proizvodnja furnira i ploča od drveta" },
                    { 111, 15, "16.22", "Proizvodnja parketa" },
                    { 112, 15, "16.23", "Proizvodnja ostale građevinske stolarije i elemenata" },
                    { 113, 15, "16.24", "Proizvodnja drvne ambalaže" },
                    { 114, 15, "16.29", "Proizvodnja proizvoda od drveta, plute, slame i pruća" },
                    { 115, 16, "17.11", "Proizvodnja vlakana celuloze" },
                    { 116, 16, "17.12", "Proizvodnja papira i kartona" },
                    { 117, 16, "17.21", "Proizvodnja talasastog papira, kartona i ambalaže" },
                    { 118, 16, "17.22", "Proizvodnja predmeta od papira za ličnu upotrebu" },
                    { 119, 16, "17.23", "Proizvodnja kancelarijskih predmeta od papira" },
                    { 120, 16, "17.24", "Proizvodnja tapeta" },
                    { 121, 16, "17.29", "Proizvodnja ostalih proizvoda od papira i kartona" },
                    { 122, 17, "18.11", "Štampanje novina" },
                    { 123, 17, "18.12", "Ostalo štampanje" },
                    { 124, 17, "18.13", "Usluge pripreme za štampu" },
                    { 125, 17, "18.14", "Knjigovezačke i srodne usluge" },
                    { 126, 17, "18.2", "Umnožavanje snimljenih zapisa" },
                    { 127, 18, "19.1", "Proizvodnja produkata koksovanja" },
                    { 128, 18, "19.2", "Proizvodnja derivata nafte" },
                    { 129, 19, "20.11", "Proizvodnja industrijskih gasova" },
                    { 130, 19, "20.12", "Proizvodnja sredstava za pripremanje boja i pigmenata" },
                    { 131, 19, "20.13", "Proizvodnja ostalih osnovnih neorganskih hemikalija" },
                    { 132, 19, "20.14", "Proizvodnja ostalih osnovnih organskih hemikalija" },
                    { 133, 19, "20.15", "Proizvodnja veštačkih đubriva i azotnih jedinjenja" },
                    { 134, 19, "20.16", "Proizvodnja plastičnih masa u primarnim oblicima" },
                    { 135, 19, "20.17", "Proizvodnja sintetičkog kaučuka" },
                    { 136, 19, "20.2", "Proizvodnja pesticida i hemikalija za poljoprivredu" },
                    { 137, 19, "20.3", "Proizvodnja boja, lakova i sličnih premaza" },
                    { 138, 19, "20.41", "Proizvodnja deterdženata, sapuna i sredstava za čišćenje" },
                    { 139, 19, "20.42", "Proizvodnja parfema i toaletnih preparata" },
                    { 140, 19, "20.51", "Proizvodnja eksploziva" },
                    { 141, 19, "20.52", "Proizvodnja sredstava za lepljenje" },
                    { 142, 19, "20.53", "Proizvodnja eteričnih ulja" },
                    { 143, 19, "20.59", "Proizvodnja ostalih hemijskih proizvoda" },
                    { 144, 19, "20.6", "Proizvodnja veštačkih vlakana" },
                    { 145, 20, "21.1", "Proizvodnja osnovnih farmaceutskih proizvoda" },
                    { 146, 20, "21.2", "Proizvodnja farmaceutskih preparata" },
                    { 147, 21, "22.11", "Proizvodnja guma za vozila, protektiranje guma" },
                    { 148, 21, "22.19", "Proizvodnja ostalih proizvoda od gume" },
                    { 149, 21, "22.21", "Proizvodnja ploča, listova, cevi i profila" },
                    { 150, 21, "22.22", "Proizvodnja ambalaže od plastike" },
                    { 151, 21, "22.23", "Proizvodnja predmeta od plastike za građevinarstvo" },
                    { 152, 21, "22.29", "Proizvodnja ostalih proizvoda od plastike" },
                    { 153, 22, "23.11", "Proizvodnja ravnog stakla" },
                    { 154, 22, "23.12", "Oblikovanje i obrada ravnog stakla" },
                    { 155, 22, "23.13", "Proizvodnja šupljeg stakla" },
                    { 156, 22, "23.14", "Proizvodnja staklenih vlakana" },
                    { 157, 22, "23.19", "Proizvodnja i obrada ostalog stakla" },
                    { 158, 22, "23.2", "Proizvodnja vatrostalnih proizvoda" },
                    { 159, 22, "23.31", "Proizvodnja keramičkih pločica i ploča" },
                    { 160, 22, "23.32", "Proizvodnja opeke, crepa i građevinskih proizvoda" },
                    { 161, 22, "23.41", "Proizvodnja keramičkih predmeta za domaćinstvo" },
                    { 162, 22, "23.42", "Proizvodnja sanitarnih keramičkih proizvoda" },
                    { 163, 22, "23.43", "Proizvodnja izolatora i izolac. pribora od keramike" },
                    { 164, 22, "23.44", "Proizvodnja ostalih tehničkih proizvoda od keramike" },
                    { 165, 22, "23.49", "Proizvodnja ostalih keramičkih proizvoda" },
                    { 166, 22, "23.51", "Proizvodnja cementa" },
                    { 167, 22, "23.52", "Proizvodnja kreča i gipsa" },
                    { 168, 22, "23.61", "Proizvodnja proizvoda od betona za građevinarstvo" },
                    { 169, 22, "23.62", "Proizvodnja proizvoda od gipsa za građevinarstvo" },
                    { 170, 22, "23.63", "Proizvodnja svežeg betona" },
                    { 171, 22, "23.64", "Proizvodnja maltera" },
                    { 172, 22, "23.65", "Proizvodnja proizvoda od cementa s vlaknima" },
                    { 173, 22, "23.69", "Proizvodnja ostalih proizvoda od betona i gipsa" },
                    { 174, 22, "23.7", "Sečenje, oblikovanje i obrada kamena" },
                    { 175, 22, "23.91", "Proizvodnja brusnih proizvoda" },
                    { 176, 22, "23.99", "Proizvodnja proizvoda od nemetalnih minerala" },
                    { 177, 23, "24.1", "Proizvodnja sirovog gvožđa, čelika i ferolegura" },
                    { 178, 23, "24.2", "Proizvodnja čeličnih cevi, profila i fitinga" },
                    { 179, 23, "24.31", "Hladno valjanje šipki" },
                    { 180, 23, "24.32", "Hladno valjanje pljosnatih proizvoda" },
                    { 181, 23, "24.33", "Hladno oblikovanje profila" },
                    { 182, 23, "24.34", "Hladno vučenje žice" },
                    { 183, 23, "24.41", "Proizvodnja plemenitih metala" },
                    { 184, 23, "24.42", "Proizvodnja aluminijuma" },
                    { 185, 23, "24.43", "Proizvodnja olova, cinka i kalaja" },
                    { 186, 23, "24.44", "Proizvodnja bakra" },
                    { 187, 23, "24.45", "Proizvodnja ostalih obojenih metala" },
                    { 188, 23, "24.46", "Proizvodnja nuklearnog goriva" },
                    { 189, 23, "24.51", "Livenje gvožđa" },
                    { 190, 23, "24.52", "Livenje čelika" },
                    { 191, 23, "24.53", "Livenje lakih metala" },
                    { 192, 23, "24.54", "Livenje ostalih obojenih metala" },
                    { 193, 24, "25.11", "Proizvodnja metalnih konstrukcija i delova" },
                    { 194, 24, "25.12", "Proizvodnja metalnih vrata i prozora" },
                    { 195, 24, "25.21", "Proizvodnja kotlova i radijatora za grejanje" },
                    { 196, 24, "25.29", "Proizvodnja ostalih metalnih cisterni i kontejnera" },
                    { 197, 24, "25.3", "Proizvodnja parnih kotlova, osim za centr. grejanje" },
                    { 198, 24, "25.4", "Proizvodnja oružja i municije" },
                    { 199, 24, "25.5", "Kovanje, presovanje, štancovanje i valjanje metala" },
                    { 200, 24, "25.61", "Obrada i prevlačenje metala" },
                    { 201, 24, "25.62", "Mašinska obrada metala" },
                    { 202, 24, "25.71", "Proizvodnja sečiva" },
                    { 203, 24, "25.72", "Proizvodnja brava i okova" },
                    { 204, 24, "25.73", "Proizvodnja alata" },
                    { 205, 24, "25.91", "Proizvodnja čeličnih buradi i slične ambalaže" },
                    { 206, 24, "25.92", "Proizvodnja ambalaže od lakih metala" },
                    { 207, 24, "25.93", "Proizvodnja žičanih proizvoda, lanaca i opruga" },
                    { 208, 24, "25.94", "Proizvodnja veznih elemenata i vijčanih proizvoda" },
                    { 209, 24, "25.99", "Proizvodnja ostalih metalnih proizvoda" },
                    { 210, 25, "26.11", "Proizvodnja elektronskih elemenata" },
                    { 211, 25, "26.12", "Proizvodnja štampanih elektronskih ploča" },
                    { 212, 25, "26.2", "Proizvodnja računara i periferne opreme" },
                    { 213, 25, "26.3", "Proizvodnja komunikacione opreme" },
                    { 214, 25, "26.4", "Proizvodnja elektronskih uređaja za široku potrošnju" },
                    { 215, 25, "26.51", "Proizvodnja mernih instrumenata i aparata" },
                    { 216, 25, "26.52", "Proizvodnja satova" },
                    { 217, 25, "26.6", "Proizvodnja elektromedicinske opreme" },
                    { 218, 25, "26.7", "Proizvodnja optičkih instrumenata i fotogr. opreme" },
                    { 219, 25, "26.8", "Proizvodnja magnetnih i optičkih nosilaca zapisa" },
                    { 220, 26, "27.11", "Proizvodnja elektromot. generatora i transformatora" },
                    { 221, 26, "27.12", "Proizvodnja opreme za distribuciju elektr. energije" },
                    { 222, 26, "27.2", "Proizvodnja baterija i akumulatora" },
                    { 223, 26, "27.31", "Proizvodnja kablova od optičkih vlakana" },
                    { 224, 26, "27.32", "Proizvodnja ostalih elektronskih i elektr. kablova" },
                    { 225, 26, "27.33", "Proizvodnja opreme za povezivanje žica i kablova" },
                    { 226, 26, "27.4", "Proizvodnja opreme za osvetljenje" },
                    { 227, 26, "27.51", "Proizvodnja električnih aparata za domaćinstvo" },
                    { 228, 26, "27.52", "Proizvodnja neelektričnih aparata za domaćinstvo" },
                    { 229, 26, "27.9", "Proizvodnja ostale električne opreme" },
                    { 230, 27, "28.11", "Proizvodnja motora i turbina, osim za motorna vozila" },
                    { 231, 27, "28.12", "Proizvodnja hidrauličnih pogonskih uređaja" },
                    { 232, 27, "28.13", "Proizvodnja ostalih pumpi i kompresora" },
                    { 233, 27, "28.14", "Proizvodnja ostalih slavina i ventila" },
                    { 234, 27, "28.15", "Proizvodnja ležajeva, zupčanika i zupčastih elemenata" },
                    { 235, 27, "28.21", "Proizvodnja industrijskih peći i gorionika" },
                    { 236, 27, "28.22", "Proizvodnja opreme za podizanje i prenošenje" },
                    { 237, 27, "28.23", "Proizvodnja kancelarijskih mašina i opreme" },
                    { 238, 27, "28.24", "Proizvodnja ručnih pogonskih aparata sa mehanizmima" },
                    { 239, 27, "28.25", "Proizvodnja rashladne i ventilacione opreme" },
                    { 240, 27, "28.29", "Proizvodnja ostalih mašina i aparata opšte namene" },
                    { 241, 27, "28.3", "Proizvodnja mašina za poljoprivredu i šumarstvo" },
                    { 242, 27, "28.41", "Proizvodnja mašina za obradu metala" },
                    { 243, 27, "28.49", "Proizvodnja ostalih alatnih mašina" },
                    { 244, 27, "28.91", "Proizvodnja mašina za metalurgiju" },
                    { 245, 27, "28.92", "Proizvodnja mašina za rudnike i građevinarstvo" },
                    { 246, 27, "28.93", "Proizvodnja mašina za industr. hrane, pića i duvana" },
                    { 247, 27, "28.94", "Proizvodnja mašina za industr. tekstila, odeće i kože" },
                    { 248, 27, "28.95", "Proizvodnja mašina za industriju papira i kartona" },
                    { 249, 27, "28.96", "Proizvodnja mašina za izradu plastike i gume" },
                    { 250, 27, "28.99", "Proizvodnja mašina za ostale specijalne namene" },
                    { 251, 28, "29.1", "Proizvodnja motornih vozila" },
                    { 252, 28, "29.2", "Proizvodnja karoserija za motorna vozila i prikolice" },
                    { 253, 28, "29.31", "Proizvodnja električne opreme za motorna vozila" },
                    { 254, 28, "29.32", "Proizvodnja ostalih delova za motorna vozila" },
                    { 255, 29, "30.11", "Izgradnja brodova i plovnih objekata" },
                    { 256, 29, "30.12", "Izrada čamaca za sport i razonodu" },
                    { 257, 29, "30.2", "Proizvodnja lokomotiva i šinskih vozila" },
                    { 258, 29, "30.3", "Proizvodnja vazdušnih i svemirskih letelica" },
                    { 259, 29, "30.4", "Proizvodnja borbenih vojnih vozila" },
                    { 260, 29, "30.91", "Proizvodnja motocikala" },
                    { 261, 29, "30.92", "Proizvodnja bicikala i invalidskih kolica" },
                    { 262, 29, "30.99", "Proizvodnja ostale transportne opreme" },
                    { 263, 30, "31.01", "Proizvodnja nameštaja za poslovne prostore" },
                    { 264, 30, "31.02", "Proizvodnja kuhinjskog nameštaja" },
                    { 265, 30, "31.03", "Proizvodnja madraca" },
                    { 266, 30, "31.09", "Proizvodnja ostalog nameštaja" },
                    { 267, 31, "32.11", "Kovanje novca" },
                    { 268, 31, "32.12", "Proizvodnja nakita i srodnih predmeta" },
                    { 269, 31, "32.13", "Proizvodnja imitacije nakita i srodnih proizvoda" },
                    { 270, 31, "32.2", "Proizvodnja muzičkih instrumenata" },
                    { 271, 31, "32.3", "Proizvodnja sportske opreme" },
                    { 272, 31, "32.4", "Proizvodnja igara i igračaka" },
                    { 273, 31, "32.5", "Proizvodnja medicinskih i stomatoloških materijala" },
                    { 274, 31, "32.91", "Proizvodnja metli i četki" },
                    { 275, 31, "32.99", "Proizvodnja ostalih predmeta" },
                    { 276, 32, "33.11", "Popravka metalnih proizvoda" },
                    { 277, 32, "33.12", "Popravka mašina" },
                    { 278, 32, "33.13", "Popravka elektronske i optičke opreme" },
                    { 279, 32, "33.14", "Popravka električne opreme" },
                    { 280, 32, "33.15", "Popravka i održavanje brodova i čamaca" },
                    { 281, 32, "33.16", "Popravka i održavanje letelica" },
                    { 282, 32, "33.17", "Popravka i održavanje druge transportne opreme" },
                    { 283, 32, "33.19", "Popravka ostale opreme" },
                    { 284, 32, "33.2", "Montaža industrijskih mašina i opreme" },
                    { 285, 33, "35.11", "Proizvodnja električne energije" },
                    { 286, 33, "35.12", "Prenos električne energije" },
                    { 287, 33, "35.13", "Distribucija električne energije" },
                    { 288, 33, "35.14", "Trgovina električnom energijom" },
                    { 289, 33, "35.21", "Proizvodnja gasa" },
                    { 290, 33, "35.22", "Distribucija gasovitih goriva gasovodom" },
                    { 291, 33, "35.23", "Trgovina gasovitim gorivima preko gasovodne mreže" },
                    { 292, 33, "35.3", "Snabdevanje parom i klimatizacija" },
                    { 293, 34, "36.0", "Skupljanje, prečišćavanje i distribucija vode" },
                    { 294, 35, "37.0", "Uklanjanje otpadnih voda" },
                    { 295, 36, "38.11", "Skupljanje otpada koji nije opasan" },
                    { 296, 36, "38.12", "Skupljanje opasnog otpada" },
                    { 297, 36, "38.21", "Tretman i odlaganje otpada koji nije opasan" },
                    { 298, 36, "38.22", "Tretman i odlaganje opasnog otpada" },
                    { 299, 36, "38.31", "Demontaža olupina" },
                    { 300, 36, "38.32", "Ponovna upotreba razvrstanih materijala" },
                    { 301, 37, "39.0", "Sanacija, rekultivacija i upravljanje otpadom" },
                    { 302, 38, "41.1", "Razrada građevinskih projekata" },
                    { 303, 38, "41.2", "Izgradnja stambenih i nestambenih zgrada" },
                    { 304, 39, "42.11", "Izgradnja puteva i autoputeva" },
                    { 305, 39, "42.12", "Izgradnja železničkih pruga i podzemnih železnica" },
                    { 306, 39, "42.13", "Izgradnja mostova i tunela" },
                    { 307, 39, "42.21", "Izgradnja cevovoda" },
                    { 308, 39, "42.22", "Izgradnja električnih i telekomunikacionih vodova" },
                    { 309, 39, "42.91", "Izgradnja hidrotehničkih objekata" },
                    { 310, 39, "42.99", "Izgradnja ostalih nepomenutih građevina" },
                    { 311, 40, "43.11", "Rušenje objekata" },
                    { 312, 40, "43.12", "Pripremanje gradilišta" },
                    { 313, 40, "43.13", "Ispitivanje terena bušenjem i sondiranjem" },
                    { 314, 40, "43.21", "Postavljanje električnih instalacija" },
                    { 315, 40, "43.22", "Postavljanje vodovodnih i klimatizacionih sistema" },
                    { 316, 40, "43.29", "Ostali instalacioni radovi u građevinarstvu" },
                    { 317, 40, "43.31", "Malterisanje" },
                    { 318, 40, "43.32", "Ugradnja stolarije" },
                    { 319, 40, "43.33", "Postavljanje podnih i zidnih obloga" },
                    { 320, 40, "43.34", "Bojenje i zastakljivanje" },
                    { 321, 40, "43.39", "Ostali završni radovi" },
                    { 322, 40, "43.91", "Krovni radovi" },
                    { 323, 40, "43.99", "Ostali nepomenuti specifični građevinski radovi" },
                    { 324, 41, "45.11", "Trgovina automobilima i lakim motornim vozilima" },
                    { 325, 41, "45.19", "Trgovina ostalim motornim vozilima" },
                    { 326, 41, "45.2", "Održavanje i popravka motornih vozila" },
                    { 327, 41, "45.31", "Trgovina na veliko delovima i opremom za vozila" },
                    { 328, 41, "45.32", "Trgovina na malo delovima i opremom za vozila" },
                    { 329, 41, "45.4", "Trgovina motociklima, delovima i popravka motocik." },
                    { 330, 42, "46.11", "Posredovanje u prodaji poljoprivrednih sirovina" },
                    { 331, 42, "46.12", "Posredovanje u prodaji goriva, ruda i metala" },
                    { 332, 42, "46.13", "Posredovanje u prodaji građevinskog materijala" },
                    { 333, 42, "46.14", "Posredovanje u prodaji mašina i industrijske opreme" },
                    { 334, 42, "46.15", "Posredovanje u prodaji nameštaja i metalne robe" },
                    { 335, 42, "46.16", "Posredovanje u prodaji tekstila, odeće, krzna i obuće" },
                    { 336, 42, "46.17", "Posredovanje u prodaji hrane, pića i duvana" },
                    { 337, 42, "46.18", "Specijalizovano posredovanje u prodaji proizvoda" },
                    { 338, 42, "46.19", "Posredovanje u prodaji raznovrsnih proizvoda" },
                    { 339, 42, "46.21", "Trgovina na veliko žitom, sirovim duvanom i semenjem" },
                    { 340, 42, "46.22", "Trgovina na veliko cvećem i sadnicama" },
                    { 341, 42, "46.23", "Trgovina na veliko životinjama" },
                    { 342, 42, "46.24", "Trgovina na veliko sirovom i dovršenom kožom" },
                    { 343, 42, "46.31", "Trgovina na veliko voćem i povrćem" },
                    { 344, 42, "46.32", "Trgovina na veliko mesom i proizvodima od mesa" },
                    { 345, 42, "46.33", "Trgovina na veliko mlečnim proizvodima i mastima" },
                    { 346, 42, "46.34", "Trgovina na veliko pićima" },
                    { 347, 42, "46.35", "Trgovina na veliko duvanskim proizvodima" },
                    { 348, 42, "46.36", "Trgovina na veliko šećerom, čokoladom i slatkišima" },
                    { 349, 42, "46.37", "Trgovina na veliko kafom, čajevima, kakaom i začinima" },
                    { 350, 42, "46.38", "Trgovina na veliko ostalom hranom, uključujući ribu" },
                    { 351, 42, "46.39", "Nespecijalizovana trgovina na veliko hranom i pićima" },
                    { 352, 42, "46.41", "Trgovina na veliko tekstilom" },
                    { 353, 42, "46.42", "Trgovina na veliko odećom i obućom" },
                    { 354, 42, "46.43", "Trgovina na veliko elektr. aparatima za domaćinstvo" },
                    { 355, 42, "46.44", "Trgovina na veliko porculanom i staklenom robom" },
                    { 356, 42, "46.45", "Trgovina na veliko parfimerijskim proizvodima" },
                    { 357, 42, "46.46", "Trgovina na veliko farmaceutskim proizvodima" },
                    { 358, 42, "46.47", "Trgovina na veliko nameštajem i tepisima" },
                    { 359, 42, "46.48", "Trgovina na veliko satovima i nakitom" },
                    { 360, 42, "46.49", "Trgovina na veliko ostalim proizvodima" },
                    { 361, 42, "46.51", "Trgovina na veliko računarima i softverima" },
                    { 362, 42, "46.52", "Trgovina na veliko elektronskim delovima i opremom" },
                    { 363, 42, "46.61", "Trgovina na veliko poljoprivrednim mašinama" },
                    { 364, 42, "46.62", "Trgovina na veliko alatnim mašinama" },
                    { 365, 42, "46.63", "Trgovina na veliko rudarskim i građ. mašinama" },
                    { 366, 42, "46.64", "Trgovina na veliko mašinama za tekstilnu industriju" },
                    { 367, 42, "46.65", "Trgovina na veliko kancelarijskim nameštajem" },
                    { 368, 42, "46.66", "Trgovina na veliko ostalim kancelarijskim mašinama" },
                    { 369, 42, "46.69", "Trgovina na veliko ostalim mašinama i opremom" },
                    { 370, 42, "46.71", "Trgovina na veliko čvrstim i tečnim gorivima" },
                    { 371, 42, "46.72", "Trgovina na veliko metalima i metalnim rudama" },
                    { 372, 42, "46.73", "Trgovina na veliko drvetom i građ. materijalom" },
                    { 373, 42, "46.74", "Trgovina na veliko metalnom robom" },
                    { 374, 42, "46.75", "Trgovina na veliko hemijskim proizvodima" },
                    { 375, 42, "46.76", "Trgovina na veliko ostalim poluproizvodima" },
                    { 376, 42, "46.77", "Trgovina na veliko otpacima i ostacima" },
                    { 377, 42, "46.9", "Nespecijalizovana trgovina na veliko" },
                    { 378, 43, "47.11", "Trgovina na malo u nespec. prodavn. pretežno hranom" },
                    { 379, 43, "47.19", "Ostala trgovina na malo u nespecijaliz. prodavnicama" },
                    { 380, 43, "47.21", "Trgovina na malo voćem i povrćem" },
                    { 381, 43, "47.22", "Trgovina na malo mesom i proizvodima od mesa" },
                    { 382, 43, "47.23", "Trgovina na malo ribom, ljuskarima i mekušcima" },
                    { 383, 43, "47.24", "Trgovina na malo hlebom, kolačima i slatkišima" },
                    { 384, 43, "47.25", "Trgovina na malo pićima" },
                    { 385, 43, "47.26", "Trgovina na malo proizvodima od duvana" },
                    { 386, 43, "47.29", "Ostala trgovina na malo hranom u spec. prodavnicama" },
                    { 387, 43, "47.3", "Trgovina na malo motornim gorivima" },
                    { 388, 43, "47.41", "Trgovina na malo računarima i softverom" },
                    { 389, 43, "47.42", "Trgovina na malo telekomunikacionom opremom" },
                    { 390, 43, "47.43", "Trgovina na malo audio i video opremom" },
                    { 391, 43, "47.51", "Trgovina na malo tekstilom u spec. prodavnicama" },
                    { 392, 43, "47.52", "Trgovina na malo metalnom robom, bojama i staklom" },
                    { 393, 43, "47.53", "Trgovina na malo tepisima, zidnim i podnim oblogama" },
                    { 394, 43, "47.54", "Trgovina na malo elektr. aparatima za domaćinstvo" },
                    { 395, 43, "47.59", "Trgovina na malo nameštajem i ostalim predmetima" },
                    { 396, 43, "47.61", "Trgovina na malo knjigama u spec. prodavnicama" },
                    { 397, 43, "47.62", "Trgovina na malo novinama i kancelar. materijalom" },
                    { 398, 43, "47.63", "Trgovina na malo muzičkim i video zapisima" },
                    { 399, 43, "47.64", "Trgovina na malo sportskom opremom" },
                    { 400, 43, "47.65", "Trgovina na malo igrama i igračkama" },
                    { 401, 43, "47.71", "Trgovina na malo odećom u spec. prodavnicama" },
                    { 402, 43, "47.72", "Trgovina na malo obućom i predmetima od kože" },
                    { 403, 43, "47.73", "Trgovina na malo farmaceutskim proizv. u apotekama" },
                    { 404, 43, "47.74", "Trgovina na malo medicinskim i ortoped. pomagalima" },
                    { 405, 43, "47.75", "Trgovina na malo kozmetičkim i toaletnim proizv." },
                    { 406, 43, "47.76", "Trgovina na malo cvećem, sadnicama i semenjem" },
                    { 407, 43, "47.77", "Trgovina na malo satovima i nakitom" },
                    { 408, 43, "47.78", "Ostala trgovina na malo novim proizvodima" },
                    { 409, 43, "47.79", "Trgovina na malo polovnom robom u prodavnicama" },
                    { 410, 43, "47.81", "Trgovina na malo hranom, pićima na pijacama" },
                    { 411, 43, "47.82", "Trgovina na malo tekstilom i obućom na pijacama" },
                    { 412, 43, "47.89", "Trgovina na malo ostalom robom na tezgama i pijacama" },
                    { 413, 43, "47.91", "Trgovina na malo posredstvom pošte ili interneta" },
                    { 414, 43, "47.99", "Ostala trgovina na malo izvan prodavnica i pijaca" },
                    { 415, 44, "49.1", "Železnički prevoz putnika, daljinski i regionalni" },
                    { 416, 44, "49.2", "Železnički prevoz tereta" },
                    { 417, 44, "49.31", "Gradski i prigradski kopneni prevoz putnika" },
                    { 418, 44, "49.32", "Taksi prevoz" },
                    { 419, 44, "49.39", "Ostali prevoz putnika u kopnenom saobraćaju" },
                    { 420, 44, "49.41", "Drumski prevoz tereta" },
                    { 421, 44, "49.42", "Usluge preseljenja" },
                    { 422, 44, "49.5", "Cevovodni transport" },
                    { 423, 45, "50.1", "Pomorski i priobalni prevoz putnika" },
                    { 424, 45, "50.2", "Pomorski i priobalni prevoz tereta" },
                    { 425, 45, "50.3", "Prevoz putnika unutrašnjim plovnim putevima" },
                    { 426, 45, "50.4", "Prevoz tereta unutrašnjim plovnim putevima" },
                    { 427, 46, "51.1", "Vazdušni prevoz putnika" },
                    { 428, 46, "51.21", "Vazdušni prevoz tereta" },
                    { 429, 46, "51.22", "Vasionski saobraćaj" },
                    { 430, 47, "52.1", "Skladištenje" },
                    { 431, 47, "52.21", "Uslužne delatnosti u kopnenom saobraćaju" },
                    { 432, 47, "52.22", "Uslužne delatnosti u vodenom saobraćaju" },
                    { 433, 47, "52.23", "Uslužne delatnosti u vazdušnom saobraćaju" },
                    { 434, 47, "52.24", "Manipulacija teretom" },
                    { 435, 47, "52.29", "Ostale prateće delatnosti u saobraćaju" },
                    { 436, 48, "53.1", "Poštanske aktivnosti javnog servisa" },
                    { 437, 48, "53.2", "Poštanske aktivnosti komercijalnog servisa" },
                    { 438, 49, "55.1", "Hoteli i sličan smeštaj" },
                    { 439, 49, "55.2", "Odmarališta i slični objekti za kraći boravak" },
                    { 440, 49, "55.3", "Delatnost kampova i auto-kampova" },
                    { 441, 49, "55.9", "Ostali smeštaj" },
                    { 442, 50, "56.1", "Delatnosti restorana i pokretnih ugostitelj. objekta" },
                    { 443, 50, "56.21", "Ketering" },
                    { 444, 50, "56.29", "Ostale usluge pripremanja i posluživanja hrane" },
                    { 445, 50, "56.3", "Usluge pripremanja i posluživanja pića" },
                    { 446, 51, "58.11", "Izdavanje knjiga" },
                    { 447, 51, "58.12", "Izdavanje imenika i adresara" },
                    { 448, 51, "58.13", "Izdavanje novina" },
                    { 449, 51, "58.14", "Izdavanje časopisa i periodičnih izdanja" },
                    { 450, 51, "58.19", "Ostala izdavačka delatnost" },
                    { 451, 51, "58.21", "Izdavanje računarskih igara" },
                    { 452, 51, "58.29", "Izdavanje ostalih softvera" },
                    { 453, 52, "59.11", "Proizvodnja kinematografskih dela i TV programa" },
                    { 454, 52, "59.12", "Delatnosti nakon snimanja kinematograf. dela i TV programa" },
                    { 455, 52, "59.13", "Distribucija kinematografskih dela i TV programa" },
                    { 456, 52, "59.14", "Delatnost prikazivanja kinematografskih dela" },
                    { 457, 52, "59.2", "Snimanje i izdavanje zvučnih zapisa i muzike" },
                    { 458, 53, "60.1", "Emitovanje radio-programa" },
                    { 459, 53, "60.2", "Proizvodnja i emitovanje televizijskog programa" },
                    { 460, 54, "61.1", "Kablovske telekomunikacije" },
                    { 461, 54, "61.2", "Bežične telekomunikacije" },
                    { 462, 54, "61.3", "Satelitske telekomunikacije" },
                    { 463, 54, "61.9", "Ostale telekomunikacione delatnosti" },
                    { 464, 55, "62.01", "Računarsko programiranje" },
                    { 465, 55, "62.02", "Konsultantske delat. u informacionim tehnologijama" },
                    { 466, 55, "62.03", "Upravljanje računarskom opremom" },
                    { 467, 55, "62.09", "Ostale usluge informacione tehnologije" },
                    { 468, 56, "63.11", "Obrada podataka, hosting i sl." },
                    { 469, 56, "63.12", "Veb portali" },
                    { 470, 56, "63.91", "Delatnosti novinskih agencija" },
                    { 471, 56, "63.99", "Informacione uslužne delatnosti" },
                    { 472, 57, "64.11", "Centralna banka" },
                    { 473, 57, "64.19", "Ostalo monetarno posredovanje" },
                    { 474, 57, "64.2", "Delatnost holding kompanija" },
                    { 475, 57, "64.3", "Poverenički fondovi i investicioni fondovi" },
                    { 476, 57, "64.91", "Finansijski lizing" },
                    { 477, 57, "64.92", "Ostale usluge kreditiranja" },
                    { 478, 57, "64.99", "Ostale finans. usluge, osim osiguranja i penz. fondova" },
                    { 479, 58, "65.11", "Životno osiguranje" },
                    { 480, 58, "65.12", "Neživotno osiguranje" },
                    { 481, 58, "65.2", "Reosiguranje" },
                    { 482, 58, "65.3", "Penzijski fondovi" },
                    { 483, 59, "66.11", "Finansijske i robne berze" },
                    { 484, 59, "66.12", "Brokerski poslovi s hartijama i berzanskom robom" },
                    { 485, 59, "66.19", "Ostale pomoćne delatnosti u finans. uslugama" },
                    { 486, 59, "66.21", "Obrada odštetnih zahteva i procenjivanje rizika i šteta" },
                    { 487, 59, "66.22", "Delatnost zastupnika i posrednika u osiguranju" },
                    { 488, 59, "66.29", "Ostale pomoćne delat. u osiguranju i penz. fondovima" },
                    { 489, 59, "66.3", "Upravljanje fondovima" },
                    { 490, 60, "68.1", "Kupovina i prodaja vlastitih nekretnina" },
                    { 491, 60, "68.2", "Iznajmljivanje nekretnina i upravljanje njima" },
                    { 492, 60, "68.31", "Delatnost agencija za nekretnine" },
                    { 493, 60, "68.32", "Upravljanje nekretninama za naknadu" },
                    { 494, 61, "69.1", "Pravni poslovi" },
                    { 495, 61, "69.2", "Računovodstveni, knjigov. i revizorski poslovi" },
                    { 496, 62, "70.1", "Upravljanje ekonomskim subjektom" },
                    { 497, 62, "70.21", "Delatnost komunikacija i odnosa s javnošću" },
                    { 498, 62, "70.22", "Konsultantske aktivnosti u vezi s poslovanjem" },
                    { 499, 63, "71.11", "Arhitektonska delatnost" },
                    { 500, 63, "71.12", "Inženjerske delatnosti i tehničko savetovanje" },
                    { 501, 63, "71.2", "Tehničko ispitivanje i analize" },
                    { 502, 64, "72.11", "Istraživanje i razvoj u biotehnologiji" },
                    { 503, 64, "72.19", "Istraživanje i razvoj u ostalim prirodnim naukama" },
                    { 504, 64, "72.2", "Istraživanje i razvoj u društvenim i human. naukama" },
                    { 505, 65, "73.11", "Delatnost reklamnih agencija" },
                    { 506, 65, "73.12", "Medijsko predstavljanje" },
                    { 507, 65, "73.2", "Istraživanje tržišta i ispitivanje javnog mnjenja" },
                    { 508, 66, "74.1", "Specijalizovane dizajnerske delatnosti" },
                    { 509, 66, "74.2", "Fotografske usluge" },
                    { 510, 66, "74.3", "Prevođenje i usluge tumača" },
                    { 511, 66, "74.9", "Ostale stručne, naučne i tehničke delatnosti" },
                    { 512, 67, "75.0", "Veterinarska delatnost" },
                    { 513, 68, "77.11", "Iznajmljivanje i lizing automobila i motornih vozila" },
                    { 514, 68, "77.12", "Iznajmljivanje i lizing kamiona" },
                    { 515, 68, "77.21", "Iznajmljivanje i lizing opreme za rekreaciju i sport" },
                    { 516, 68, "77.22", "Iznajmljivanje video-kaseta i kompakt-diskova" },
                    { 517, 68, "77.29", "Iznajmljivanje i lizing ostalih predmeta" },
                    { 518, 68, "77.31", "Iznajmljivanje i lizing poljoprivrednih mašina" },
                    { 519, 68, "77.32", "Iznajmljivanje i lizing mašina za građevinarstvo" },
                    { 520, 68, "77.33", "Iznajmljivanje i lizing kancelarijskih mašina" },
                    { 521, 68, "77.34", "Iznajmljivanje i lizing opreme za vodeni transport" },
                    { 522, 68, "77.35", "Iznajmljivanje i lizing opreme za vazdušni transport" },
                    { 523, 68, "77.39", "Iznajmljivanje i lizing ostalih mašina i opreme" },
                    { 524, 68, "77.4", "Lizing intelektualne svojine i sličnih proizvoda" },
                    { 525, 69, "78.1", "Delatnost agencija za zapošljavanje" },
                    { 526, 69, "78.2", "Delatnost agencija za privremeno zapošljavanje" },
                    { 527, 69, "78.3", "Ostalo ustupanje ljudskih resursa" },
                    { 528, 70, "79.11", "Delatnost putničkih agencija" },
                    { 529, 70, "79.12", "Delatnost tur-operatora" },
                    { 530, 70, "79.9", "Ostale usluge rezervacije" },
                    { 531, 71, "80.1", "Delatnost privatnog obezbeđenja" },
                    { 532, 71, "80.2", "Usluge sistema obezbeđenja" },
                    { 533, 71, "80.3", "Istražne delatnosti" },
                    { 534, 72, "81.1", "Usluge održavanja objekata" },
                    { 535, 72, "81.21", "Usluge redovnog čišćenja zgrada" },
                    { 536, 72, "81.22", "Usluge ostalog čišćenja zgrada i opreme" },
                    { 537, 72, "81.29", "Usluge ostalog čišćenja" },
                    { 538, 72, "81.3", "Usluge uređenja i održavanja okoline" },
                    { 539, 73, "82.11", "Kombinovane kancelarijsko-administrativne usluge" },
                    { 540, 73, "82.19", "Fotokopiranje i druga kancelarijska podrška" },
                    { 541, 73, "82.2", "Delatnost pozivnih centara" },
                    { 542, 73, "82.3", "Organizovanje sastanaka i sajmova" },
                    { 543, 73, "82.91", "Delatnost agencija za naplatu potraživanja" },
                    { 544, 73, "82.92", "Usluge pakovanja" },
                    { 545, 73, "82.99", "Ostale uslužne aktivnosti podrške poslovanju" },
                    { 546, 74, "84.11", "Delatnost državnih organa" },
                    { 547, 74, "84.12", "Uređivanje subjekata koji pružaju društvene usluge" },
                    { 548, 74, "84.13", "Uređenje poslovanja u oblasti ekonomije" },
                    { 549, 74, "84.21", "Spoljni poslovi" },
                    { 550, 74, "84.22", "Poslovi odbrane" },
                    { 551, 74, "84.23", "Sudske i pravosudne delatnosti" },
                    { 552, 74, "84.24", "Obezbeđivanje javnog reda i bezbednosti" },
                    { 553, 74, "84.25", "Delatnost vatrogasnih jedinica" },
                    { 554, 74, "84.3", "Obavezno socijalno osiguranje" },
                    { 555, 75, "85.1", "Predškolsko obrazovanje" },
                    { 556, 75, "85.2", "Osnovno obrazovanje" },
                    { 557, 75, "85.31", "Srednje opšte obrazovanje" },
                    { 558, 75, "85.32", "Srednje stručno obrazovanje" },
                    { 559, 75, "85.41", "Obrazovanje posle srednjeg koje nije visoko" },
                    { 560, 75, "85.42", "Visoko obrazovanje" },
                    { 561, 75, "85.51", "Sportsko i rekreativno obrazovanje" },
                    { 562, 75, "85.52", "Umetničko obrazovanje" },
                    { 563, 75, "85.53", "Delatnost škola za vozače" },
                    { 564, 75, "85.59", "Ostalo obrazovanje" },
                    { 565, 75, "85.6", "Pomoćne obrazovne delatnosti" },
                    { 566, 76, "86.1", "Delatnost bolnica" },
                    { 567, 76, "86.21", "Opšta medicinska praksa" },
                    { 568, 76, "86.22", "Specijalistička medicinska praksa" },
                    { 569, 76, "86.23", "Stomatološka praksa" },
                    { 570, 76, "86.9", "Ostala zdravstvena zaštita" },
                    { 571, 77, "87.1", "Delatnost smeštajnih ustanova s medicinskom negom" },
                    { 572, 77, "87.2", "Socijalno staranje u smeštajnim ustanovama" },
                    { 573, 77, "87.3", "Rad ustanova za lica s posebnim potrebama" },
                    { 574, 77, "87.9", "Ostali oblici socijalne zaštite sa smeštajem" },
                    { 575, 78, "88.1", "Socijalna zaštita bez smeštaja za stara lica" },
                    { 576, 78, "88.91", "Delatnost dnevne brige o deci" },
                    { 577, 78, "88.99", "Ostala nepomenuta socijalna zaštita bez smeštaja" },
                    { 578, 79, "90.01", "Izvođačka umetnost" },
                    { 579, 79, "90.02", "Druge umetničke delatnosti u okviru izvođačke umetnosti" },
                    { 580, 79, "90.03", "Umetničko stvaralaštvo" },
                    { 581, 79, "90.04", "Rad umetničkih ustanova" },
                    { 582, 80, "91.01", "Delatnost biblioteka i arhiva" },
                    { 583, 80, "91.02", "Delatnost muzeja, galerija i zbirki" },
                    { 584, 80, "91.03", "Zaštita i održavanje nepokretnih kulturnih dobara" },
                    { 585, 80, "91.04", "Delatnost botaničkih i zooloških vrtova" },
                    { 586, 81, "92.0", "Kockanje i klađenje" },
                    { 587, 82, "93.11", "Delatnost sportskih objekata" },
                    { 588, 82, "93.12", "Delatnost sportskih klubova" },
                    { 589, 82, "93.13", "Delatnost fitnes klubova" },
                    { 590, 82, "93.19", "Ostale sportske delatnosti" },
                    { 591, 82, "93.21", "Delatnost zabavnih i tematskih parkova" },
                    { 592, 82, "93.29", "Ostale zabavne i rekreativne delatnosti" },
                    { 593, 83, "94.11", "Delatnost poslovnih udruženja i poslodavaca" },
                    { 594, 83, "94.12", "Delatnost strukovnih udruženja" },
                    { 595, 83, "94.2", "Delatnost sindikata" },
                    { 596, 83, "94.91", "Delatnost verskih organizacija" },
                    { 597, 83, "94.92", "Delatnost političkih organizacija" },
                    { 598, 83, "94.99", "Delatnost ostalih organizacija na bazi učlanjenja" },
                    { 599, 84, "95.11", "Popravka računara i periferne opreme" },
                    { 600, 84, "95.12", "Popravka komunikacione opreme" },
                    { 601, 84, "95.21", "Popravka elektronskih aparata za široku upotrebu" },
                    { 602, 84, "95.22", "Popravka aparata za domaćinstvo i kućne opreme" },
                    { 603, 84, "95.23", "Popravka obuće i predmeta od kože" },
                    { 604, 84, "95.24", "Održavanje i popravka nameštaja" },
                    { 605, 84, "95.25", "Popravka satova i nakita" },
                    { 606, 84, "95.29", "Popravka ostalih ličnih predmeta" },
                    { 607, 85, "96.01", "Pranje i hemijsko čišćenje tekstilnih proizvoda" },
                    { 608, 85, "96.02", "Delatnost frizerskih i kozmetičkih salona" },
                    { 609, 85, "96.03", "Pogrebne i srodne delatnosti" },
                    { 610, 85, "96.04", "Delatnost nege i održavanja tela" },
                    { 611, 85, "96.09", "Ostale nepomenute lične uslužne delatnosti" },
                    { 612, 86, "97.0", "Domaćinstava koja zapošljavaju poslugu" },
                    { 613, 87, "98.1", "Domaćinstava koja proizvode robu za sebe" },
                    { 614, 87, "98.2", "Domaćinstava koja obezbeđuju usluge za sebe" },
                    { 615, 88, "99.0", "Delatnost eksteritorijalnih organizacija i tela" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityGroups_ActivitySectorId",
                table: "ActivityGroups",
                column: "ActivitySectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityGroups_ActivitySectors_ActivitySectorId",
                table: "ActivityGroups",
                column: "ActivitySectorId",
                principalTable: "ActivitySectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityGroups_ActivitySectors_ActivitySectorId",
                table: "ActivityGroups");

            migrationBuilder.DropTable(
                name: "ActivitySectors");

            migrationBuilder.DropIndex(
                name: "IX_ActivityGroups_ActivitySectorId",
                table: "ActivityGroups");

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 240);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 241);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 242);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 243);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 244);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 245);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 246);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 247);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 248);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 249);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 250);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 251);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 252);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 253);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 254);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 255);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 256);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 257);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 258);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 259);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 260);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 261);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 262);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 263);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 264);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 265);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 266);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 267);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 268);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 269);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 270);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 271);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 272);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 273);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 274);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 275);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 276);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 277);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 278);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 279);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 280);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 281);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 282);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 283);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 284);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 285);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 286);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 287);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 288);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 289);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 290);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 291);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 292);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 293);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 294);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 295);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 296);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 297);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 298);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 299);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 304);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 305);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 306);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 307);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 308);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 309);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 310);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 311);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 312);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 313);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 314);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 315);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 316);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 317);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 318);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 319);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 320);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 321);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 322);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 323);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 324);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 325);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 326);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 327);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 328);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 329);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 330);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 331);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 332);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 333);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 334);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 335);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 336);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 337);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 338);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 339);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 340);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 341);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 342);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 343);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 344);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 345);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 346);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 347);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 348);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 349);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 350);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 351);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 352);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 353);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 354);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 355);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 356);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 357);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 358);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 359);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 360);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 361);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 362);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 363);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 364);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 365);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 366);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 367);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 368);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 369);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 370);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 371);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 372);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 373);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 374);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 375);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 376);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 377);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 378);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 379);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 380);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 381);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 382);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 383);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 384);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 385);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 386);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 387);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 388);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 389);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 390);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 391);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 392);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 393);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 394);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 395);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 396);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 397);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 398);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 399);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 400);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 401);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 402);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 403);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 404);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 405);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 406);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 407);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 408);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 409);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 410);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 411);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 412);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 413);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 414);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 415);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 416);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 417);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 418);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 419);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 420);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 421);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 422);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 423);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 424);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 425);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 426);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 427);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 428);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 429);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 430);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 431);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 432);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 433);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 434);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 435);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 436);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 437);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 438);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 439);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 440);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 441);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 442);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 443);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 444);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 445);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 446);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 447);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 448);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 449);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 450);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 451);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 452);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 453);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 454);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 455);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 456);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 457);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 458);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 459);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 460);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 461);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 462);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 463);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 464);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 465);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 466);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 467);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 468);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 469);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 470);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 471);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 472);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 473);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 474);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 475);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 476);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 477);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 478);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 479);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 480);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 481);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 482);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 483);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 484);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 485);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 486);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 487);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 488);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 489);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 490);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 491);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 492);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 493);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 494);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 495);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 496);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 497);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 498);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 499);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 500);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 501);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 502);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 503);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 504);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 505);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 506);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 507);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 508);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 509);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 510);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 511);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 512);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 513);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 514);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 515);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 516);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 517);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 518);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 519);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 520);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 521);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 522);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 523);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 524);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 525);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 526);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 527);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 528);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 529);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 530);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 531);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 532);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 533);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 534);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 535);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 536);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 537);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 538);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 539);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 540);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 541);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 542);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 543);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 544);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 545);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 546);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 547);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 548);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 549);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 550);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 551);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 552);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 553);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 554);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 555);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 556);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 557);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 558);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 559);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 560);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 561);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 562);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 563);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 564);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 565);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 566);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 567);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 568);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 569);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 570);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 571);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 572);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 573);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 574);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 575);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 576);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 577);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 578);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 579);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 580);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 581);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 582);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 583);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 584);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 585);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 586);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 587);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 588);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 589);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 590);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 591);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 592);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 593);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 594);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 595);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 596);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 597);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 598);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 599);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 600);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 601);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 602);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 603);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 604);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 605);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 606);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 607);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 608);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 609);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 610);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 611);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 612);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 613);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 614);

            migrationBuilder.DeleteData(
                table: "ActivityCodes",
                keyColumn: "Id",
                keyValue: 615);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "ActivityGroups",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DropColumn(
                name: "ActivitySectorId",
                table: "ActivityGroups");
        }
    }
}
