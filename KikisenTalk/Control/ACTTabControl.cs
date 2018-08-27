using System;
using System.Windows.Forms;

namespace KikisenTalk
{
    public partial class ACTTabControl : UserControl
    {
        private PluginMain plugin;

        public ACTTabControl(PluginMain pluginMain)
        {
            InitializeComponent();

            plugin = pluginMain;
            var settings = plugin.Settings;
            settings.AddControlSetting("WebhookUrl", textUrl);
        }

        private void buttonSendTest_Click(object sender, EventArgs e)
        {
            bool result = false;

            try
            {
                result = plugin.DiscordService.SendMessageSync(textUrl.Text, "Hello!");
            }catch(Exception ex)
            {}

            MessageBox.Show(result ? "succeeded" : "failed", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public String GetWebhookUrl()
        {
            return textUrl.Text;
        }

    }
}
