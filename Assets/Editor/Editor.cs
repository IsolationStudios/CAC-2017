using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

/*
 * Editor scripts
 */

public class Editor : MonoBehaviour {
	
	[MenuItem("Edit/Play Init %0")]
	public static void PlayFromPreLaunchScene(){
		if(EditorApplication.isPlaying){
			EditorApplication.isPlaying = false;
			return;
		}
			
		EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo ();
		EditorSceneManager.OpenScene ("Assets/Scenes/title.unity");
		EditorApplication.isPlaying = true;
	}
}
