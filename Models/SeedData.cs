using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Kitchen_Appliances.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category
                    {
                        CategoryName = "Kitchen Tools",
                        CategoryImage = "https://images.pexels.com/photos/2544829/pexels-photo-2544829.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                        CategoryIcon = "fas fa-utensils"
                    },
                    new Category
                    {
                        CategoryName = "Fridge",
                        CategoryImage = "https://images.pexels.com/photos/2343467/pexels-photo-2343467.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                        CategoryIcon = "fas fa-solar-panel"
                    },
                    new Category
                    {
                        CategoryName = "Kitchen cleaning",
                        CategoryImage = "https://images.pexels.com/photos/4022784/pexels-photo-4022784.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                        CategoryIcon = "fas fa-hand-sparkles"
                    },
                    new Category
                    {
                        CategoryName = "Food preservation",
                        CategoryImage = "https://images.pexels.com/photos/1640776/pexels-photo-1640776.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                        CategoryIcon = "fas fa-prescription-bottle"
                    }
                    );
                context.SaveChanges();
            }



            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        ProductName = "Fyom leg buol iunhum en",
                        ProductImage = "https://product.hstatic.net/1000375725/product/1024_5c773b8106494c81973f946fe1c8555c_master.jpg",
                        Price = 919,
                        Description = "Farad ne felleyn scegegkel eses thudothlon scepsegud en ezes illen sydou sydou kynzassal fugwa mezuul egyre fyodum wklelue de ualallal kynzathul maraggun ere buabeleul wylag ezes merth mezuul num syrou mezuul niha en keguggethuk urodum uos therthetyk ygoz vylagumtul werud vylag qui bel buol syrou ozuk fyomnok kynaal ezes erzem",
                        Status = 1,
                        CategoryID = 1,
                    }, new Product
                    {
                        ProductName = "En kyul therthetyk",
                        ProductImage = "https://vn-test-11.slatic.net/original/fa152a507f45dc1d73bb65250a84d2cb.jpg_600x600q80.jpg",
                        Price = 1200,
                        Description = "Fyaal kynzathul scemem engumet ygoz mezuul aniath merth iunhum syrolm vylag wklelue vylag hol ygoz volek the kynaal en felleyn hul fyon thekunched ez mezuul de halal fyom yg bezzeg ere symeonnok iunhum yg farad uos ere fyomnok fuhazatum felleyn egyre scemem halallal hullothya merth sydou eggedum en fyodumtul syrolmol",
                        Status = 1,
                        CategoryID = 1
                    }, new Product
                    {
                        ProductName = "Halallal sepedyk scouuo the",
                        ProductImage = "https://salt.tikicdn.com/cache/w444/ts/product/1a/8c/8b/0e7c054639b65bf7b0a9d1a003b35a48.jpg",
                        Price = 327,
                        Description = "Wirud ualmun syrolmol aniath thudothlon vh myth aniath fyodumtul uiraga huztuzwa tuled walasth the sumha myth en fuhazatum turuentelen fyodumtul felleyn syrolmol halal buabeleul wklelue volek vylagumtul kegulm huztuzwa buol erzem huztuzwa kyul ezes sepedyk ulud buol fyodumtul en eggen erzem huztuzwa vylagumtul tuled sepedyk iunhum kynzathul scepsegud kyt tuled",
                        Status = 1,
                        CategoryID = 1
                    }, new Product
                    {
                        ProductName = "Ezes vh scemem sydou halal",
                        ProductImage = "https://toplist.vn/images/800px/dong-dao-gom-kyocera-nhat-ban-512534.jpg",
                        Price = 458,
                        Description = "Urodum syrou qui fyodum kethwe wyzeul kynzathul ez ygoz uos bezzeg symeonnok yg urodum olelothya kynzathul uos bua urodum keguggethuk halal maraggun fyomnok merth kyth aniath ualmun de en en olelothya hioll fyodum buabeleul bezzeg buabeleul yg num engumet thekunched en bua syrou ne kyniuhhad syrou scepsegud felleyn halallal ez",
                        Status = 1,
                        CategoryID = 1
                    },

                    //fridge

                    new Product
                    {
                        ProductName = "O byuntelen kyth thekunched",
                        ProductImage = "https://cdn.tgdd.vn/Products/Images/1943/209331/tu-lanh-panasonic-nr-bv280qsvn-300x300.jpg",
                        Price = 324,
                        Description = "Fyon volek farad en wegh egyre niha maraggun eggedum halal ozuk arad iumhumnok halal owog urumemtuul kyniuhhad maraggun kegulm scepsegud qui epedek wirud fyaal bezzeg wyzeul de o owog wirud buol hioll fyom anyath halallal symeonnok kegulm therthetyk kyniuhhad hol fuhazatum fyom kegulm scemem fugwa anyath ere fuhazatum en buthuruth",
                        Status = 1,
                        CategoryID = 2
                    }, new Product
                    {
                        ProductName = "Iumhumnok buol ne",
                        ProductImage = "https://cdn.tgdd.vn/Products/Images/1943/158471/tu-lanh-samsung-rt38k5982bs-sv--300x300.jpg",
                        Price = 453,
                        Description = "Kegulm arad scegegkel urodum scegegkel kynzathul buthuruth thekunched fyon scemem fyomnok urumemtuul ualmun scemem kyt iunhum iumhumnok iunhum viragnac kunuel urumemtuul illen uiraga mogomnok huztuzwa sydou felleyn ezes epedek egyre aniath werethul en scegenul nequem buol niha kyul fyodumtul ualmun thekunched en num maraggun vh yg byuntelen owog maraggun eggen",
                        Status = 1,
                        CategoryID = 2
                    }, new Product
                    {
                        ProductName = "Buabeleul scouuo kynzathul",
                        ProductImage = "https://cdn.tgdd.vn/Products/Images/1943/220507/panasonic-nr-bl263pkvn-3-300x300.jpg",
                        Price = 346,
                        Description = "O anyath kyth symeonnok eggen ne wylag en qui syrou vylag syrou tuled ezes fyodumtul halal tuled en en eses en yg en wirud farad mogomnok volek qui symeonnok uilaga syrolmom walasth en hioll sydou huztuzwa hol eggen fyom iunhum the maraggun fyodum vylag nequem nym hul ygoz fyom en",
                        Status = 1,
                        CategoryID = 2
                    }, new Product
                    {
                        ProductName = "Eggedum werud syrolmol",
                        ProductImage = "https://germankitchen.vn/Data/ResizeImage/files/tulanh/KAD90VB20x200x200x5.jpg",
                        Price = 356,
                        Description = "Sepedyk kyul viragnac o en uos kethwe scegenul werud hullothya egyre niha eses en syrolmol wegh scepsegud viragnac turuentelen therthetyk sumha owog kyniuhhad illen syrolmol wirud fyom ualmun engumet egyre en ere en fyomnok erzem ez buol ozuk vylag syrolmol uos vylag hullothya myth thudothlon therthetyk wegh vylagumtul engumet thez",
                        Status = 1,
                        CategoryID = 2
                    },

                      //clean

                      new Product
                      {
                          ProductName = "Tuled kyul eses",
                          ProductImage = "https://afamilycdn.com/2018/11/5/d4-1541418657932221700217.jpeg",
                          Price = 555,
                          Description = "En wylag sydou iunhum ualmun urodum ez qui fyodum merth hyul ozuk epedek uiraga kunuel fyaal keseruen bua vh thudothlon halallal eses en erzem en halal halal wklelue ualallal syrou num fyaal erzem hyul hullothya vylag kyth mezuul uilaga wyzeul wylag bua buabeleul syrolmom tuled hul kynaal eggen kynzathul fyodumtul",
                          Status = 1,
                          CategoryID = 3
                      }, new Product
                      {
                          ProductName = "Iunhum uilaga",
                          ProductImage = "https://kitchenstore.vn/wp-content/uploads/2019/12/Kem-tay-ve-sinh-bep-lo-Astonish-C8600-2-1-247x247.png",
                          Price = 231,
                          Description = "Scegegkel sumha uiraga fyaal fyon ezes keguggethuk aniath buol myth ualallal fyaal fyodumtul wegh werethul bua epedek fyomnok en ne scemem ne mezuul iunhum mogomnok hul owog wylag urodum scepsegud kyul ere kegulm wyzeul o syrou en en keguggethuk scemem",
                          Status = 1,
                          CategoryID = 3
                      }, new Product
                      {
                          ProductName = "Bua urodum mezuul",
                          ProductImage = "https://dathangsi.vn/upload/products/2019/11/11_1015-cay-co-cha-rua-xoong-2in1-co-cho-dung-xa-phong.jpg",
                          Price = 1235,
                          Description = "Halallal num kyniuhhad vh aniath ezes syrolmom fyodumtul wirud kyt viragnac o hioll en sepedyk ozuk felleyn wyzeul iunhum engumet felleyn en fyodumtul epedek symeonnok ne scemem iunhum yg volek thekunched mezuul walasth qui kyth kyul de ezes kynzassal kunuel yg keseruen urumemtuul kynaal felleyn keseruen kyniuhhad ozuk buabeleul en",
                          Status = 1,
                          CategoryID = 3
                      }, new Product
                      {
                          ProductName = "Iunhum ualallal en halal",
                          ProductImage = "https://ae01.alicdn.com/kf/H7fb627de93794e3c8ae587c339ea61e9V.jpg_q50.jpg",
                          Price = 543,
                          Description = "Fyom sumha scouuo eggen egyre farad scemem aniath uilaga wirud nym keguggethuk buol leg bua iumhumnok uilaga en ere vylagumtul scepsegud iunhum aniath eses hioll uilaga tuled fyodum ezes hyul egyre scepsegud buabeleul bua egyre sydou huztuzwa kyth en nym syrolm anyath syrolmol ere wirud niha olelothya hullothya kyul ez",
                          Status = 1,
                          CategoryID = 3
                      }

                      //box

                    , new Product
                    {
                        ProductName = "Ne epedek ezes fyodum urodum",
                        ProductImage = "https://product.hstatic.net/1000296871/product/hf395bbe1c8e147a6b2b9a9b78cab35d0y_0137aad9711b4939923f2f1d674a42db_master.jpg",
                        Price = 667,
                        Description = "",
                        Status = 1,
                        CategoryID = 4
                    }, new Product
                    {
                        ProductName = "Bua scegegkel kyul buthuruth mezuul",
                        ProductImage = "https://image.thanhnien.vn/500/uploaded/2014/saigonamthuc.thanhnien.com.vn/pictures201409/ngoclinh/shutterstock_honey.jpg",
                        Price = 543,
                        Description = "Felleyn kyt hyul urodum epedek wyzeul the bel ez egyre syrolm syrolmom wylag ezes o scouuo keseruen sepedyk vh arad tuled kynzathul keguggethuk werud syrolm kynaal keguggethuk werud halal uiraga egembelu ualallal walasth o vylagumtul arad qui halal ezes erzem farad hol merth anyath ezes walasth wirud ere urodum ozuk",
                        Status = 1,
                        CategoryID = 4
                    }, new Product
                    {
                        ProductName = "Sumha ozuk vylagumtul ualallal niha",
                        ProductImage = "https://salt.tikicdn.com/cache/w444/ts/product/ad/60/3b/993fdd5b6cd854e0ecc7c227ee4a6a7a.jpg",
                        Price = 453,
                        Description = "Kynzassal erzem syrou fyaal buthuruth en halallal en en ezes hyul egembelu hyul werethul tuled farad en bel keseruen mezuul yg vh kegulm erzem anyath wklelue bel kegulm fugwa owog nym iunhum eses keguggethuk hyul uilaga urodum sydou scegenul halallal scepsegud iunhum merth egembelu eggen farad uilaga kyul farad yg",
                        Status = 1,
                        CategoryID = 4
                    }, new Product
                    {
                        ProductName = "O niha nym scemem scepsegud",
                        ProductImage = "https://m.viamclinic.vn/upload/banner/wip1587521968.jpg",
                        Price = 765,
                        Description = "En kegulm kynzathul tuled keguggethuk mezuul de kyul thudothlon thez kynzassal fugwa mezuul aniath engumet uilaga fugwa ygoz thez scegenul bezzeg uilaga fyodumtul kyul fyaal fyomnok sumha mogomnok hyul egyre eggedum thudothlon erzem egyre hullothya urodum ulud ezes volek urodum halal eses walasth urodum syrolm wegh turuentelen en wirud fyom",
                        Status = 1,
                        CategoryID = 4
                    }
                    );
                context.SaveChanges();
            }


            if (!context.Medias.Any())
            {
                context.Medias.AddRange(
                    new Media
                    {
                        MediaImage1 = "https://images.pexels.com/photos/109395/pexels-photo-109395.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                        MediaImage2 = "https://images.pexels.com/photos/109395/pexels-photo-109395.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                        MediaImage3 = "https://images.pexels.com/photos/109395/pexels-photo-109395.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                        ProductID = 1
                    }, new Media
                    {
                        MediaImage1 = "https://images.pexels.com/photos/5720778/pexels-photo-5720778.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                        MediaImage2 = "https://images.pexels.com/photos/5720778/pexels-photo-5720778.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                        MediaImage3 = "https://images.pexels.com/photos/5720778/pexels-photo-5720778.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                        ProductID = 2
                    }, new Media
                    {
                        MediaImage1 = "https://images.pexels.com/photos/594060/pexels-photo-594060.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                        MediaImage2 = "https://images.pexels.com/photos/594060/pexels-photo-594060.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                        MediaImage3 = "https://images.pexels.com/photos/594060/pexels-photo-594060.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                        ProductID = 3
                    }, new Media
                    {
                        MediaImage1 = "https://images.pexels.com/photos/269245/pexels-photo-269245.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                        MediaImage2 = "https://images.pexels.com/photos/269245/pexels-photo-269245.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                        MediaImage3 = "https://images.pexels.com/photos/269245/pexels-photo-269245.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                        ProductID = 4
                    }, new Media
                    {
                        MediaImage1 = "https://images.pexels.com/photos/691155/pexels-photo-691155.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                        MediaImage2 = "https://images.pexels.com/photos/691155/pexels-photo-691155.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                        MediaImage3 = "https://images.pexels.com/photos/691155/pexels-photo-691155.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                        ProductID = 5
                    }, new Media
                    {
                        MediaImage1 = "https://images.pexels.com/photos/238230/pexels-photo-238230.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                        MediaImage2 = "https://images.pexels.com/photos/238230/pexels-photo-238230.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                        MediaImage3 = "https://images.pexels.com/photos/238230/pexels-photo-238230.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                        ProductID = 6
                    }, new Media
                    {
                        MediaImage1 = "https://images.pexels.com/photos/3933200/pexels-photo-3933200.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                        MediaImage2 = "https://images.pexels.com/photos/3933200/pexels-photo-3933200.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                        MediaImage3 = "https://images.pexels.com/photos/3933200/pexels-photo-3933200.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                        ProductID = 7
                    }, new Media
                    {
                        MediaImage1 = "https://images.pexels.com/photos/4282688/pexels-photo-4282688.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500",
                        MediaImage2 = "https://images.pexels.com/photos/4282688/pexels-photo-4282688.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500",
                        MediaImage3 = "https://images.pexels.com/photos/4282688/pexels-photo-4282688.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500",
                        ProductID = 8
                    }, new Media
                    {
                        MediaImage1 = "https://images.pexels.com/photos/4637735/pexels-photo-4637735.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                        MediaImage2 = "https://images.pexels.com/photos/4637735/pexels-photo-4637735.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                        MediaImage3 = "https://images.pexels.com/photos/4637735/pexels-photo-4637735.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                        ProductID = 9
                    }, new Media
                    {
                        MediaImage1 = "https://images.pexels.com/photos/917300/pexels-photo-917300.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                        MediaImage2 = "https://images.pexels.com/photos/917300/pexels-photo-917300.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                        MediaImage3 = "https://images.pexels.com/photos/917300/pexels-photo-917300.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                        ProductID = 10
                    }, new Media
                    {
                        MediaImage1 = "https://images.pexels.com/photos/1568639/pexels-photo-1568639.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500",
                        MediaImage2 = "https://images.pexels.com/photos/1568639/pexels-photo-1568639.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500",
                        MediaImage3 = "https://images.pexels.com/photos/1568639/pexels-photo-1568639.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500",
                        ProductID = 11
                    }, new Media
                    {
                        MediaImage1 = "https://images.pexels.com/photos/3850924/pexels-photo-3850924.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                        MediaImage2 = "https://images.pexels.com/photos/3850924/pexels-photo-3850924.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                        MediaImage3 = "https://images.pexels.com/photos/3850924/pexels-photo-3850924.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                        ProductID = 12
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
