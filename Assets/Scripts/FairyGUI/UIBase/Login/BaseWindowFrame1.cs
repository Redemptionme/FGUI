/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace LrsJudgeTools.Login
{
    public partial class BaseWindowFrame1 : GLabel
    {
        public GGraph m_dragArea;
        public GGraph m_contentArea;
        public BaseNormalButton m_closeButton;
        public const string URL = "ui://vvgx8vozhpdk9";

        public static BaseWindowFrame1 CreateInstance()
        {
            return (BaseWindowFrame1)UIPackage.CreateObject("Login", "WindowFrame1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_dragArea = (GGraph)GetChildAt(0);
            m_contentArea = (GGraph)GetChildAt(1);
            m_closeButton = (BaseNormalButton)GetChildAt(3);
        }
    }
}