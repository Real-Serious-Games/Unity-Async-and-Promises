﻿using UnityEngine;
using System.Collections;

public class HTTPWithProceduralInstantiationExampleUsage : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Debug.Log("Starting coroutine...");
        HTTPWithProceduralInstantiation.Get("http://www.google.com")
            .Then(value => Debug.Log("HTML: " + value)) // Signal completion!
            .Catch(ex => Debug.LogException(ex, this)); // Handle any errors that may have occured.


    }
	
	// Update is called once per frame
	void Update () {

	}
}
