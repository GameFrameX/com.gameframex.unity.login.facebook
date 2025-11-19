// ==========================================================================================
//  GameFrameX 组织及其衍生项目的版权、商标、专利及其他相关权利
//  GameFrameX organization and its derivative projects' copyrights, trademarks, patents, and related rights
//  均受中华人民共和国及相关国际法律法规保护。
//  are protected by the laws of the People's Republic of China and relevant international regulations.
// 
//  使用本项目须严格遵守相应法律法规及开源许可证之规定。
//  Usage of this project must strictly comply with applicable laws, regulations, and open-source licenses.
// 
//  本项目采用 MIT 许可证与 Apache License 2.0 双许可证分发，
//  This project is dual-licensed under the MIT License and Apache License 2.0,
//  完整许可证文本请参见源代码根目录下的 LICENSE 文件。
//  please refer to the LICENSE file in the root directory of the source code for the full license text.
// 
//  禁止利用本项目实施任何危害国家安全、破坏社会秩序、
//  It is prohibited to use this project to engage in any activities that endanger national security, disrupt social order,
//  侵犯他人合法权益等法律法规所禁止的行为！
//  or infringe upon the legitimate rights and interests of others, as prohibited by laws and regulations!
//  因基于本项目二次开发所产生的一切法律纠纷与责任，
//  Any legal disputes and liabilities arising from secondary development based on this project
//  本项目组织与贡献者概不承担。
//  shall be borne solely by the developer; the project organization and contributors assume no responsibility.
// 
//  GitHub 仓库：https://github.com/GameFrameX
//  GitHub Repository: https://github.com/GameFrameX
//  Gitee  仓库：https://gitee.com/GameFrameX
//  Gitee Repository:  https://gitee.com/GameFrameX
//  官方文档：https://gameframex.doc.alianblank.com/
//  Official Documentation: https://gameframex.doc.alianblank.com/
// ==========================================================================================

using System;
using cn.sharesdk.unity3d;
using GameFrameX.Event.Runtime;
using GameFrameX.Runtime;
using GameFrameX.ShareSdk.Runtime;
using UnityEngine;

namespace GameFrameX.Login.FaceBook.Runtime
{
    [UnityEngine.Scripting.Preserve]
    public sealed class FaceBookLoginManager : GameFrameworkModule, IFaceBookLoginManager
    {
        [UnityEngine.Scripting.Preserve]
        public FaceBookLoginManager()
        {
        }

        private EventComponent _eventComponent;
        private ShareSDK _shareSDK;
        private bool isInit = false;

        /// <summary>
        /// 初始化 Facebook 登录组件。
        /// </summary>
        /// <param name="appId">Facebook 登录 App Id。</param>
        /// <param name="appKey">Facebook 登录 App Key。</param>
        [UnityEngine.Scripting.Preserve]
        public void Init(string appId, string appKey)
        {
            if (isInit)
            {
                return;
            }

            _eventComponent = GameEntry.GetComponent<EventComponent>();
            _eventComponent.CheckSubscribe(AuthEventArgs.EventId, OnAuthEventArgs);
            _shareSDK = UnityEngine.Object.FindObjectOfType<ShareSDK>();
#if UNITY_ANDROID
            _shareSDK.devInfo.facebook.ConsumerKey = appId;
            _shareSDK.devInfo.facebook.ConsumerSecret = appKey;

            _shareSDK.devInfo.facebookAccount.AppKey = appId;
            _shareSDK.devInfo.facebookAccount.AppSecret = appKey;

            _shareSDK.devInfo.facebookMessenger.AppId = appId;
#endif
#if UNITY_IOS || UNITY_IPHONE
            _shareSDK.devInfo.facebook.api_key = appId;
            _shareSDK.devInfo.facebook.app_secret = appKey;

            _shareSDK.devInfo.facebookAccount.app_id = appId;
            _shareSDK.devInfo.facebookAccount.client_token = appKey;

            _shareSDK.devInfo.facebookMessenger.api_key = appId;
#endif
            isInit = true;
        }

        private void OnAuthEventArgs(object sender, GameEventArgs e)
        {
            if (e is AuthEventArgs eventArgs)
            {
                if (eventArgs.Type != PlatformType.Facebook)
                {
                    return;
                }

                if (eventArgs.State == ResponseState.Success)
                {
                    Success();
                }
                else
                {
                    _loginFail?.Invoke((int)eventArgs.State);
                }
            }
        }


        private void Success()
        {
            var faceBookLoginSuccess = new FaceBookLoginSuccess();
            var authInfo = _shareSDK.GetAuthInfo(PlatformType.Facebook);
            Log.Debug(authInfo);
            if (authInfo != null)
            {
                if (authInfo.ContainsKey("userName"))
                {
                    faceBookLoginSuccess.NickName = authInfo["userName"].ToString();
                }

                if (authInfo.ContainsKey("userID"))
                {
                    faceBookLoginSuccess.UserId = authInfo["userID"].ToString();
                }

                if (authInfo.ContainsKey("userID"))
                {
                    faceBookLoginSuccess.UserId = authInfo["userID"].ToString();
                }

                if (authInfo.ContainsKey("userIcon"))
                {
                    faceBookLoginSuccess.PhotoUrl = authInfo["userIcon"].ToString();
                }

                if (authInfo.ContainsKey("token"))
                {
                    faceBookLoginSuccess.Token = authInfo["token"].ToString();
                }

                if (authInfo.ContainsKey("userGender"))
                {
                    faceBookLoginSuccess.UserGender = authInfo["userGender"].ToString();
                }
            }

            _loginSuccess?.Invoke(faceBookLoginSuccess);
        }

        private Action<FaceBookLoginSuccess> _loginSuccess;
        private Action<int> _loginFail;

        /// <summary>
        /// 登录 Facebook 账号。
        /// </summary>
        /// <param name="loginSuccess">登录成功回调。</param>
        /// <param name="loginFail">登录失败回调。</param>
        [UnityEngine.Scripting.Preserve]
        public void Login(Action<FaceBookLoginSuccess> loginSuccess, Action<int> loginFail)
        {
            _loginSuccess = loginSuccess;
            _loginFail = loginFail;
#if UNITY_EDITOR
            _loginSuccess?.Invoke(new FaceBookLoginSuccess() { NickName = "test@facebook.com", UserId = SystemInfo.deviceUniqueIdentifier, PhotoUrl = "test", Token = "test", UserGender = "f", OpenId = "test", UnionId = "test" });
            return;
#endif
            if (_shareSDK.IsAuthorized(PlatformType.Facebook))
            {
                Success();
                return;
            }

            _shareSDK.Authorize(PlatformType.Facebook);
        }

        /// <summary>
        /// 退出登录 Facebook 账号。
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        public void LogOut()
        {
            _shareSDK.CancelAuthorize(PlatformType.Facebook);
        }

        protected override void Update(float elapseSeconds, float realElapseSeconds)
        {
        }

        protected override void Shutdown()
        {
        }
    }
}