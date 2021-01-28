/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace LrsJudgeTools.Login
{
    public partial class BaseWind : GComponent
    {
        public BaseWindowFrame1 m_frame;
        public const string URL = "ui://vvgx8vozhpdka";

        public static BaseWind CreateInstance()
        {
            return (BaseWind)UIPackage.CreateObject("Login", "Wind");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_frame = (BaseWindowFrame1)GetChildAt(0);
        }
    }
}