using RSG;
using System;
using System.Collections;
using UnityEngine;

//
// Example of a HTTP GET using Unity's WWW wrapped in a promise.
//
public class CoroutineWithHttpGet : MonoBehaviour
{
    /// <summary>
    /// Returns a promise with the deserialised result of a HTTP GET to the specified URL.
    /// </summary>
    public IPromise<string> Get(string url)
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