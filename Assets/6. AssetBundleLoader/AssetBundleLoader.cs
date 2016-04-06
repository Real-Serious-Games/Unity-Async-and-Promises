using RSG;
using System;
using System.Collections;
using UnityEngine;

//
// Async loads a Unity scene wrapped in a promise.
// 
// Uses the old Unity scene loading API (prior to Unity 5.3, now obselete).
//
public class AssetBundleLoader : MonoBehaviour
{
    //
    // Singleton instances used to run the coroutine.
    //
    private static AssetBundleLoader singletonInstance = null;

    /// <summary>
    /// todo
    /// </summary>
    public static IPromise<AssetBundle> LoadAssetBundle(string assetBundleFilePath)
    {
        if (singletonInstance == null)
        {
            var gameObject = new GameObject("_AssetBundleLoader");
            GameObject.DontDestroyOnLoad(gameObject);
            singletonInstance = gameObject.AddComponent<AssetBundleLoader>();
        }

        return singletonInstance.PrivateLoadAssetBundle(assetBundleFilePath);
    }

    /// <summary>
    /// todo
    /// </summary>
    private IPromise<AssetBundle> PrivateLoadAssetBundle(string assetBundleFilePath)
    {
        return new Promise<AssetBundle>((resolve, reject) =>
            StartCoroutine(TheCoroutine(assetBundleFilePath, resolve, reject))
        );
    }

    private IEnumerator TheCoroutine(string assetBundleFilePath, Action<AssetBundle> resolve, Action<Exception> reject)
    {
        var www = new WWW("file://" + assetBundleFilePath);

        yield return www;

        try
        {
            if (!string.IsNullOrEmpty(www.error))
            {
                reject(new ApplicationException("Failed to load asset bundle " + assetBundleFilePath + "\r\n" + www.error));
            }
            else 
            {
                resolve(www.assetBundle);
            }
        }
        catch (Exception ex)
        {
            // Catch any other errors.
            reject(ex);
        }
   }
}