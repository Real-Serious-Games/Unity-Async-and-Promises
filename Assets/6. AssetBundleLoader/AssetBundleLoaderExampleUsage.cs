using UnityEngine;
using System.Collections;
using System.IO;
using System.Linq;

public class AssetBundleLoaderExampleUsage : MonoBehaviour {

	void Start () 
    {
        Debug.Log("Loading asset bundle...");
        var assetBundleFilePath = Path.Combine(Application.dataPath, "6. AssetBundleLoader\\Bundles\\trees");
        AssetBundleLoader.LoadAssetBundle(assetBundleFilePath)
            .Then(assetBundle =>
            {
                Debug.Log("Loaded bundle.");

                var allBundleObjects = assetBundle
                    .LoadAllAssets(typeof(GameObject))
                    .Cast<GameObject>();

                var x = 0f;

                foreach (var bundleObject in allBundleObjects)
                {
                    Instantiate(bundleObject, new Vector3(x, 0f, 0f), Quaternion.identity);
                    x += 3f;
                }                
                
                assetBundle.Unload(false);
            }) 
            .Catch(ex => Debug.LogException(ex, this)); // Handle any errors that may have occured.
    }

}
