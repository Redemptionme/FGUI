using System;
using System.Reflection;
using FairyGUI;
using LrsJudgeTools.Login;
using UnityEngine;

namespace GameFramework.FGUI
{
    public class BaseWindow : Window
    {
        private Type m_Type = typeof(BaseWind);
         
        public BaseWindow()
        {
            
        }
        
        protected override void OnInit()
        {
            MethodInfo method = m_Type.GetMethod("CreateInstance");
            this.contentPane = (GComponent) method.Invoke(null, null); 
            this.Center();
            
        }

        protected override void DoShowAnimation()
        {
            this.SetScale(0.1f, 0.1f);
            this.SetPivot(0.5f, 0.5f);
            this.TweenScale(new Vector2(1, 1), 0.3f).OnComplete(this.OnShown);
        }

        protected override void DoHideAnimation()
        {
            this.TweenScale(new Vector2(0.1f, 0.1f), 0.3f).OnComplete(this.HideImmediately);
        }

        
        
        
    }
    
    
}