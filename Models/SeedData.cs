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
            }


            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        ProductName = "Fyom leg buol iunhum en",
                        ProductImage = "https://product.hstatic.net/1000173770/product/ce57s--main-image-1024px-2_38d3b8d356544d9cb3bacf42aae9c9d2_compact.png",
                        Price = 919,
                        Description = "Farad ne felleyn scegegkel eses thudothlon scepsegud en ezes illen sydou sydou kynzassal fugwa mezuul egyre fyodum wklelue de ualallal kynzathul maraggun ere buabeleul wylag ezes merth mezuul num syrou mezuul niha en keguggethuk urodum uos therthetyk ygoz vylagumtul werud vylag qui bel buol syrou ozuk fyomnok kynaal ezes erzem",
                        Status = 1,
                        CategoryID = 1,
                    },new Product
                    {
                        ProductName = "En kyul therthetyk",
                        ProductImage = "https://product.hstatic.net/1000173770/product/ce57s--main-image-1024px-2_38d3b8d356544d9cb3bacf42aae9c9d2_compact.png",
                        Price = 1200,
                        Description = "Fyaal kynzathul scemem engumet ygoz mezuul aniath merth iunhum syrolm vylag wklelue vylag hol ygoz volek the kynaal en felleyn hul fyon thekunched ez mezuul de halal fyom yg bezzeg ere symeonnok iunhum yg farad uos ere fyomnok fuhazatum felleyn egyre scemem halallal hullothya merth sydou eggedum en fyodumtul syrolmol",
                        Status = 1,
                        CategoryID = 1
                    },new Product
                    {
                        ProductName = "Halallal sepedyk scouuo the",
                        ProductImage = "https://product.hstatic.net/1000173770/product/ce57s--main-image-1024px-2_38d3b8d356544d9cb3bacf42aae9c9d2_compact.png",
                        Price = 327,
                        Description = "Wirud ualmun syrolmol aniath thudothlon vh myth aniath fyodumtul uiraga huztuzwa tuled walasth the sumha myth en fuhazatum turuentelen fyodumtul felleyn syrolmol halal buabeleul wklelue volek vylagumtul kegulm huztuzwa buol erzem huztuzwa kyul ezes sepedyk ulud buol fyodumtul en eggen erzem huztuzwa vylagumtul tuled sepedyk iunhum kynzathul scepsegud kyt tuled",
                        Status = 1,
                        CategoryID = 1
                    },new Product
                    {
                        ProductName = "Ezes vh scemem sydou halal",
                        ProductImage = "https://product.hstatic.net/1000173770/product/ce57s--main-image-1024px-2_38d3b8d356544d9cb3bacf42aae9c9d2_compact.png",
                        Price = 458,
                        Description = "Urodum syrou qui fyodum kethwe wyzeul kynzathul ez ygoz uos bezzeg symeonnok yg urodum olelothya kynzathul uos bua urodum keguggethuk halal maraggun fyomnok merth kyth aniath ualmun de en en olelothya hioll fyodum buabeleul bezzeg buabeleul yg num engumet thekunched en bua syrou ne kyniuhhad syrou scepsegud felleyn halallal ez",
                        Status = 1,
                        CategoryID = 1
                    },


                    //

                    new Product
                    {
                        ProductName = "O byuntelen kyth thekunched",
                        ProductImage = "https://www.google.com/url?sa=i&url=https%3A%2F%2Ftiki.vn%2Ftu-lanh-panasonic-inverter-368-lit-nr-bx410wkvn-hang-chinh-hang-p52155021.html&psig=AOvVaw3wpTluNHnYiuBTl775qiEZ&ust=1607440306772000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCJDynPaTvO0CFQAAAAAdAAAAABAV",
                        Price = 324,
                        Description = "Fyon volek farad en wegh egyre niha maraggun eggedum halal ozuk arad iumhumnok halal owog urumemtuul kyniuhhad maraggun kegulm scepsegud qui epedek wirud fyaal bezzeg wyzeul de o owog wirud buol hioll fyom anyath halallal symeonnok kegulm therthetyk kyniuhhad hol fuhazatum fyom kegulm scemem fugwa anyath ere fuhazatum en buthuruth",
                        Status = 1,
                        CategoryID = 2
                    },new Product
                    {
                        ProductName = "Iumhumnok buol ne",
                        ProductImage = "https://www.google.com/url?sa=i&url=https%3A%2F%2Ftiki.vn%2Ftu-lanh-panasonic-inverter-368-lit-nr-bx410wkvn-hang-chinh-hang-p52155021.html&psig=AOvVaw3wpTluNHnYiuBTl775qiEZ&ust=1607440306772000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCJDynPaTvO0CFQAAAAAdAAAAABAV",
                        Price = 453,
                        Description = "Kegulm arad scegegkel urodum scegegkel kynzathul buthuruth thekunched fyon scemem fyomnok urumemtuul ualmun scemem kyt iunhum iumhumnok iunhum viragnac kunuel urumemtuul illen uiraga mogomnok huztuzwa sydou felleyn ezes epedek egyre aniath werethul en scegenul nequem buol niha kyul fyodumtul ualmun thekunched en num maraggun vh yg byuntelen owog maraggun eggen",
                        Status = 1,
                        CategoryID = 2
                    }, new Product
                    {
                        ProductName = "Buabeleul scouuo kynzathul",
                        ProductImage = "https://www.google.com/url?sa=i&url=https%3A%2F%2Ftiki.vn%2Ftu-lanh-panasonic-inverter-368-lit-nr-bx410wkvn-hang-chinh-hang-p52155021.html&psig=AOvVaw3wpTluNHnYiuBTl775qiEZ&ust=1607440306772000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCJDynPaTvO0CFQAAAAAdAAAAABAV",
                        Price = 346,
                        Description = "O anyath kyth symeonnok eggen ne wylag en qui syrou vylag syrou tuled ezes fyodumtul halal tuled en en eses en yg en wirud farad mogomnok volek qui symeonnok uilaga syrolmom walasth en hioll sydou huztuzwa hol eggen fyom iunhum the maraggun fyodum vylag nequem nym hul ygoz fyom en",
                        Status = 1,
                        CategoryID = 2
                    }, new Product
                    {
                        ProductName = "Eggedum werud syrolmol",
                        ProductImage = "https://www.google.com/url?sa=i&url=https%3A%2F%2Ftiki.vn%2Ftu-lanh-panasonic-inverter-368-lit-nr-bx410wkvn-hang-chinh-hang-p52155021.html&psig=AOvVaw3wpTluNHnYiuBTl775qiEZ&ust=1607440306772000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCJDynPaTvO0CFQAAAAAdAAAAABAV",
                        Price = 356,
                        Description = "Sepedyk kyul viragnac o en uos kethwe scegenul werud hullothya egyre niha eses en syrolmol wegh scepsegud viragnac turuentelen therthetyk sumha owog kyniuhhad illen syrolmol wirud fyom ualmun engumet egyre en ere en fyomnok erzem ez buol ozuk vylag syrolmol uos vylag hullothya myth thudothlon therthetyk wegh vylagumtul engumet thez",
                        Status = 1,
                        CategoryID = 2
                    },

                     //
                      new Product
                     {
                         ProductName = "Tuled kyul eses",
                         ProductImage = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.thespruceeats.com%2Fkitchen-cleaning-tips-481830&psig=AOvVaw3crAwtPZrUkyQ2RdMS7G_-&ust=1607440507080000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCKD3stiUvO0CFQAAAAAdAAAAABAD",
                         Price = 555,
                         Description = "En wylag sydou iunhum ualmun urodum ez qui fyodum merth hyul ozuk epedek uiraga kunuel fyaal keseruen bua vh thudothlon halallal eses en erzem en halal halal wklelue ualallal syrou num fyaal erzem hyul hullothya vylag kyth mezuul uilaga wyzeul wylag bua buabeleul syrolmom tuled hul kynaal eggen kynzathul fyodumtul",
                         Status = 1,
                         CategoryID = 3
                     }, new Product
                     {
                         ProductName = "Iunhum uilaga",
                         ProductImage = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.thespruceeats.com%2Fkitchen-cleaning-tips-481830&psig=AOvVaw3crAwtPZrUkyQ2RdMS7G_-&ust=1607440507080000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCKD3stiUvO0CFQAAAAAdAAAAABAD",
                         Price = 231,
                         Description = "Scegegkel sumha uiraga fyaal fyon ezes keguggethuk aniath buol myth ualallal fyaal fyodumtul wegh werethul bua epedek fyomnok en ne scemem ne mezuul iunhum mogomnok hul owog wylag urodum scepsegud kyul ere kegulm wyzeul o syrou en en keguggethuk scemem",
                         Status = 1,
                         CategoryID = 3
                     }, new Product
                     {
                         ProductName = "Bua urodum mezuul",
                         ProductImage = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.thespruceeats.com%2Fkitchen-cleaning-tips-481830&psig=AOvVaw3crAwtPZrUkyQ2RdMS7G_-&ust=1607440507080000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCKD3stiUvO0CFQAAAAAdAAAAABAD",
                         Price = 1235,
                         Description = "Halallal num kyniuhhad vh aniath ezes syrolmom fyodumtul wirud kyt viragnac o hioll en sepedyk ozuk felleyn wyzeul iunhum engumet felleyn en fyodumtul epedek symeonnok ne scemem iunhum yg volek thekunched mezuul walasth qui kyth kyul de ezes kynzassal kunuel yg keseruen urumemtuul kynaal felleyn keseruen kyniuhhad ozuk buabeleul en",
                         Status = 1,
                         CategoryID = 3
                     }, new Product
                     {
                         ProductName = "Iunhum ualallal en halal",
                         ProductImage = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.thespruceeats.com%2Fkitchen-cleaning-tips-481830&psig=AOvVaw3crAwtPZrUkyQ2RdMS7G_-&ust=1607440507080000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCKD3stiUvO0CFQAAAAAdAAAAABAD",
                         Price = 543,
                         Description = "Fyom sumha scouuo eggen egyre farad scemem aniath uilaga wirud nym keguggethuk buol leg bua iumhumnok uilaga en ere vylagumtul scepsegud iunhum aniath eses hioll uilaga tuled fyodum ezes hyul egyre scepsegud buabeleul bua egyre sydou huztuzwa kyth en nym syrolm anyath syrolmol ere wirud niha olelothya hullothya kyul ez",
                         Status = 1,
                         CategoryID = 3
                     }

                      //

                    , new Product
                    {
                        ProductName = "Ne epedek ezes fyodum urodum",
                        ProductImage = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.foodnetwork.com%2Fhealthyeats%2F2010%2F07%2Ffood-preserving-safety&psig=AOvVaw1rLQB8M9IFYsVC--sFn9Ga&ust=1607440683145000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCNDv3aqVvO0CFQAAAAAdAAAAABAI",
                        Price = 667,
                        Description = "",
                        Status = 1,
                        CategoryID = 4
                    },new Product
                    {
                        ProductName = "Bua scegegkel kyul buthuruth mezuul",
                        ProductImage = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.foodnetwork.com%2Fhealthyeats%2F2010%2F07%2Ffood-preserving-safety&psig=AOvVaw1rLQB8M9IFYsVC--sFn9Ga&ust=1607440683145000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCNDv3aqVvO0CFQAAAAAdAAAAABAI",
                        Price = 543,
                        Description = "Felleyn kyt hyul urodum epedek wyzeul the bel ez egyre syrolm syrolmom wylag ezes o scouuo keseruen sepedyk vh arad tuled kynzathul keguggethuk werud syrolm kynaal keguggethuk werud halal uiraga egembelu ualallal walasth o vylagumtul arad qui halal ezes erzem farad hol merth anyath ezes walasth wirud ere urodum ozuk",
                        Status = 1,
                        CategoryID = 4
                    }, new Product
                    {
                        ProductName = "Sumha ozuk vylagumtul ualallal niha",
                        ProductImage = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.foodnetwork.com%2Fhealthyeats%2F2010%2F07%2Ffood-preserving-safety&psig=AOvVaw1rLQB8M9IFYsVC--sFn9Ga&ust=1607440683145000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCNDv3aqVvO0CFQAAAAAdAAAAABAI",
                        Price = 453,
                        Description = "Kynzassal erzem syrou fyaal buthuruth en halallal en en ezes hyul egembelu hyul werethul tuled farad en bel keseruen mezuul yg vh kegulm erzem anyath wklelue bel kegulm fugwa owog nym iunhum eses keguggethuk hyul uilaga urodum sydou scegenul halallal scepsegud iunhum merth egembelu eggen farad uilaga kyul farad yg",
                        Status = 1,
                        CategoryID = 4
                    }, new Product
                    {
                        ProductName = "O niha nym scemem scepsegud",
                        ProductImage = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.foodnetwork.com%2Fhealthyeats%2F2010%2F07%2Ffood-preserving-safety&psig=AOvVaw1rLQB8M9IFYsVC--sFn9Ga&ust=1607440683145000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCNDv3aqVvO0CFQAAAAAdAAAAABAI",
                        Price = 765,
                        Description = "En kegulm kynzathul tuled keguggethuk mezuul de kyul thudothlon thez kynzassal fugwa mezuul aniath engumet uilaga fugwa ygoz thez scegenul bezzeg uilaga fyodumtul kyul fyaal fyomnok sumha mogomnok hyul egyre eggedum thudothlon erzem egyre hullothya urodum ulud ezes volek urodum halal eses walasth urodum syrolm wegh turuentelen en wirud fyom",
                        Status = 1,
                        CategoryID = 4
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
