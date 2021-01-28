using System;
using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using GameFramework.FGUI;
using LrsJudgeTools.Login;
using UnityEngine;

public class test : MonoBehaviour
{
    private void Awake()
    {
        UIPackage.AddPackage("Assets/Resources/GameRes/UI/Login");
        LoginBinder.BindAll();
    }

    // Start is called before the first frame update
    void Start()
    {
        var ui = new BaseWindow();
        ui.Show();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
