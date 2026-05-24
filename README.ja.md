<div align="center">
  <img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />
</div>

# Game Frame X Facebook ログイン

[![GitHub release](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.login.facebook?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.login.facebook/releases)
[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.login.facebook?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.login.facebook/blob/main/LICENSE.md)
[![Documentation](https://img.shields.io/badge/Documentation-Online-blue?style=flat-square)](https://gameframex.doc.alianblank.com)

**インディゲーム開発者向けオールインワンソリューション · インディ開発者の夢を支援**

[ドキュメント](https://gameframex.doc.alianblank.com) · [クイックスタート](#クイックスタート) · [QQグループ](https://qm.qq.com/q/5s5e1e6e6e)

**言語**: [English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | **日本語** | [한국어](README.ko.md)

---

## プロジェクト概要

Game Frame X Facebook ログインは、GameFrameX フレームワークの Facebook ログインコンポーネントで、初期化、ログイン、ログアウト機能を提供します。

## クイックスタート

### インストール

以下のいずれかの方法をお選びください：

1. プロジェクトの `manifest.json` の `dependencies` セクションに以下を追加：
   ```json
   {"com.gameframex.unity.login.facebook": "https://github.com/AlianBlank/com.gameframex.unity.login.facebook.git"}
   ```

2. Unity の Package Manager で `Git URL` を使用：
   ```
   https://github.com/AlianBlank/com.gameframex.unity.login.facebook.git
   ```

3. リポジトリをダウンロードして Unity プロジェクトの `Packages` ディレクトリに配置。自動的にロードされます。

## 使用例

1. `GameEntry` ゲームオブジェクトに `FaceBookLoginComponent` コンポーネントをアタッチ。
2. `FaceBookLoginComponent` コンポーネントに `AppId` と `AppKey` を設定。
3. メソッドを呼び出し：

```csharp
// Facebook ログインコンポーネントの取得
var faceBookLoginComponent = GameEntry.GetComponent<FaceBookLoginComponent>();

// 初期化
faceBookLoginComponent.Init();

// ログイン
faceBookLoginComponent.Login(
    (faceBookLoginSuccess) =>
    {
        Debug.Log($"ログイン成功! {JsonUtility.ToJson(faceBookLoginSuccess)}");
    },
    (code) =>
    {
        Debug.LogError($"ログイン失敗! {code}");
    });

// ログアウト
faceBookLoginComponent.LogOut();
```

## プラットフォーム設定

### Android

1. `res/values/strings.xml` に `facebook_app_id` 文字列リソースを追加：
   ```xml
   <?xml version="1.0" encoding="utf-8"?>
   <resources>
       <string name="facebook_app_id">YOUR_APP_ID</string>
   </resources>
   ```

2. `AndroidManifest.xml` の `application` ノードに `meta-data` を追加：
   ```xml
   <meta-data
       android:name="com.facebook.sdk.ApplicationId"
       android:value="@string/facebook_app_id"/>
   ```

3. `manifest` ノードにインターネット権限を追加：
   ```xml
   <uses-permission android:name="android.permission.INTERNET"/>
   ```

### iOS

`Info.plist` に以下のキーを追加：

```xml
<key>CFBundleURLTypes</key>
<array>
  <dict>
    <key>CFBundleURLSchemes</key>
    <array>
      <string>fbYOUR_APP_ID</string>
    </array>
  </dict>
</array>
<key>FacebookAppID</key>
<string>YOUR_APP_ID</string>
<key>FacebookDisplayName</key>
<string>YOUR_APP_NAME</string>
```

## 依存関係

- `com.gameframex.unity`: GameFrameX コアフレームワーク
- `com.gameframex.unity.sharesdk`: ShareSDK 統合

## ドキュメントとリソース

- ドキュメント: https://gameframex.doc.alianblank.com
- リポジトリ: https://github.com/GameFrameX/com.gameframex.unity.login.facebook
- Issues: https://github.com/GameFrameX/com.gameframex.unity.login.facebook/issues

## ライセンス

このプロジェクトは MIT ライセンスの下で公開されています。詳細は [LICENSE](LICENSE.md) ファイルを参照してください。
