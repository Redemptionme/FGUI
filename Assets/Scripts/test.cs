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
    private void Awake()
    {
        //以下是成功的
        // assetbundle方式
        
        // ios "file://{Application.streamingAssetsPath}"
        string str = Path.Combine(Application.streamingAssetsPath, "hh.ab");
        
        
        var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "hl.ab"));
        if (myLoadedAssetBundle == null) {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }
        var prefab = myLoadedAssetBundle.LoadAsset<GameObject>("Cube");
        Instantiate(prefab);
        
        /*
        AssetBundle bundle = AssetBundle.LoadFromFile(str);
        UIPackage.AddPackage(bundle);*/
        // Resouce加载方式
        //UIPackage.AddPackage("Assets/Resources/GameRes/UI/Login");
        UIPackage.AddPackage("GameRes1/UI/Login");
        // 编辑器加载模式
        // UIPackage.AddPackage("Assets/GameRes/UI/Login");
        // LoginBinder.BindAll();
        // var ui = new BaseWindow();
        // Debug.Log("asdf");
        // ui.Show();
        
        //StartCoroutine(LoadUIPackage());
        
        LoginBinder.BindAll();
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
            UIPackage.AddPackage(bundle);
            LoginBinder.BindAll();
            var ui = new BaseWindow();
            Debug.Log("asdf");
            ui.Show();
           
            
        }
        else
            Debug.LogError(www.error);
    }

    // Start is called before the first frame update
    void Start()
    {
        
        
        var ui = new BaseWindow();
        Debug.Log("asdf");
        ui.Show();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
