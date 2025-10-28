// GameFrameX 组织下的以及组织衍生的项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
// 
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE 文件。
// 
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

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

        [UnityEngine.Scripting.Preserve]
        public void Init(string appId, string appKey)
        {
            _eventComponent = GameEntry.GetComponent<EventComponent>();
            _eventComponent.CheckSubscribe(AuthEventArgs.EventId, OnAuthEventArgs);
            _shareSDK = UnityEngine.Object.FindObjectOfType<ShareSDK>();
            _shareSDK.devInfo.facebook.ConsumerKey = appId;
            _shareSDK.devInfo.facebook.ConsumerSecret = appKey;

            _shareSDK.devInfo.facebookAccount.AppKey = appId;
            _shareSDK.devInfo.facebookAccount.AppSecret = appKey;

            _shareSDK.devInfo.facebookMessenger.AppId = appId;
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
                    var faceBookLoginSuccess = new FaceBookLoginSuccess();
                    if (eventArgs.Data.ContainsKey("name"))
                    {
                        faceBookLoginSuccess.Name = eventArgs.Data["name"].ToString();
                    }

                    if (eventArgs.Data.ContainsKey("id"))
                    {
                        faceBookLoginSuccess.Id = eventArgs.Data["id"].ToString();
                    }

                    if (eventArgs.Data.ContainsKey("uid"))
                    {
                        faceBookLoginSuccess.Uid = eventArgs.Data["uid"].ToString();
                    }

                    if (eventArgs.Data.ContainsKey("picture"))
                    {
                        faceBookLoginSuccess.PhotoUrl = eventArgs.Data["picture"].ToString();
                    }

                    if (eventArgs.Data.ContainsKey("email"))
                    {
                        faceBookLoginSuccess.Email = eventArgs.Data["email"].ToString();
                    }

                    _loginSuccess.Invoke(faceBookLoginSuccess);
                }
                else
                {
                    _loginFail.Invoke((int)eventArgs.State);
                }
            }
        }

        private Action<FaceBookLoginSuccess> _loginSuccess;
        private Action<int> _loginFail;

        [UnityEngine.Scripting.Preserve]
        public void Login(Action<FaceBookLoginSuccess> loginSuccess, Action<int> loginFail)
        {
            _loginSuccess = loginSuccess;
            _loginFail = loginFail;
#if UNITY_EDITOR
            _loginSuccess?.Invoke(new FaceBookLoginSuccess() { Name = "test", Id = SystemInfo.deviceUniqueIdentifier, Uid = SystemInfo.deviceUniqueIdentifier, PhotoUrl = "test", Email = "test@facebook.com" });
            return;
#endif
            _shareSDK.Authorize(PlatformType.Facebook);
        }

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