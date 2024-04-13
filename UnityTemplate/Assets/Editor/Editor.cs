using System.IO;
using UnityEditor;
using UnityEngine;

public class Editor : MonoBehaviour
{
    [MenuItem("Tools/Build")]
    public static void Build()
    {
        string dir = "AssetsBundles";
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        BuildPipeline.BuildAssetBundles(dir, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    }
}
