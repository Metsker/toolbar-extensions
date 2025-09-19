using System;
using System.Globalization;
using Paps.UnityToolbarExtenderUIToolkit;
using UnityEngine;
using UnityEngine.UIElements;

namespace ToolbarExtensions.Elements
{
    [MainToolbarElement(id: "TimeScaleSlider", ToolbarAlign.Right, 1)]
    public class TimeScaleSliderElement : Slider
    {
        private static string LabelText => "TimeScale: " + Time.timeScale.ToString(CultureInfo.InvariantCulture);

        private void InitializeElement()
        {
            label = LabelText;
            lowValue = 0;
            highValue = 2;
            value = Time.timeScale;
            style.flexDirection = FlexDirection.RowReverse;

            labelElement.style.width = 88;
            labelElement.pickingMode = PickingMode.Ignore;
            
            RegisterCallback<ChangeEvent<float>>(OnSliderValueChanged);
        }

        private void OnSliderValueChanged(ChangeEvent<float> evt)
        {
            float round = (float)Math.Round(evt.newValue, 1);
            Time.timeScale = round;
            label = LabelText;
        }
    }
}



