using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KBEngine;
using UnityEngine.UI;
public class UI_Login : MonoBehaviour
{
    public InputField ipt_account;
    public InputField ipt_pwd;
    private string stringAccount = "";
    private string stringPasswd = "";

    public void login()
    {
        stringAccount = ipt_account.text;
        stringPasswd = ipt_pwd.text;

#if !UNITY_EDITOR
        if (stringAccount == "")
        {
            stringAccount = "123";
            stringPasswd = "123123";
        }
#endif

        Debug.Log("connect to server...(连接到服务端...)");
        ServerEvents.Instance.PlayerLogin(stringAccount, stringPasswd);
    }
}
