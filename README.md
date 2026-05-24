<div align="center">
  <img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />
</div>

# Game Frame X Facebook Login

[![GitHub release](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.login.facebook?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.login.facebook/releases)
[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.login.facebook?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.login.facebook/blob/main/LICENSE.md)
[![Documentation](https://img.shields.io/badge/Documentation-Online-blue?style=flat-square)](https://gameframex.doc.alianblank.com)

**All-in-One Solution for Indie Game Development · Empowering Indie Developers' Dreams**

[Documentation](https://gameframex.doc.alianblank.com) · [Quick Start](#quick-start) · [QQ Group](https://qm.qq.com/q/5s5e1e6e6e)

**Language**: **English** | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

---

## Project Overview

Game Frame X Facebook Login is a Facebook login component for the GameFrameX framework, providing initialization, login, and logout capabilities.

## Quick Start

### Installation

Choose one of the following methods:

1. Add the following to the `dependencies` section in your project's `manifest.json`:
   ```json
   {"com.gameframex.unity.login.facebook": "https://github.com/AlianBlank/com.gameframex.unity.login.facebook.git"}
   ```

2. Use `Git URL` in Unity's Package Manager:
   ```
   https://github.com/AlianBlank/com.gameframex.unity.login.facebook.git
   ```

3. Download the repository and place it in your Unity project's `Packages` directory. It will be loaded automatically.

## Usage Examples

1. Attach the `FaceBookLoginComponent` component to the `GameEntry` game object.
2. Set the `AppId` and `AppKey` on the `FaceBookLoginComponent` component.
3. Call the methods:

```csharp
// Get Facebook login component
var faceBookLoginComponent = GameEntry.GetComponent<FaceBookLoginComponent>();

// Initialize
faceBookLoginComponent.Init();

// Login
faceBookLoginComponent.Login(
    (faceBookLoginSuccess) =>
    {
        Debug.Log($"Login successful! {JsonUtility.ToJson(faceBookLoginSuccess)}");
    },
    (code) =>
    {
        Debug.LogError($"Login failed! {code}");
    });

// Logout
faceBookLoginComponent.LogOut();
```

## Platform Configuration

### Android

1. Add the `facebook_app_id` string resource in `res/values/strings.xml`:
   ```xml
   <?xml version="1.0" encoding="utf-8"?>
   <resources>
       <string name="facebook_app_id">YOUR_APP_ID</string>
   </resources>
   ```

2. Add `meta-data` in the `application` node of `AndroidManifest.xml`:
   ```xml
   <meta-data
       android:name="com.facebook.sdk.ApplicationId"
       android:value="@string/facebook_app_id"/>
   ```

3. Add internet permission in the `manifest` node:
   ```xml
   <uses-permission android:name="android.permission.INTERNET"/>
   ```

### iOS

Update `Info.plist` with the following keys:

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

## Dependencies

- `com.gameframex.unity`: GameFrameX core framework
- `com.gameframex.unity.sharesdk`: ShareSDK integration

## Documentation & Resources

- Documentation: https://gameframex.doc.alianblank.com
- Repository: https://github.com/GameFrameX/com.gameframex.unity.login.facebook
- Issues: https://github.com/GameFrameX/com.gameframex.unity.login.facebook/issues

## License

This project is licensed under the MIT License. See [LICENSE](LICENSE.md) for details.
