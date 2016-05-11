using UnityEngine;
using System.Collections;
using System.IO;
using System.Linq;
using RSG;

public class CombinedExample : MonoBehaviour {

	void Start ()
    {
        LoadScene()
            .Then(() => LoadBundle())
            .Then(assetBundle => InstantiateGameObjects(assetBundle))
            .Then(assetBundle => assetBundle.Unload(false))
            .Catch(ex => Debug.LogException(ex, this)); // Handle any errors that may have occured.
    }

    private IPromise LoadScene()
    {
        Debug.Log("Loading scene...");

        return SceneLoader.LoadScene("SceneLoader_TestScene")
            .Then(() => Debug.Log("Loaded scene"));
    }

    private IPromise<AssetBundle> LoadBundle()
    {
        var assetBundleFilePath = Path.Combine(Application.dataPath, "6. AssetBundleLoader\\Bundles\\trees");
        return AssetBundleLoader.LoadAssetBundle(assetBundleFilePath)
            .Then(bundle =>
            {
                Debug.Log("Loaded bundle");

                return bundle;
            });
    }

    private AssetBundle InstantiateGameObjects(AssetBundle assetBundle)
    {
        var allBundleObjects = assetBundle
            .LoadAllAssets(typeof(GameObject))
            .Cast<GameObject>();

        var x = 0f;

        foreach (var bundleObject in allBundleObjects)
        {
            Instantiate(bundleObject, new Vector3(x, 0f, -5f), Quaternion.identity);
            x += 5f;
        }

        return assetBundle;
    }
}
