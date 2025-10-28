# GameFrameX.Login.FaceBook Facebook登录

> GameFrameX.Login.FaceBook 是 GameFrameX 框架的 Facebook 登录组件。

## 功能

- `初始化`
- `登录`
- `登出`

## 使用方法

1. **挂载组件**
   在 `GameEntry` 游戏入口对象上挂载 `FaceBookLoginComponent` 组件。

2. **设置参数**
   在 `FaceBookLoginComponent` 组件上设置 `AppId` 和 `AppKey`。

3. **调用方法**
   ```csharp
   // 获取Facebook登录组件
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

## Android 配置

### 1. 添加字符串资源

在项目 `res/values/strings.xml` 文件中添加 `facebook_app_id` 字符串，值为 Facebook 后台生成的 `AppId`。

```xml
<?xml version="1.0" encoding="utf-8"?>
<resources>
    <!--  这里填写后台生成的ID-->
    <string name="facebook_app_id">YOUR_APP_ID</string>
</resources>
```

### 2. 配置 AndroidManifest.xml

在 `AndroidManifest.xml` 文件的 `application` 节点下添加 `meta-data`。

```xml
<meta-data
    android:name="com.facebook.sdk.ApplicationId"
    android:value="@string/facebook_app_id"/>
```

在 `AndroidManifest.xml` 文件的 `manifest` 节点下添加网络权限。
```xml
<uses-permission android:name="android.permission.INTERNET"/>
```

## iOS 配置

### 1. 更新 Info.plist

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
