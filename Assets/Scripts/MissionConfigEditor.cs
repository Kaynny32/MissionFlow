/*#if UNITY_EDITOR
[UnityEditor.CustomEditor(typeof(MissionConfig))]
public class MissionConfigEditor : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        var config = (MissionConfig)target;

        // ������ ����������� ����
        DrawDefaultInspector();

        // �������� ����������
        if (config.MissionImplementation == null && config.MissionBehaviour != null)
        {
            UnityEditor.EditorGUILayout.HelpBox("������ �� ��������� IMission!", UnityEditor.MessageType.Error);
        }
    }
}
#endif*/