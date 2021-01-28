/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace LrsJudgeTools.Login
{
    public partial class BaseNormalButton : GComponent
    {
        public Controller m_button;
        public const string URL = "ui://vvgx8vozt6jc8";

        public static BaseNormalButton CreateInstance()
        {
            return (BaseNormalButton)UIPackage.CreateObject("Login", "NormalButton");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_button = GetControllerAt(0);
        }
    }
}