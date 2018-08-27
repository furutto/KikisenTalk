using System;
using System.Text;
using System.Windows.Forms;
using Advanced_Combat_Tracker;
using KikisenTalk.Util;

namespace KikisenTalk
{
    public class PluginMain : IActPluginV1
    {
        public PluginSettings Settings { get; private set; }
        public ACTTabControl ACTTabControl { get; private set; }
        public DiscordService DiscordService { get; private set; }

        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            Settings = new PluginSettings(this);

            DiscordService = new DiscordService();

            ACTTabControl = new ACTTabControl(this);
            pluginScreenSpace.Text = "Kikisen Talk";
            pluginScreenSpace.Controls.Add(ACTTabControl);

            Settings.Load();
            ClearParamMessages();
            ClearBatchMessage();
            ActGlobals.oFormActMain.OnLogLineRead += OnLogLineRead;

        }

        public void DeInitPlugin()
        {
            ActGlobals.oFormActMain.OnLogLineRead -= OnLogLineRead;
            Settings.Save();
        }

        private void OnLogLineRead(bool isImport, LogLineEventArgs logInfo)
        {
            String logLine = logInfo.logLine;

            // "[07:23:04.000] 00:0038:/m text"
            if(logLine.Length < 25)
            {
                return;
            }

            // 00:0038: から始まるなら /echo のログっぽい
            if (!logLine.Substring(15,9).Equals("00:0038:/"))
                return;

            String command = "";
            String message = "";

            int sepalate = logLine.IndexOf(' ', 24);
            if(sepalate > 0)
            {
                command = logLine.Substring(24, sepalate - 24);
                message = logLine.Substring(sepalate).Trim();
            }
            else
            {
                command = logLine.Substring(24);
            }

            switch (command.ToLower())
            {
                case "m":
                case "message":
                    if (message.IndexOf("{0}") >= 0)
                    {
                        ClearParamMessages();
                        paramMessage = message;
                    }
                    else
                    {
                        sendMessage(message);
                    }
                    break;
                case "p":
                case "param":
                    if (paramMessage != null)
                    {
                        paramMessage = paramMessage.Replace("{" + paramCount + "}", message);
                        ++paramCount;
                        if(paramMessage.IndexOf("{" + paramCount + "}") < 0)
                        {
                            sendMessage(paramMessage);
                            ClearParamMessages();
                        }
                    }
                    break;
                case "s":
                case "start":
                    batchMode = true;
                    break;
                case "e":
                case "end":
                    batchMode = false;
                    sendMessage(buffer.ToString());
                    ClearBatchMessage();
                    break;

                case "c":
                case "clear":
                    ClearBatchMessage();
                    ClearParamMessages();
                    break;
            }
        }

        private StringBuilder buffer = new StringBuilder();
        private String paramMessage;
        private int paramCount;
        private bool batchMode;

        private void ClearParamMessages()
        {
            paramMessage = null;
            paramCount = 0;
        }

        private void ClearBatchMessage()
        {
            buffer.Clear();
            batchMode = false;
        }

        private void sendMessage(String message)
        {
            if (batchMode)
            {
                buffer.Append(message);
            }
            else
            {
                String webhookUrl = ACTTabControl.GetWebhookUrl();
                DiscordService.SendMessageAsync(webhookUrl, message);
            }
        }
    }
}
