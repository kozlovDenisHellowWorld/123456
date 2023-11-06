using System.Diagnostics.SymbolStore;
using Telebot.Sourse.Item;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telebot.Sourse.Item.IItem;

namespace Telebot.Sourse
{
     public static class TeleTools
    {

        static public async Task<Message> SendStaticMenu(MyChat _myChat,  ITelegramBotClient client, CancellationToken canslationToken)
        {
            //  ITelegramBotClient telegramBotClient= client;

          


           //Message resut= await iClient.SendTextMessageAsync(curentChat.ChatId, curentChat.LastUserProcess().CurentProcess.MenuContent, replyMarkup: InitInlineKeyboard(_myChat.LastUserProcess().CurentProcess.Buttons, _myChat.LastUserProcess().CurentProcess.LinesInMenu),cancellationToken: canslationToken);

           


            return null;
        }
    }
    //{

    //    static public Item.TeleClientUser GetSetClientFromUpdate(Update update, TelegramBotClient clietn)
    //    {

    //        var chat = getChatFromUpdate(update);

    //        if (IsNewClient(update))
    //            using (var db = new context())
    //            {

    //                if (update.Type == UpdateType.MyChatMember) return null;
    //                db.TeleUsers.Add(new Item.TeleClientUser(update, Item.TeleClientUser.type.regulareClient));
    //                db.SaveChanges();


    //            }


    //        var DB = new context();

    //        foreach (var user in DB.TeleUsers.ToList())
    //        {
    //            if (user.TeleChatId == chat.Id) return user;
    //        }



    //        return null;
    //    }






    //    public static bool IsNewClient(Update update)
    //    {
    //        var db = new context();

    //        TeleClient user = null;

    //        Chat chat = getChatFromUpdate(update);

    //        foreach (var teleUser in db.TeleUsers)
    //        {
    //            if (teleUser.TeleChatId == chat.Id) return false;

    //        }

    //        return true;
    //    }


    //    public static Chat getChatFromUpdate(Update update)
    //    {
    //        Chat result = null;

    //        if (update.Type == UpdateType.Message) result = update.Message.Chat;

    //        if (update.Type == UpdateType.CallbackQuery) result = update.CallbackQuery.Message.Chat;



    //        return result;
    //    }


    //    public static Telegram.Bot.Types.Message getMassageFromUpdate(Update update)
    //    {
    //        Telegram.Bot.Types.Message result = null;

    //        if (update.Type == UpdateType.Message) result = update.Message;

    //        if (update.Type == UpdateType.CallbackQuery) result = update.CallbackQuery.Message;



    //        return result;
    //    }


    //    public static async Task SendBtnInChat(TelegramBotClient client, Item.TeleClientUser user, string text_priv, Dictionary<string, string> BtnContent, int btnInl, bool needToDelete, CancellationToken cancellationToken)
    //    {

    //        Message msg = await client.SendTextMessageAsync(user.TeleChatId, text_priv, replyMarkup: initMenuInlineKeyB(BtnContent, btnInl), cancellationToken: cancellationToken);

    //        Item.Massage.SetNewMassage(client, msg, needToDelete, text_priv);

    //    }


    //    public static async Task<bool> SendAlbum(TelegramBotClient client, Item.TeleClientUser user, List<IAlbumInputMedia> mediaAlbum, bool needToDelete, CancellationToken cancellationToken)
    //    {

            

    //      var msgs = await client.SendMediaGroupAsync(user.TeleChatId, media:mediaAlbum,cancellationToken:cancellationToken);

    //        foreach (var msg in msgs)
    //        {
    //            Item.Massage.SetNewMassage(client, msg, needToDelete, "альбом фоток");
    //        }

    //        return true;

    //    }


    //    public static async Task<bool> Sendphoto(TelegramBotClient client, Item.TeleClientUser user, PhotoSize photo, bool needToDelete, CancellationToken cancellationToken)
    //    {



    //        var msg = await client.SendPhotoAsync(user.TeleChatId, photo: new Telegram.Bot.Types.InputFiles.InputOnlineFile(photo.FileId), cancellationToken: cancellationToken);

          
    //        Item.Massage.SetNewMassage(client, msg, needToDelete, "фотока");
            

    //        return true;

    //    }




    //    public static InlineKeyboardMarkup initMenuInlineKeyB(Dictionary<string, string> BtnContent, int btnInl)
    //    {
    //        int i = 1;
    //        List<InlineKeyboardButton[]> btnMain = new List<InlineKeyboardButton[]>();
    //        var lineBtn = new List<InlineKeyboardButton>();

    //        var last = BtnContent.Last();

    //        foreach (var item in BtnContent)
    //        {
    //            var bt = InlineKeyboardButton.WithCallbackData(item.Key, callbackData: item.Value);
                
    //            lineBtn.Add(bt);

    //            if (i == btnInl || last.Equals(item))
    //            {
    //                btnMain.Add(lineBtn.ToArray());
    //                lineBtn = new List<InlineKeyboardButton>();
    //                i = 1;
    //                continue;
    //            }


    //            i++;


    //        }





    //        return new InlineKeyboardMarkup(btnMain);
    //    }




    //    public static async void SendMsg(TelegramBotClient client, Item.TeleClientUser user, string text,  bool needToDelete, CancellationToken cancellationToken)
    //    {

    //        Message msg = await client.SendTextMessageAsync(user.TeleChatId, text,  cancellationToken: cancellationToken);

    //        Item.Massage.SetNewMassage(client, msg, needToDelete, text);

    //    }
















    //    /// <summary>
    //    /// если вернулся 0 то ошибка 
    //    /// </summary>
    //    /// <param name="update"></param>
    //    /// <returns></returns>
    //    public static long GetUserIdFromCallBakc(Update update)
    //    {
    //        long result = 0;

    //        string maincontent = getMassageFromUpdate(update).Text;


    //        if (maincontent.Contains("user:"))
    //        {

    //            foreach (var item in maincontent.Split('|'))
    //            {
    //                if (!item.Contains("user:")) continue;

    //                string content = item.Split(':')[1];

    //                result = Convert.ToInt64(content);

    //            }


    //        }




    //        return result;
    //    }


    //    public static string SetChatIdInCallBack(Item.TeleClientUser user)
    //    {
    //        return $"user:{user.TeleChatId.ToString()}|";


    //    }

    //    //public static string SetQustenId(Item.Question question)
    //    //{

    //    //    if (question == null) return $"qu:{0}|"; 
    //    //    return $"qu:{question.Id.ToString()}|";

    //    //}

    //    public static int GetQustenId(Update update)
    //    {
         

    //        if (update.Type == UpdateType.CallbackQuery)
    //        {
    //            var content = update.CallbackQuery.Data;
              
    //            if (!content.Contains("qu:")) return 0;

    //             foreach (var item in content.Split('|'))
    //            {

                   
    //                if (item.Contains("qu:")) return Convert.ToInt32(item.Split(':')[1]);

                    
    //            }

    //        }
    //        else 
    //        {
    //            var content = Item.TeleClientUser.GetClientByUpdate(update).CurentProcessCode;
                
    //            if (!content.Contains("qu:")) return 0;
              
    //            foreach (var item in content.Split('|'))
    //            {

    //                if (item.Contains("qu:")) return Convert.ToInt32(item.Split(':')[1]);


    //            }

    //        }


            


    //        return 0;
    //    }






    //    //public static string SetRequestId(Item.Request question)
    //    //{

    //    //    if (question == null) return $"re:{0}|";
    //    //    return $"re:{question.id.ToString()}|";

    //    //}

    //    public static int GetRequestId(Update update)
    //    {


    //        if (update.Type == UpdateType.CallbackQuery)
    //        {
    //            var content = update.CallbackQuery.Data;

    //            if (!content.Contains("re:")) return 0;

    //            foreach (var item in content.Split('|'))
    //            {


    //                if (item.Contains("re:")) return Convert.ToInt32(item.Split(':')[1]);


    //            }

    //        }
    //        else
    //        {
    //            var content = Item.TeleClientUser.GetClientByUpdate(update).CurentProcessCode;

    //            if (!content.Contains("re:")) return 0;

    //            foreach (var item in content.Split('|'))
    //            {

    //                if (item.Contains("re:")) return Convert.ToInt32(item.Split(':')[1]);


    //            }

    //        }





    //        return 0;
    //    }



    //}
}
