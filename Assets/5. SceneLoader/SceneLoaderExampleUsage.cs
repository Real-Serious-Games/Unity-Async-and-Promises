using UnityEngine;
using System.Collections;

public class SceneLoaderExampleUsage : MonoBehaviour {

	void Start () 
    {
        Debug.Log("Loading scene...");
        SceneLoader.LoadScene("SceneLoader_TestScene")
            .Then(() => Debug.Log("Loaded scene.")) // Signal completion!
            .Catch(ex => Debug.LogException(ex, this)); // Handle any errors that may have occured.
    }

}
