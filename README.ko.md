<div align="center">
  <img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />
</div>

# Game Frame X Facebook 로그인

[![GitHub release](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.login.facebook?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.login.facebook/releases)
[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.login.facebook?style=flat-square)](https://github.com/GameFrameX/com.gameframex.unity.login.facebook/blob/main/LICENSE.md)
[![Documentation](https://img.shields.io/badge/Documentation-Online-blue?style=flat-square)](https://gameframex.doc.alianblank.com)

**인디 게임 개발자를 위한 올인원 솔루션 · 인디 개발자의 꿈을 실현**

[문서](https://gameframex.doc.alianblank.com) · [빠른 시작](#빠른-시작) · [QQ 그룹](https://qm.qq.com/q/5s5e1e6e6e)

**언어**: [English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | **한국어**

---

## 프로젝트 개요

Game Frame X Facebook 로그인은 GameFrameX 프레임워크의 Facebook 로그인 컴포넌트로, 초기화, 로그인 및 로그아웃 기능을 제공합니다.

## 빠른 시작

### 설치

다음 방법 중 하나를 선택하세요:

1. 프로젝트의 `manifest.json` 파일의 `dependencies` 섹션에 다음을 추가:
   ```json
   {"com.gameframex.unity.login.facebook": "https://github.com/AlianBlank/com.gameframex.unity.login.facebook.git"}
   ```

2. Unity의 Package Manager에서 `Git URL` 사용:
   ```
   https://github.com/AlianBlank/com.gameframex.unity.login.facebook.git
   ```

3. 저장소를 다운로드하여 Unity 프로젝트의 `Packages` 디렉토리에 배치. 자동으로 로드됩니다.

## 사용 예시

1. `GameEntry` 게임 오브젝트에 `FaceBookLoginComponent` 컴포넌트를 연결합니다.
2. `FaceBookLoginComponent` 컴포넌트에 `AppId` 및 `AppKey`를 설정합니다.
3. 메서드를 호출합니다:

```csharp
// Facebook 로그인 컴포넌트 가져오기
var faceBookLoginComponent = GameEntry.GetComponent<FaceBookLoginComponent>();

// 초기화
faceBookLoginComponent.Init();

// 로그인
faceBookLoginComponent.Login(
    (faceBookLoginSuccess) =>
    {
        Debug.Log($"로그인 성공! {JsonUtility.ToJson(faceBookLoginSuccess)}");
    },
    (code) =>
    {
        Debug.LogError($"로그인 실패! {code}");
    });

// 로그아웃
faceBookLoginComponent.LogOut();
```

## 플랫폼 설정

### Android

1. `res/values/strings.xml`에 `facebook_app_id` 문자열 리소스 추가:
   ```xml
   <?xml version="1.0" encoding="utf-8"?>
   <resources>
       <string name="facebook_app_id">YOUR_APP_ID</string>
   </resources>
   ```

2. `AndroidManifest.xml`의 `application` 노드에 `meta-data` 추가:
   ```xml
   <meta-data
       android:name="com.facebook.sdk.ApplicationId"
       android:value="@string/facebook_app_id"/>
   ```

3. `manifest` 노드에 인터넷 권한 추가:
   ```xml
   <uses-permission android:name="android.permission.INTERNET"/>
   ```

### iOS

`Info.plist`에 다음 키를 추가:

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

## 의존성

- `com.gameframex.unity`: GameFrameX 핵심 프레임워크
- `com.gameframex.unity.sharesdk`: ShareSDK 통합

## 문서 및 자료

- 문서: https://gameframex.doc.alianblank.com
- 저장소: https://github.com/GameFrameX/com.gameframex.unity.login.facebook
- Issues: https://github.com/GameFrameX/com.gameframex.unity.login.facebook/issues

## 라이선스

이 프로젝트는 MIT 라이선스에 따라 배포됩니다. 자세한 내용은 [LICENSE](LICENSE.md) 파일을 참조하세요.
