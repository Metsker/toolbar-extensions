using System.IO;
using Paps.UnityToolbarExtenderUIToolkit;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

namespace ToolbarExtensions.Elements
{
    [MainToolbarElement(id: "SceneNavigationButtons", ToolbarAlign.Left, order: 1)]
    public class SceneButtonsElement : VisualElement
    {
        private void InitializeElement()
        {
            style.flexDirection = FlexDirection.Row;
            foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
            {
                if (!scene.enabled)
                    continue;

                string path = scene.path;
                string sceneName = Path.GetFileNameWithoutExtension(path);

                var sceneButton = new Button();
                sceneButton.clickable = new Clickable(() =>
                {
                    if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                        return;

                    EditorSceneManager.OpenScene(path, !Event.current.alt ? OpenSceneMode.Single : OpenSceneMode.Additive);
                });
                sceneButton.clickable.activators.Add(new ManipulatorActivationFilter { button = MouseButton.LeftMouse, modifiers = EventModifiers.Alt });
                
                sceneButton.style.overflow = Overflow.Visible;
                sceneButton.text = sceneName;
                sceneButton.tooltip = "Hold Alt to open in additive mode";
                Add(sceneButton);
            }
        }
    }
}

