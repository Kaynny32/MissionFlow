/*#if UNITY_EDITOR
[UnityEditor.CustomEditor(typeof(MissionConfig))]
public class MissionConfigEditor : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        var config = (MissionConfig)target;

        // Рисуем стандартные поля
        DrawDefaultInspector();

        // Проверка реализации
        if (config.MissionImplementation == null && config.MissionBehaviour != null)
        {
            UnityEditor.EditorGUILayout.HelpBox("Объект не реализует IMission!", UnityEditor.MessageType.Error);
        }
    }
}
#endif*/