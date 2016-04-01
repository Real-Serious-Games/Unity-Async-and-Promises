using RSG;
using System;
using System.Collections;
using UnityEngine;

//
// Most basic example of wrapping a coroutine in a promise.
//
// This doesn't do anything much. It's just simply a template to start from.
//
public class BasicCoroutineAsPromise : MonoBehaviour
{
    public IPromise Execute()
    {
        return new Promise((resolve, reject) =>
            StartCoroutine(TheCoroutine(resolve, reject))
        );
    }

    private IEnumerator TheCoroutine(Action resolve, Action<Exception> reject)
    {
        // ... add your async operations here ...

        yield return new WaitForSeconds(5f);

        // ... several yields later ...

        var someErrorOccurred = false;
        if (someErrorOccurred)
        {
            // An error occurred, reject the promise.
            reject(new ApplicationException("My error"));
        }
        else
        {
            // Completed successfully, resolve the promise.
            resolve();
        }
    }
}