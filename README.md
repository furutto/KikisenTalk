# KikisenTalk
FFXIVのマクロに登録したメッセージをDiscordに送信する機能です。

例えば、聞き専が戦闘中にマクロを実行することで、Discordの音声読み上げを介してパーティーメンバーに伝えることができます。

他にも、マクロにFFXIVの /wait コマンドを挟むことで、パーティーメンバーでちょっとしたタイムラインを共有することにも使えます。

## ダウンロード
[リリースページ](https://github.com/furutto/KikisenTalk/releases/latest)からダウンロード
## インストール
1. ダウンロードファイルを任意のディレクトリに展開 
1. KikisenTalk.dll を ACT からプラグイン追加
#### 動作環境
* .NET Framework 4.7.1 以降
## Discord側の事前準備
1. Discord のメッセージ読み上げを有効にします

![Discord Speech1](https://github.com/furutto/KikisenTalk/blob/master/resources/image/readme_enable_speech1.png)

      ユーザー設定を開き、[通知]→[テキスト読み上げによる通知]の設定を「すべてのチャンネル」または「現在の選択したチャンネルのみ」を選択します。

2. サーバーにWEBHOOKを追加します

![Discord Webhook1](https://github.com/furutto/KikisenTalk/blob/master/resources/image/readme_add_webhook1.png)

      サーバーを選択して右クリック、[サーバー設定]→[Webhooks]を開きます

![Discord Webhook2](https://github.com/furutto/KikisenTalk/blob/master/resources/image/readme_add_webhook2.png)

      [Webhooks]→[Webhookを作成]をクリックします

![Discord Webhook3](https://github.com/furutto/KikisenTalk/blob/master/resources/image/readme_add_webhook3.png)

      [WEBHOOK URL]はACT側で設定する必要があるので、Copyボタンを押して設定を憶えておいてください


## 使用方法

1. ACT側でメッセージ送信先の WEBHOOK URL を設定します

![ACT Settings](https://github.com/furutto/KikisenTalk/blob/master/resources/image/readme_settings.png)

      [Plugins]→[Kikisen Talk]タブの[Webhook url]テキストボックスに、Discordで追加した[WEBHOOK URL]をセットします

2. FFXIV側でマクロにメッセージを登録して実行します。

![FFXIV Macro](https://github.com/furutto/KikisenTalk/blob/master/resources/image/readme_add_macro.png)

マクロに登録する内容を以下に説明します。

* テキストを送信するコマンド(/message または /m)
```
/echo /message 叱咤ください
または
/e /m 叱咤ください
```

先頭にFFXIVのコマンド /echo(または /e) を入力し、半角スペースの後に /message(または /m)のコマンドを入力し、更に半角スペースの後ろに送信するテキストを入力します。


* テキスト置き換えコマンド(/param または /p)

```
/e /m {0}はAに、{1}はBに移動してください
/e /p 白ちゃん
/e /p 黒ちゃん
```
Discordには「白ちゃんはAに、黒ちゃんはBに移動してください」と送信されます。

/mコマンドのテキスト内に波括弧\{}と連番(開始は0から)がセットされている場合、後から渡されたパラメータのテキストに置き換えてから送信されます。

/mコマンドと/pコマンドを別々のマクロに記述することで、戦闘中に流すマクロの順番によって動的にテキストを組み立てることができます。

* 一括送信コマンド(/start または /s ～ /end または /e)
```
/e /start
/e /m 今日の
/e /m 天気は
/e /m 晴れ
/e /end
```
Discordには「今日の天気は晴れ」と送信されます。

/start(または /s) と /end(または /e) 間に記述されたメッセージコマンドは連結されて送られます。

テキストが長くて１つのマクロに記述出来ない場合にマクロに分割して記述しても、テキストを途切れることなくDiscord側で読み上げてくれます。
(Discordには文字数制限があるので、あまり長い文章の場合には分割して送ってください)

* 送信破棄コマンド(/clear または /c)
```
/e /clear
```
一括送信コマンドで/endが記述されてなかったり、テキスト置き換えコマンドで /p が渡していなかったりで、まだサーバーにテキストが送られていない段階で実行すると、送信前のテキストを破棄します。 

戦闘時にテキストを送信する前にワイプして、送る必要がなくなったときに使えます。

・タイムライン的な使い方（おまけ）
```
/e /m 集合してください
/wait 10
/e /m 散開してください
```
「集合してください」と送信して１０秒後に、「散開してください」と送信されます。

## ライセンス
[三条項BSDライセンス](LICENSE)  
## 連絡先
twitter:  [@furutto_dev](https://twitter.com/furutto_dev)  