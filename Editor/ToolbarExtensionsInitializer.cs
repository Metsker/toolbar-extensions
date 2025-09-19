using Paps.UnityToolbarExtenderUIToolkit;
using UnityEditor;
using UnityEngine.UIElements;

namespace ToolbarExtensions
{
    [InitializeOnLoad]
    public class ToolbarExtensionsInitializer
    {
        static ToolbarExtensionsInitializer()
        {
            MainToolbar.OnInitialized += ApplyStyleSheet;
        }

        private static void ApplyStyleSheet()
        {
            StyleSheet styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Packages/com.metsker.toolbar-extensions/Editor/USS/ToolbarExtensions.uss");
            MainToolbar.UnityToolbarRoot.styleSheets.Add(styleSheet);

            MainToolbar.CenterContainer.Q("ToolbarAutomaticExtenderLeftContainer").Query().ForEach(e => e.focusable = false);
            MainToolbar.CenterContainer.Q("ToolbarAutomaticExtenderRightContainer").Query().ForEach(e => e.focusable = false);
        }
    }
}


