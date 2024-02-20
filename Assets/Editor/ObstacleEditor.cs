using UnityEngine;
using UnityEditor;

public class ObstacleEditor : EditorWindow
{
    public ObstacleData obstacleData;

    [MenuItem("Tools/Obstacle Editor")]
    public static void ShowWindow()
    {
        GetWindow<ObstacleEditor>("Obstacle Editor");
    }

    void OnGUI()
    {
        obstacleData = EditorGUILayout.ObjectField("Obstacle Data", obstacleData, typeof(ObstacleData), false) as ObstacleData;

        if (obstacleData == null)
        {
            EditorGUILayout.HelpBox("Please assign Obstacle Data.", MessageType.Warning);
            return;
        }

        GUILayout.Space(20);

        EditorGUI.BeginChangeCheck(); // Start checking for changes

        for (int x = 0; x < obstacleData.obstacleMap.GetLength(0); x++)
        {
            GUILayout.BeginHorizontal();

            for (int y = 0; y < obstacleData.obstacleMap.GetLength(1); y++)
            {
                bool oldValue = obstacleData.obstacleMap[x, y];
                bool newValue = EditorGUILayout.Toggle(oldValue);

                if (oldValue != newValue)
                {
                    obstacleData.obstacleMap[x, y] = newValue;
                }
            }

            GUILayout.EndHorizontal();
        }

        if (EditorGUI.EndChangeCheck()) // Check if any changes were made
        {
            // If changes were made, mark the object as dirty so Unity knows to save it
            EditorUtility.SetDirty(obstacleData);
        }
    }
}
