using Microsoft.EntityFrameworkCore;
using Telebot.Sourse.Handlers;
using Telebot.Sourse.Item;
using Telebot.Sourse.Item.IItem;
using Telegram.Bot;

namespace Telebot.Sourse
{
    public class context : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=NewStartBD;Trusted_Connection=True;");
            //Server=(localdb)\mssqllocaldb;Database=D:\MegaBot 1.0\teleBot\MegoDB.mdf;Trusted_Connection=True;
            //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="D:\MegaBot 1.0\teleBot\MegoDB.mdf";Integrated Security=True

            //optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning));

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<MyUser>()
            //      .HasMany(c => c.Chats)
            //      .WithMany(s => s.CurentUsers)
            //      .UsingEntity(j => j.ToTable("UserChats")); //  таблица для попределения отношения между чатом и юзером 







            modelBuilder
        .Entity<MyChat>()
        .HasMany(u => u.Update)
        .WithOne(p => p.ChatFrom)
        .HasForeignKey(p => p.ChatFromId);




            modelBuilder
        .Entity<myMenuProcess>()
        .HasMany(u => u.Buttons)
        .WithOne(p => p.CurentMenu)
        .HasForeignKey(p => p.CurentMenuId);



      

            //     modelBuilder
            //.Entity<Process>()
            //.HasMany(u => u.PriviousProcess)
            //.WithOne(p => p.PriviousProcess)
            //.HasForeignKey(p => p.PriviousProcessId);

            modelBuilder.Entity<BotProperties>().HasData(
            new BotProperties[]
            {
                new BotProperties { MyId=1,  LastUpdateId=0, BotClientId=6240171220},

            });
            //вынести в конфиг



            //------
            var startMenu_admin = new myMenuProcess()
            {
                dateTimeCreation = DateTime.Now,
                MyId = 1,
                BotClientId = 6240171220,
                MyName = "меню администратора",
                IsDelite = false,

            };
            startMenu_admin.MyDescription = $"Obj type: {startMenu_admin.GetType().Name}|Id BD: {startMenu_admin.MyId}|Text: {startMenu_admin.MyName}";




            //раздва три
            //-------
            //var button_startmenu_createprocess = new myButtons() 
            //{ 
            //    BotClientId= 6240171220,
            //    CurentMenu= startMenu_admin,
            //     CurentMenuId= startMenu_admin.MyId,
            //     dateTimeCreation= DateTime.Now,
            //      isCreated= true,
            //       IsDelite= false,
            //        MyId=1,
            //         NextMenu=null,
            //          MyName="Создать новый опрос",

                       

            //};



            modelBuilder.Entity<myMenuProcess>().HasData(
            new myMenuProcess[]
            {
                startMenu_admin
            });


        }



        public context()
        {
            // Database.EnsureDeleted();
            Database.EnsureCreated();




        }


        public void reSetBD(bool needDelete, ITelegramBotClient client, CancellationToken cts)
        {

            if (needDelete)
            {

                Database.EnsureDeleted();
                Console.WriteLine("------------------------------------------------");
                concoldebuger.goodMSG("бд обнавлена", client, cts);
                Console.WriteLine("------------------------------------------------");
            }
            Database.EnsureCreated();


        }



        public DbSet<MyUser> MyUsers { set; get; }
        public DbSet<MyChat> myChats { set; get; }

        public DbSet<MyUserUpdates> myUserUpdates { set; get; }


        public DbSet<BotProperties> BotProperties { set; get; }

        public DbSet<myMenuProcess> myProcessMenues { set; get; }

        public DbSet<myButtons> myButtons { set; get; }

        //public DbSet<myPhoto> myPhotoes { set; get; }

        //public DbSet<PriviosMSG> MessagesNeeTodelite { set; get; }

        // public DbSet<Process> Processes { set; get; }
        //public DbSet<MyBtns>  MyBtns { set; get; }




        //
        //  public DbSet<Item.WorckItems.ItemType> ObjTypes  { set; get; }


    }
}
