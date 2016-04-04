using RSG;
using System;
using System.Collections;
using UnityEngine;

//
// Same as previous example... but GameObject/MonoBehaviour are instantiated automatically.
//
public class HTTPWithProceduralInstantiation : MonoBehaviour
{
    //
    // Singleton instances used to run the coroutine.
    //
    private static HTTPWithProceduralInstantiation singletonInstance = null;

    /// <summary>
    /// Returns a promise with the deserialised result of a GET request to the specified URL.
    /// The result of the raw request must be JSON that can be deserialised into type T.
    /// </summary>
    public static IPromise<string> Get(string url)
    {
        if (singletonInstance == null)
        {
            var gameObject = new GameObject("_HTTP_Helper");
            GameObject.DontDestroyOnLoad(gameObject);
            singletonInstance = gameObject.AddComponent<HTTPWithProceduralInstantiation>();
        }

        return singletonInstance.PrivateGet(url);
    }

    /// <summary>
    /// Returns a promise with the deserialised result of a GET request to the specified URL.
    /// The result of the raw request must be JSON that can be deserialised into type T.
    /// </summary>
    private IPromise<string> PrivateGet(string url)
    {
        return new Promise<string>((resolve, reject) =>
            StartCoroutine(TheCoroutine(url, resolve, reject))
        );
    }

    private IEnumerator TheCoroutine(string url, Action<string> resolve, Action<Exception> reject)
    {
        var www = new WWW(url);

        yield return www; // Allow the async operation to complete.

        try
        {
            if (!string.IsNullOrEmpty(www.error))
            {
                reject(new ApplicationException(www.error));
            }
            else
            {
                resolve(www.text);
            }
        }
        catch (Exception ex)
        {
            reject(ex);
        }
    }
}