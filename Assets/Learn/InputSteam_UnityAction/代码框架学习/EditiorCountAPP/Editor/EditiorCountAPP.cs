
using UnityEngine;
using UnityEditor;
namespace FrameworkDesign.CountApp
{ 

public class EditiorCountAPP : EditorWindow
{

    [MenuItem("EditorCountAPP/Open")]
    static void Open()
    {
        var editorCountApp = GetWindow<EditiorCountAPP>();

        editorCountApp.name = nameof(EditiorCountAPP);

        editorCountApp.position = new Rect(100, 100, 400, 600);
        editorCountApp.Show();
    }

    private void OnGUI()
    {
        if (GUILayout.Button("+"))
        {
            new AddCountCommand().Execute();
        }

        if (GUILayout.Button("-"))
        {
            new SubCountCommand().Execute();
        }

        GUILayout.Label(CounterApp.Get<ICounterModel>().Count.Value.ToString());
    }
}

}
