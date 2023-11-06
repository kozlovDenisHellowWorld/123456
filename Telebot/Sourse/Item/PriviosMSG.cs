using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Telebot.Sourse.Item.IItem;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Telebot.Sourse.Item
{
    public class PriviosMSG : IItemDB<PriviosMSG>
    {
        [Key]
        public int MyId { get ; set ; }
        public string? MyDescription { get ; set ; }
        public string? MyName { get ; set ; }
        public DateTime? dateTimeCreation { get ; set ; }
        public long? BotClientId { get ; set ; }

        public bool? IsDelite { set; get; }
        public int? MessageId { set; get; }

        public long? UupdateId { set; get; }

        public bool NedTodelite { set; get; }


        public int ChatId { set; get; }
        [ForeignKey("ChatId")]
        public virtual MyChat? Chat { set; get; }



    }
}
