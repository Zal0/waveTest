using System;
using WaveEngine.Common.Graphics;
using WaveEngine.Editor.Extension;
using WaveEngine.Editor.Extension.Attributes;

namespace MyWaveProject
{
    // Sample class for a custom Property editor.
    // This property editor will be used for a property or field of type MyCustomClass when is used in a component of an entity.
    // 
    // [CustomPropertyEditor(typeof(MyCustomClass))]
    // public class MyCustomClassEditor : PropertyEditor<MyCustomClass>
    // {
    //     MyCustomClass property;
    // 
    //     protected override void Loaded()
    //     {
    //         this.property = this.GetMemberValue();
    //     }
    // 
    //     public override void GenerateUI()
    //     {
    //         // Add MyCustomClass properties.
    //         this.propertyPanelContainer.AddLabel("MyLabel", "My label");
    //         this.propertyPanelContainer.AddNumeric(nameof(MyCustomClass.Number), nameof(MyCustomClass.Number), getValue: () => property.Number, setValue: x => property.Number = x);
    //         this.propertyPanelContainer.AddText(nameof(MyCustomClass.Number), nameof(MyCustomClass.String), () => property.String, x => property.String = x);
    //     }
    // }
}
