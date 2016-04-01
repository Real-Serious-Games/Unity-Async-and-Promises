using UnityEngine;
using System.Collections;

public class BasicCoroutineAsPromiseExampleUsage : MonoBehaviour {

	// Use this for initialization
	void Start () {

        var exampleCoroutine = this.gameObject.AddComponent<BasicCoroutineAsPromise>();
        Debug.Log("Starting coroutine...");
        exampleCoroutine.Execute()
            .Then(() => Debug.Log("Coroutine has completed!")) // Signal completion!
            .Catch(ex => Debug.LogException(ex, this)); // Handle any errors that may have occured.


    }
	
	// Update is called once per frame
	void Update () {

	}
}
