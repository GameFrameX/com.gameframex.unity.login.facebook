<div align="center">
  <img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />
</div>

# Game Frame X Facebook 登錄

[![GitHub release](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.login.facebook?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.login.facebook/releases)
[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.login.facebook?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.login.facebook/blob/main/LICENSE.md)
[![Documentation](https://img.shields.io/badge/Documentation-Online-blue?style=flat-square)](https://gameframex.doc.alianblank.com)

**獨立遊戲前後端一體化解決方案 · 獨立遊戲開發者的圓夢大使**

[文檔](https://gameframex.doc.alianblank.com) · [快速開始](#快速開始) · [QQ群](https://qm.qq.com/q/5s5e1e6e6e)

**語言**: [English](README.md) | [简体中文](README.zh-CN.md) | **繁體中文** | [日本語](README.ja.md) | [한국어](README.ko.md)

---

## 項目簡介

Game Frame X Facebook 登錄是 GameFrameX 框架的 Facebook 登錄組件，提供初始化、登錄和登出功能。

## 快速開始

### 安裝

任選以下方式之一：

1. 直接在 `manifest.json` 的文件中的 `dependencies` 節點下添加以下內容：
   ```json
   {"com.gameframex.unity.login.facebook": "https://github.com/AlianBlank/com.gameframex.unity.login.facebook.git"}
   ```

2. 在 Unity 的 `Packages Manager` 中使用 `Git URL` 的方式添加庫，地址為：
   ```
   https://github.com/AlianBlank/com.gameframex.unity.login.facebook.git
   ```

3. 直接下載倉庫放置到 Unity 項目的 `Packages` 目錄下，會自動加載識別。

## 使用範例

1. 在 `GameEntry` 遊戲入口對象上掛載 `FaceBookLoginComponent` 組件。
2. 在 `FaceBookLoginComponent` 組件上設置 `AppId` 和 `AppKey`。
3. 調用方法：

```csharp
// 獲取 Facebook 登錄組件
var faceBookLoginComponent = GameEntry.GetComponent<FaceBookLoginComponent>();

// 初始化
faceBookLoginComponent.Init();

// 登錄
faceBookLoginComponent.Login(
    (faceBookLoginSuccess) =>
    {
        Debug.Log($"登錄成功! {JsonUtility.ToJson(faceBookLoginSuccess)}");
    },
    (code) =>
    {
        Debug.LogError($"登錄失敗! {code}");
    });

// 登出
faceBookLoginComponent.LogOut();
```

## 平台配置

### Android

1. 在項目 `res/values/strings.xml` 文件中添加 `facebook_app_id` 字符串資源：
   ```xml
   <?xml version="1.0" encoding="utf-8"?>
   <resources>
       <string name="facebook_app_id">YOUR_APP_ID</string>
   </resources>
   ```

2. 在 `AndroidManifest.xml` 文件的 `application` 節點下添加 `meta-data`：
   ```xml
   <meta-data
       android:name="com.facebook.sdk.ApplicationId"
       android:value="@string/facebook_app_id"/>
   ```

3. 在 `manifest` 節點下添加網絡權限：
   ```xml
   <uses-permission android:name="android.permission.INTERNET"/>
   ```

### iOS

在 `Info.plist` 文件中添加以下鍵值對：

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

## 依賴項

- `com.gameframex.unity`: GameFrameX 核心框架
- `com.gameframex.unity.sharesdk`: ShareSDK 集成

## 文檔與資源

- 文檔地址: https://gameframex.doc.alianblank.com
- 倉庫地址: https://github.com/GameFrameX/com.gameframex.unity.login.facebook
- 問題反饋: https://github.com/GameFrameX/com.gameframex.unity.login.facebook/issues

## 開源協議

本項目遵循 MIT 許可證。詳細信息請查看 [LICENSE](LICENSE.md) 文件。
