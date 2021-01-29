using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using FairyGUI;
using GameFramework.FGUI;
using LrsJudgeTools.Login;
using UnityEngine;

public class test : MonoBehaviour
{
    private void Awake()
    {
        //以下是成功的
        // assetbundle方式
        string str = Path.Combine(Application.streamingAssetsPath, "hh.ab");
        
        str =
#if UNITY_ANDROID
            "jar:file://"+Application.dataPath+"!/assets/";
#elif UNITY_IPHONE
            Application.dataPath+"/Raw/";
#elif UNITY_STANDALONE_WIN||UNITY_EDITOR
           "file://" + Application.dataPath + "/StreamingAssets/";
#endif
        
        AssetBundle bundle = AssetBundle.LoadFromFile(str);
        UIPackage.AddPackage(bundle);
        // Resouce加载方式
        //UIPackage.AddPackage("Assets/Resources/GameRes/UI/Login");
        // 编辑器加载模式
        //UIPackage.AddPackage("Assets/GameRes/UI/Login");
        LoginBinder.BindAll();
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
