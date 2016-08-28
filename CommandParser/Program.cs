using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.InputMessageContents;
using Telegram.Bot.Types.ReplyMarkups;

namespace CommandParser
{
	class MainClass
	{
		private static String ACCESS_TOKEN = "232168269:AAGf8WuWT2lDSmHodxfnnAOieQQ6mQqH-LA";
		private static readonly TelegramBotClient Bot = new TelegramBotClient(ACCESS_TOKEN);
		private static Controller controller = new ControllerImpl ();

		static void Main(string[] args)
		{
			Bot.OnMessage += BotOnMessageReceived;
			Bot.OnMessageEdited += BotOnMessageReceived;
			Bot.OnReceiveError += BotOnReceiveError;

			var me = Bot.GetMeAsync().Result;

			Console.Title = me.Username;

			Bot.StartReceiving();
			Console.ReadLine();
			Bot.StopReceiving();
		}

		private static void BotOnReceiveError(object sender, ReceiveErrorEventArgs receiveErrorEventArgs)
		{
			Debugger.Break();
		}

		private static async void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
		{
			var message = messageEventArgs.Message;

			if (message == null || message.Type != MessageType.TextMessage) return;

			performCommand (message, controller);
		}

		private static async void performCommand(Message message, Controller controller) {
			String command = message.Text.ToLower ();
			int openBracket = command.IndexOf ('[');
			Boolean forMe = true;
			if (openBracket != -1) {
				if (openBracket == 0) {
					int closeBracket = command.IndexOf (']');
					if (closeBracket <= openBracket + 1) {
						Bot.SendTextMessageAsync (message.Chat.Id, "wrong command");
					} else {
						Console.WriteLine ("Found aliases");
						String aliasesString = command.Substring (openBracket + 1, closeBracket - openBracket - 1);
						command = command.Substring (closeBracket + 2);
						forMe = false;
						String[] aliases = aliasesString.Split (' ');
						String myAlias = controller.getAlias ();
						foreach (String alias in aliases) {
							if (alias.Equals (myAlias)) {
								forMe = true;
								Console.WriteLine ("This message is for us");
							}
						}
					}
				} else {
					Bot.SendTextMessageAsync (message.Chat.Id, "wrong command");
				}
			}

			if (forMe) {
				var args = command.Split (' ');
				if (args [0].StartsWith ("playnext")) {
					if (args.Length == 1) {
						Bot.SendTextMessageAsync (message.Chat.Id, "playNext done: " + controller.onPlayNext ());
					} else {
						Bot.SendTextMessageAsync (message.Chat.Id, "wrong command");
					}
				} else if (args [0].StartsWith ("play")) {
					if (args.Length == 1) {
						Bot.SendTextMessageAsync (message.Chat.Id, "play done: " + controller.onPlay ());
					} else {
						Bot.SendTextMessageAsync (message.Chat.Id, "wrong command");
					}
				} else if (args [0].StartsWith ("freeze")) {
					if (args.Length == 2) {
						try {
							int ms = Int32.Parse (args [1]);
							Bot.SendTextMessageAsync (message.Chat.Id, "freeze done: " + controller.onFreeze (ms));
						} catch (FormatException e) {
							Bot.SendTextMessageAsync (message.Chat.Id, "wrong command");
						}
					} else {
						Bot.SendTextMessageAsync (message.Chat.Id, "wrong command");
					}
				} else if (args [0].StartsWith ("unfreeze")) {
					if (args.Length == 1) {
						Bot.SendTextMessageAsync (message.Chat.Id, "unFreeze: " + controller.onUnfreeze ());
					} else {
						Bot.SendTextMessageAsync (message.Chat.Id, "wrong command");
					}
				} else if (args [0].StartsWith ("getmicrophone")) {
					Bot.SendTextMessageAsync (message.Chat.Id, "getMicriphone is not implemented yet"); 
				} else if (args [0].StartsWith ("outtext")) {
					Bot.SendTextMessageAsync (message.Chat.Id, "outText is not implemented yet");
				} else if (args [0].StartsWith ("outimage")) {
					Bot.SendTextMessageAsync (message.Chat.Id, "outImage is not implemented yet");
				} else if (args [0].StartsWith ("setcameraxyz")) {
					if (args.Length == 4) {
						try {
							int x = Int32.Parse (args [1]);
							int y = Int32.Parse (args [2]);
							int z = Int32.Parse (args [3]);
							Bot.SendTextMessageAsync (message.Chat.Id, "onSetCameraXYZ done: " + controller.onSetCameraXYZ (x, y, z));
						} catch (FormatException e) {
							Bot.SendTextMessageAsync (message.Chat.Id, "wrong command");
						}
					} else {
						Bot.SendTextMessageAsync (message.Chat.Id, "wrong command");
					}
				} else if (args [0].StartsWith ("writetext")) {
					if (args.Length == 4) {
						try {
							String text = args [1];
							int x = Int32.Parse (args [2]);
							int y = Int32.Parse (args [3]);
							Bot.SendTextMessageAsync (message.Chat.Id, "onWriteText done: " + controller.onWriteText (text, x, y));
						} catch (FormatException e) {
							Bot.SendTextMessageAsync (message.Chat.Id, "wrong command");
						}
					} else {
						Bot.SendTextMessageAsync (message.Chat.Id, "wrong command");
					}
				} else if (args [0].StartsWith ("ongoto")) {
					if (args.Length == 2) {
						try {
							int step = Int32.Parse (args [1]);
							Bot.SendTextMessageAsync (message.Chat.Id, "onGoTo done: " + controller.onGoTo (step));
						} catch (FormatException e) {
							Bot.SendTextMessageAsync (message.Chat.Id, "wrong command");
						}
					} else {
						Bot.SendTextMessageAsync (message.Chat.Id, "wrong command");
					}
				} else if (args [0].StartsWith ("setalias")) {
					if (args.Length == 2) {
						String alias = args [1];
						controller.setAlias (alias);
						Bot.SendTextMessageAsync (message.Chat.Id, "SetAlias");
					} else {
						Bot.SendTextMessageAsync (message.Chat.Id, "wrong command");
					}
				} else if (args [0].StartsWith ("getalias")) {
					if (args.Length == 1) {
						Bot.SendTextMessageAsync (message.Chat.Id, "GetAlias: alias=" + controller.getAlias ());
					} else {
						Bot.SendTextMessageAsync (message.Chat.Id, "wrong command");
					}
				} else {
					Bot.SendTextMessageAsync (message.Chat.Id, "unknown command");
				}
			} else {
				Console.WriteLine ("This message is not for us");
			}
		}
	}

}
