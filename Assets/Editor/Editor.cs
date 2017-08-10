using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class Editor : MonoBehaviour {

	[MenuItem("Edit/Play-Stop, But From Launch Scene %0")]
	public static void PlayFromPreLaunchScene(){
		if(EditorApplication.isPlaying){
			EditorApplication.isPlaying = false;
			return;
		}
			
		EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo ();
		EditorSceneManager.OpenScene ("Assets/Scenes/init.unity");
		EditorApplication.isPlaying = true;
	}
}
