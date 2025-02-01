using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[InitializeOnLoad]
public class SceneManagerUtility {

	private readonly static string LoadScenePath = "Assets/Game/Scenes/Load.unity";
	private readonly static string MainScenePath = "Assets/Game/Scenes/Main.unity";
	private readonly static string TestScenePath = "Assets/Game/Scenes/Test.unity";

	static SceneManagerUtility() { }

	[MenuItem("SceneManager/Launch Game %l", false, 0)]
	private static void Play_0() {
		OpenScene(LoadScenePath, true);
	}

	[MenuItem("SceneManager/Launch Game +clearPrefs %&l", false, 1)]
	private static void Play_0_clean() {
		PlayerPrefs.DeleteAll();
		OpenScene(LoadScenePath, true);
	}

	[MenuItem("SceneManager/Play Current +clearPrefs #l", false, 1)]
	private static void Play_current_clean() {
		PlayerPrefs.DeleteAll();
		EditorApplication.isPlaying = true;
	}

	[MenuItem("SceneManager/Open 0 'Load'", false, 100)]
	private static void Open_0() {
		OpenScene(LoadScenePath);
	}

	[MenuItem("SceneManager/Open 1 'Main'", false, 102)]
	private static void Open_2() {
		OpenScene(MainScenePath);
	}

	[MenuItem("SceneManager/Open 'Test'", false, 200)]
	private static void Open_Test() {
		OpenScene(TestScenePath);
	}

	private static void OpenScene(string scenePath, bool startPlaymode = false) {
		if (EditorApplication.isPlaying)
			return;

		if (!System.IO.File.Exists(scenePath)) {
			Debug.LogError($"No scene with path {scenePath} found!");
			return;
		}

		if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo()) {
			EditorSceneManager.OpenScene(scenePath);
			if (startPlaymode)
				EditorApplication.isPlaying = true;
		}
	}
}