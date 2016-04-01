using RSG;
using System;
using System.Collections;
using UnityEngine;

//
// Example of a coroutine wrapped in a promise that returns a result.
//
// This doesn't do anything much. It's just simply a template to start from.
//
public class CoroutineResult : MonoBehaviour
{
    public IPromise<string> Execute()
    {
        return new Promise<string>((resolve, reject) =>
            StartCoroutine(TheCoroutine(resolve, reject))
        );
    }

    private IEnumerator TheCoroutine(Action<string> resolve, Action<Exception> reject)
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
            resolve("Hi from the coroutine!");
        }
    }
}