using RSG;
using System;
using System.Collections;
using UnityEngine;

//
// Async loads a Unity scene wrapped in a promise.
// 
// Uses the old Unity scene loading API (prior to Unity 5.3, now obselete).
//
public class SceneLoader : MonoBehaviour
{
    //
    // Singleton instances used to run the coroutine.
    //
    private static SceneLoader singletonInstance = null;

    /// <summary>
    /// Returns a promise with the deserialised result of a GET request to the specified URL.
    /// The result of the raw request must be JSON that can be deserialised into type T.
    /// </summary>
    public static IPromise LoadScene(string sceneName)
    {
        if (singletonInstance == null)
        {
            var gameObject = new GameObject("_SceneLoader");
            GameObject.DontDestroyOnLoad(gameObject);
            singletonInstance = gameObject.AddComponent<SceneLoader>();
        }

        return singletonInstance.PrivateLoadScene(sceneName);
    }

    /// <summary>
    /// Returns a promise with the deserialised result of a GET request to the specified URL.
    /// The result of the raw request must be JSON that can be deserialised into type T.
    /// </summary>
    private IPromise PrivateLoadScene(string sceneName)
    {
        return new Promise((resolve, reject) =>
            StartCoroutine(TheCoroutine(sceneName, resolve, reject))
        );
    }

    private IEnumerator TheCoroutine(string sceneName, Action resolve, Action<Exception> reject)
    {
        yield return Application.LoadLevelAsync(sceneName);

        resolve();
   }
}