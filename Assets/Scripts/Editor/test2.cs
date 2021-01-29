using UnityEngine;
using UnityEditor;
using System.IO;


public class BuildAssetBundles2
{
    [MenuItem("test/BuildBundles")]
    public static void Builde()
    {
        
        //AssetImporter.GetAtPath("Assets/GameRes/UI/Common_fui.bytes").assetBundleName = "hhl/hh.ab";
        //AssetImporter.GetAtPath("Assets/GameRes/UI/Login_fui.bytes").assetBundleName = "hhl/hh.ab";
        
        AssetImporter.GetAtPath("Assets/GameRes/prefab/Cube.prefab").assetBundleName = "hl.ab";
        AssetImporter.GetAtPath("Assets/GameRes/prefab/abc.mat").assetBundleName = "hl.ab";
        
        BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath, BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.Android);
        AssetDatabase.Refresh();
    }

}