namespace KikisenTalk
{
    partial class ACTTabControl
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupDiscordConfig = new System.Windows.Forms.GroupBox();
            this.labelWebhookUrl = new System.Windows.Forms.Label();
            this.textUrl = new System.Windows.Forms.TextBox();
            this.buttonSendTest = new System.Windows.Forms.Button();
            this.groupDiscordConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupDiscordConfig
            // 
            this.groupDiscordConfig.Controls.Add(this.labelWebhookUrl);
            this.groupDiscordConfig.Controls.Add(this.textUrl);
            this.groupDiscordConfig.Location = new System.Drawing.Point(18, 15);
            this.groupDiscordConfig.Name = "groupDiscordConfig";
            this.groupDiscordConfig.Size = new System.Drawing.Size(490, 80);
            this.groupDiscordConfig.TabIndex = 3;
            this.groupDiscordConfig.TabStop = false;
            this.groupDiscordConfig.Text = "Discord";
            // 
            // labelWebhookUrl
            // 
            this.labelWebhookUrl.AutoSize = true;
            this.labelWebhookUrl.Location = new System.Drawing.Point(17, 33);
            this.labelWebhookUrl.Name = "labelWebhookUrl";
            this.labelWebhookUrl.Size = new System.Drawing.Size(69, 12);
            this.labelWebhookUrl.TabIndex = 0;
            this.labelWebhookUrl.Text = "Webhook url:";
            // 
            // textUrl
            // 
            this.textUrl.Location = new System.Drawing.Point(101, 30);
            this.textUrl.Name = "textUrl";
            this.textUrl.Size = new System.Drawing.Size(361, 19);
            this.textUrl.TabIndex = 0;
            // 
            // buttonSendTest
            // 
            this.buttonSendTest.Location = new System.Drawing.Point(421, 101);
            this.buttonSendTest.Name = "buttonSendTest";
            this.buttonSendTest.Size = new System.Drawing.Size(87, 23);
            this.buttonSendTest.TabIndex = 2;
            this.buttonSendTest.Text = "送信テスト";
            this.buttonSendTest.UseVisualStyleBackColor = true;
            this.buttonSendTest.Click += new System.EventHandler(this.buttonSendTest_Click);
            // 
            // ACTTabControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonSendTest);
            this.Controls.Add(this.groupDiscordConfig);
            this.Name = "ACTTabControl";
            this.Size = new System.Drawing.Size(526, 150);
            this.groupDiscordConfig.ResumeLayout(false);
            this.groupDiscordConfig.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupDiscordConfig;
        private System.Windows.Forms.Button buttonSendTest;
        private System.Windows.Forms.Label labelWebhookUrl;
        private System.Windows.Forms.TextBox textUrl;
    }
}
