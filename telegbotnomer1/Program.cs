using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace telegbotnomer1
{
    class Program
    {
        private static string token { get; set; } = "2009770363:AAGWsaXE8Tb2C9HRDUMhcFNv2F2QPHilWqA";
        private static TelegramBotClient client;
        static void Main(string[] args)
        {
            client = new TelegramBotClient(token);
            client.StartReceiving();
            client.OnMessage += onMessageHandler;
            Console.ReadLine();
            client.StopReceiving();

        }

        private static async void onMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            if (msg.Text != null)
            {
                Console.WriteLine($"text: {msg.Text}");
                switch (msg.Text)
                {
                    case "Sticker":
                        var stic = await client.SendStickerAsync(
                            chatId: msg.Chat.Id,
                            sticker: "https://tlgrm.ru/_/stickers/b50/063/b5006369-8faa-44d7-9f02-1ca97d82cd49/192/29.webp",
                            replyToMessageId: msg.MessageId,
                            replyMarkup: getButtons());
                            break;
                    case "Photo":
                        var pic = await client.SendPhotoAsync(
                            chatId: msg.Chat.Id,
                            photo: "https://chto-eto-takoe.ru/uryaimg/63eec9855f56438fa75dfc3d594b13e3.jpg",
                            replyMarkup: getButtons());
                        break;

                    default:
                        await client.SendTextMessageAsync(msg.Chat.Id, "choose command: ", replyMarkup: getButtons());
                        break;
                }
            }
        }

        private static IReplyMarkup getButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Sticker"}, new KeyboardButton { Text = "Photo"} },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Weather"}, new KeyboardButton { Text = "1"} }
                }
            };
        }
    }
}
