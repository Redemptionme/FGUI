using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using FairyGUI;
using GameFramework.FGUI;
using LrsJudgeTools.Login;
using UnityEngine;
using UnityEngine.Networking;

public class test : MonoBehaviour
{
    private bool m_bTest = false;
    private void Awake()
    {
        var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "hl.ab"));
        if (myLoadedAssetBundle == null) {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }
        var prefab = myLoadedAssetBundle.LoadAsset<GameObject>("Cube");
        Instantiate(prefab);


        //LoadEditorRes();
        //LoadResource();
        LoadABResSync();
        //LoadABResASync();
    }

    // 编辑器加载
    private void LoadEditorRes()
    {
        UIPackage.AddPackage("Assets/GameRes/UI/Login");
    }
    
    // resource加载
    private void LoadResource()
    {
        UIPackage.AddPackage("GameRes/UI/Login");
    }
    
    // ab包同步加载
    private void LoadABResSync()
    {
        string url = Application.streamingAssetsPath.Replace("\\", "/") + "/hhl/hh.ab";
        // 疑惑不需要加？
        //if (Application.platform != RuntimePlatform.Android)
        //  url = "file:///" + url;
        
        AssetBundle bundle = AssetBundle.LoadFromFile(url);
        UIPackage.AddPackage(bundle,bundle,"assets/gameres/ui/Login_fui.bytes");
    }
    
    // ab包异步加载
    private void LoadABResASync()
    {
        StartCoroutine(LoadUIPackage());
    }


    IEnumerator LoadUIPackage()
    {
        string url = Application.streamingAssetsPath.Replace("\\", "/") + "/hhl/hh.ab";
        if (Application.platform != RuntimePlatform.Android)
            url = "file:///" + url;

#if UNITY_2017_2_OR_NEWER
#if UNITY_2018_1_OR_NEWER
        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(url);
#else
        UnityWebRequest www = UnityWebRequest.GetAssetBundle(url);
#endif
        yield return www.SendWebRequest();

        if (!www.isNetworkError && !www.isHttpError)
        {
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
#else
        WWW www = new WWW(url);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            AssetBundle bundle = www.assetBundle;
#endif
            if (bundle == null)
            {
                Debug.LogWarning("Run Window->Build FairyGUI example Bundles first.");
                yield return 0;
            }
            //UIPackage.AddPackage(bundle);
            UIPackage.AddPackage(bundle,bundle,"assets/gameres/ui/Login_fui.bytes"); 
        }
        else
            Debug.LogError(www.error);
    }

    // Start is called before the first frame update
    void Start()
    {
        
        
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_bTest)
        {
            LoginBinder.BindAll();
            var ui = new BaseWindow();
            Debug.Log("asdf");
            ui.Show();
            m_bTest = true;
        }   
    }
}
