using Paps.UnityToolbarExtenderUIToolkit;
using UnityEngine.UIElements;

namespace ToolbarExtensions.Elements
{
    [MainToolbarElement(id: "DebugEditorToggle", ToolbarAlign.Right, 0)]
    public class DebugToggleElement : Toggle
    {
        [Serialize] private bool _enabled;
        
        private void InitializeElement()
        {
            text = "Debug";
            tooltip = "Toggles Debug mode";
            value = _enabled;
            
            Sync();
            
            RegisterCallback<ChangeEvent<bool>>(OnToggleValueChanged);
        }

        private void OnToggleValueChanged(ChangeEvent<bool> evt)
        {
            _enabled = evt.newValue;
            Sync();
        }

        private void Sync() =>
            DebugMode.Enabled = _enabled;
    }
}
