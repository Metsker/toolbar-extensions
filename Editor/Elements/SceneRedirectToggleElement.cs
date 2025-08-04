using Paps.UnityToolbarExtenderUIToolkit;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.UIElements;

namespace ToolbarExtensions.Elements
{
    [MainToolbarElement(id: "SceneRedirectToggle", ToolbarAlign.Left, 0)]
    public class SceneRedirectToggleElement : Toggle
    {
        [Serialize] private bool _redirect;

        private void InitializeElement()
        {
            value = _redirect;
            text = "Redirect";
            tooltip = "Enters play mode from the first scene in build settings";
            
            RegisterCallback<ChangeEvent<bool>>(OnToggleValueChanged);
            Sync();
        }

        private void OnToggleValueChanged(ChangeEvent<bool> evt)
        {
            _redirect = evt.newValue;
            Sync();
        }

        private void Sync()
        {
            string firstScenePath = EditorBuildSettings.scenes.Length > 0 ? EditorBuildSettings.scenes[0].path : null;
            SetPlayModeStartScene(_redirect ? firstScenePath : null);
        }

        private static void SetPlayModeStartScene(string scenePath)
        {
            SceneAsset startScene = string.IsNullOrEmpty(scenePath) ? null : AssetDatabase.LoadAssetAtPath<SceneAsset>(scenePath);
            EditorSceneManager.playModeStartScene = startScene;
        }
    }
}
