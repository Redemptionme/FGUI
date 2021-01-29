using UnityEngine;
using UnityEditor;
using System.IO;


public class BuildAssetBundles2
{
    [MenuItem("test/BuildBundles")]
    public static void Builde()
    {
        
        AssetImporter.GetAtPath("Assets/GameRes/UI/Common_fui.bytes").assetBundleName = "hh.ab";
        AssetImporter.GetAtPath("Assets/GameRes/UI/Login_fui.bytes").assetBundleName = "hh.ab";
        BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath, BuildAssetBundleOptions.None, BuildTarget.Android);
    }

}