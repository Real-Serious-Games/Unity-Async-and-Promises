using UnityEngine;
using System.Collections;
using System.IO;
using System.Linq;
using RSG;
using System.Linq;

public class MergingScenesDynamicExample : MonoBehaviour {

	void Start ()
    {
        var scenesToLoad = new string[]
        {
            "MergeScene1",
            "MergeScene2",
            "MergeScene3",
        };

        scenesToLoad.Aggregate(Promise.Resolved(),
                (prevPromise, sceneName) => prevPromise.Then(() => AdditiveSceneLoader.LoadScene(sceneName))
            )
            .Then(() => Debug.Log("Loaded all scenes."))
            .Catch(ex => Debug.LogException(ex, this)); // Handle any errors that may have occured.
    }
}
