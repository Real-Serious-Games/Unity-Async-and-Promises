using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

/// <summary>
/// This class simply adds a menu to Unity to create an aset bundle.
/// </summary>
public class AssetBundleCreator
{
    [MenuItem("Custom/Build Asset Bundles")]
    static void BuildAllAssetBundles()
    {
        BuildPipeline.BuildAssetBundles(Path.Combine(Application.dataPath, "6. AssetBundleLoader\\Bundles"));
    }
}