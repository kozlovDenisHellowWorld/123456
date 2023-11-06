using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telebot.Sourse;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

using Telebot.Sourse.Item;
using Telebot.Sourse.Handlers;



namespace Telebot
{
    

    public class TeleClient
    {

        static bool needToUpdate = true;

        private string Token;

        static public TelegramBotClient myClient;

        static CancellationTokenSource myCansToken = new CancellationTokenSource();

        static public string myToken { private set; get; }

        static private ReceiverOptions myReceveOptions = new ReceiverOptions
        {
            AllowedUpdates = Array.Empty<UpdateType>()
        };


        public TeleClient(string token)
        {
           

            Token = token;

            myClient = new TelegramBotClient(token);
            myClient = new TelegramBotClient(token);
            myToken = token;
            
            MyStart();
            Console.ReadKey();

        }


        public async void MyStart()
        {


           
            Console.WriteLine("Необходимость в обновлении - "+ needToUpdate.ToString());
            using (var db= new context())
            {
                db.reSetBD(needToUpdate, myClient, myCansToken.Token);

            }

            myClient.StartReceiving(
                myUpdate,
                myErrohendler,
                myReceveOptions,
                myCansToken.Token);

            var my = await myClient.GetMeAsync(myCansToken.Token);

            Console.WriteLine("------------------------------------------------");
            concoldebuger.goodMSG($"Стартовал\nid: {my.Id}\nUserName: {my.Username}", myClient, myCansToken.Token);


        }


        private async Task myErrohendler(ITelegramBotClient client, Exception exception, CancellationToken arg3)
        {
            //await myClient.SendTextMessageAsync(, exception.Message, cancellationToken: myCansToken);

            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            
            
             
            concoldebuger.badMSG(exception.InnerException.ToString(),client, arg3);
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            
            MyStart();
            //InnerException = {"The INSERT statement conflicted with the FOREIGN KEY constraint \"FK_myUserUpdates_myChats_ChatIdFrom\".
            //The conflict occurred in database \"NewStartBD\", table \"dbo.myChats\", column 'MyId'."}
        }

        //Постоянство  Id = 483856953

        private async Task myUpdate(ITelegramBotClient iClient, Update update, CancellationToken cancellationToken)
        {
            
            concoldebuger.notifMSG($"\n========================= Новое Update =========================",iClient, cancellationToken);
            concoldebuger.notifMSG($"Update - id: {update.Id}| Type: {update.Type}", iClient, cancellationToken);


            //новый update и создание пользователей если их нет 
            string newUpdateResult= await  HandlerNewUpdate.newUpdateHendler(iClient, update, cancellationToken);
            concoldebuger.sistemMSG(newUpdateResult, iClient, cancellationToken);
            if (newUpdateResult.ToLower().Contains("false")) return;
            // запись update
            string updateresult =await HandlerNewUpdate.saveUpdateInfo(iClient, update, cancellationToken);
            concoldebuger.sistemMSG(updateresult, iClient, cancellationToken);


            //Обробка пришедшего сообшения 
            string processHendler= await HandlerNewUpdate.processHendler(iClient, update, cancellationToken);







            //изменение последненого update и окончание обработки
            string changeupdateId= await HandlerNewUpdate.changeLastupdateId(iClient, update, cancellationToken);
            concoldebuger.sistemMSG(changeupdateId, iClient, cancellationToken);





            HandlerNewUpdate.testPost(iClient,update, cancellationToken);


        }





    }
}
