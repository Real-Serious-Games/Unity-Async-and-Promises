using UnityEngine;
using System.Collections;
using System.IO;
using System.Linq;
using RSG;

public class MergingScenesExample : MonoBehaviour {

	void Start ()
    {
        AdditiveSceneLoader.LoadScene("MergeScene1")
            .Then(() => AdditiveSceneLoader.LoadScene("MergeScene2"))
            .Then(() => AdditiveSceneLoader.LoadScene("MergeScene3"))
            .Catch(ex => Debug.LogException(ex, this)); // Handle any errors that may have occured.
    }
}
