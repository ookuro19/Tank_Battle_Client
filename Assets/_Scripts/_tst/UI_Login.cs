using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KBEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_Login : MonoBehaviour
{
    public InputField ipt_account;
    public InputField ipt_pwd;
    private string stringAccount = "";
    private string stringPasswd = "";

    // Use this for initialization
    void Start()
    {
        installEvents();
        // List<int> tlist = new List<int>() { 1, 4, 8, 3, 2 };
        // tlist.Sort((x, y) =>x.CompareTo(y));
        // for (int i = 0; i < tlist.Count; i++)
        // {
        //     Debug.LogError(string.Format("tlist[{0}] is {1}", i, tlist[i]));
        // }
    }

    #region KBEngine
    void installEvents()
    {
        // common
        KBEngine.Event.registerOut("onConnectionState", this, "onConnectionState");

        // login
        KBEngine.Event.registerOut("onLoginFailed", this, "onLoginFailed");
        KBEngine.Event.registerOut("onLoginSuccessfully", this, "onLoginSuccessfully");
        KBEngine.Event.registerOut("onLoginSuccessfully", this, "onLoginSuccessfully");
    }

    public void onConnectionState(bool success)
    {
        if (!success)
            Debug.LogError("connect(" + KBEngineApp.app.getInitArgs().ip + ":" + KBEngineApp.app.getInitArgs().port + ") is error! (连接错误)");
        else
            Debug.Log("connect successfully, please wait...(连接成功，请等候...)");
    }

    public void onLoginFailed(UInt16 failedcode)
    {
        if (failedcode == 20)
        {
            Debug.LogError("login is failed(登陆失败), err=" + KBEngineApp.app.serverErr(failedcode) + ", " + System.Text.Encoding.ASCII.GetString(KBEngineApp.app.serverdatas()));
        }
        else
        {
            Debug.LogError("login is failed(登陆失败), err=" + KBEngineApp.app.serverErr(failedcode));
        }
    }

    public void login()
    {
        stringAccount = ipt_account.text;
        stringPasswd = ipt_pwd.text;

        Debug.Log("connect to server...(连接到服务端...)");
        KBEngine.Event.fireIn("login", stringAccount, stringPasswd, System.Text.Encoding.UTF8.GetBytes("kbengine_unity3d_demo"));
    }

    public void onLoginSuccessfully(UInt64 rndUUID, Int32 eid, Account accountEntity)
    {
        Debug.Log("login is successfully!(登陆成功!)");
        SceneManager.LoadScene("Room");
    }
    #endregion
}
