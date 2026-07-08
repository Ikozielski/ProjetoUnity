using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[InitializeOnLoad]
public static class AutoSave
{
    const double intervaloSegundos = 120; // salva a cada 2 minutos

    static double ultimoSave;

    static AutoSave()
    {
        ultimoSave = EditorApplication.timeSinceStartup;
        EditorApplication.update += Verificar;
    }

    static void Verificar()
    {
        if (EditorApplication.timeSinceStartup - ultimoSave < intervaloSegundos)
            return;

        ultimoSave = EditorApplication.timeSinceStartup;

        if (EditorApplication.isPlaying || EditorApplication.isCompiling || EditorApplication.isUpdating)
            return;

        EditorSceneManager.SaveOpenScenes();
        AssetDatabase.SaveAssets();
        Debug.Log($"[AutoSave] Cena salva automaticamente ({System.DateTime.Now:HH:mm:ss})");
    }
}
