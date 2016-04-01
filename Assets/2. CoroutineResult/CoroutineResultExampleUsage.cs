using UnityEngine;
using System.Collections;

public class CoroutineResultExampleUsage : MonoBehaviour {

	// Use this for initialization
	void Start () {

        var exampleCoroutine = this.gameObject.AddComponent<CoroutineResult>();
        Debug.Log("Starting coroutine...");
        exampleCoroutine.Execute()
            .Then(value => Debug.Log("Coroutine has completed with value: " + value)) // Signal completion!
            .Catch(ex => Debug.LogException(ex, this)); // Handle any errors that may have occured.


    }
	
	// Update is called once per frame
	void Update () {

	}
}
