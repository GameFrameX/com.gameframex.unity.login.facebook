// GameFrameX 组织下的以及组织衍生的项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
// 
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE 文件。
// 
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using System;
using GameFrameX.Runtime;
using UnityEngine;

namespace GameFrameX.Login.FaceBook.Runtime
{
    /// <summary>
    /// FaceBook登录组件。
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/FaceBook Login")]
    [RequireComponent(typeof(GameFrameXFaceBookLoginCroppingHelper))]
    [UnityEngine.Scripting.Preserve]
    public class FaceBookLoginComponent : GameFrameworkComponent
    {
        private IFaceBookLoginManager _FaceBookLoginManager = null;

        /// <summary>
        /// FaceBook AppId。
        /// </summary>
        [SerializeField] private string m_AppId = string.Empty;

        /// <summary>
        /// FaceBook AppKey。
        /// </summary>
        [SerializeField] private string m_AppKey = string.Empty;

        /// <summary>
        /// 游戏框架组件初始化。
        /// </summary>
        protected override void Awake()
        {
            ImplementationComponentType = Utility.Assembly.GetType(componentType);
            InterfaceComponentType = typeof(IFaceBookLoginManager);
            base.Awake();

            _FaceBookLoginManager = GameFrameworkEntry.GetModule<IFaceBookLoginManager>();
            if (_FaceBookLoginManager == null)
            {
                Log.Fatal("face book manager is invalid.");
                return;
            }
        }

        /// <summary>
        /// 初始化 FaceBook 登录组件。
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        public void Init()
        {
            _FaceBookLoginManager.Init(m_AppId, m_AppKey);
        }

        /// <summary>
        /// 登录 Facebook 账号。
        /// </summary>
        /// <param name="loginSuccess">登录成功回调。</param>
        /// <param name="loginFail">登录失败回调。</param>
        [UnityEngine.Scripting.Preserve]
        public void Login(Action<FaceBookLoginSuccess> loginSuccess, Action<int> loginFail)
        {
            _FaceBookLoginManager.Login(loginSuccess, loginFail);
        }

        /// <summary>
        /// 退出登录 Facebook 账号。
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        public void LogOut()
        {
            _FaceBookLoginManager.LogOut();
        }
    }
}