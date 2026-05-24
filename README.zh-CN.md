<div align="center">
  <img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />
</div>

# Game Frame X Facebook 登录

[![GitHub release](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.login.facebook?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.login.facebook/releases)
[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.login.facebook?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.login.facebook/blob/main/LICENSE.md)
[![Documentation](https://img.shields.io/badge/Documentation-Online-blue?style=flat-square)](https://gameframex.doc.alianblank.com)

**独立游戏前后端一体化解决方案 · 独立游戏开发者的圆梦大使**

[文档](https://gameframex.doc.alianblank.com) · [快速开始](#快速开始) · [QQ群](https://qm.qq.com/q/5s5e1e6e6e)

**语言**: [English](README.md) | **简体中文** | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

---

## 项目简介

Game Frame X Facebook 登录是 GameFrameX 框架的 Facebook 登录组件，提供初始化、登录和登出功能。

## 快速开始

### 安装

任选以下方式之一：

1. 直接在 `manifest.json` 的文件中的 `dependencies` 节点下添加以下内容：
   ```json
   {"com.gameframex.unity.login.facebook": "https://github.com/AlianBlank/com.gameframex.unity.login.facebook.git"}
   ```

2. 在 Unity 的 `Packages Manager` 中使用 `Git URL` 的方式添加库，地址为：
   ```
   https://github.com/AlianBlank/com.gameframex.unity.login.facebook.git
   ```

3. 直接下载仓库放置到 Unity 项目的 `Packages` 目录下，会自动加载识别。

## 使用示例

1. 在 `GameEntry` 游戏入口对象上挂载 `FaceBookLoginComponent` 组件。
2. 在 `FaceBookLoginComponent` 组件上设置 `AppId` 和 `AppKey`。
3. 调用方法：

```csharp
// 获取 Facebook 登录组件
var faceBookLoginComponent = GameEntry.GetComponent<FaceBookLoginComponent>();

// 初始化
faceBookLoginComponent.Init();

// 登录
faceBookLoginComponent.Login(
    (faceBookLoginSuccess) =>
    {
        Debug.Log($"登录成功! {JsonUtility.ToJson(faceBookLoginSuccess)}");
    },
    (code) =>
    {
        Debug.LogError($"登录失败! {code}");
    });

// 登出
faceBookLoginComponent.LogOut();
```

## 平台配置

### Android

1. 在项目 `res/values/strings.xml` 文件中添加 `facebook_app_id` 字符串资源：
   ```xml
   <?xml version="1.0" encoding="utf-8"?>
   <resources>
       <string name="facebook_app_id">YOUR_APP_ID</string>
   </resources>
   ```

2. 在 `AndroidManifest.xml` 文件的 `application` 节点下添加 `meta-data`：
   ```xml
   <meta-data
       android:name="com.facebook.sdk.ApplicationId"
       android:value="@string/facebook_app_id"/>
   ```

3. 在 `manifest` 节点下添加网络权限：
   ```xml
   <uses-permission android:name="android.permission.INTERNET"/>
   ```

### iOS

在 `Info.plist` 文件中添加以下键值对：

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

## 依赖项

- `com.gameframex.unity`: GameFrameX 核心框架
- `com.gameframex.unity.sharesdk`: ShareSDK 集成

## 文档与资源

- 文档地址: https://gameframex.doc.alianblank.com
- 仓库地址: https://github.com/GameFrameX/com.gameframex.unity.login.facebook
- 问题反馈: https://github.com/GameFrameX/com.gameframex.unity.login.facebook/issues

## 开源协议

本项目遵循 MIT 许可证。详细信息请查看 [LICENSE](LICENSE.md) 文件。
