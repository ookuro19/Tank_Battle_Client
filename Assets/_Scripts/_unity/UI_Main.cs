using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Main : MonoBehaviour
{
    public InputField ipf_map;
    public InputField ipf_mode;

    public void StartQuickMatching()
    {
        ServerEvents.StartMatching(-1, -1, -1);
    }

    public void StartCustomMatching()
    {
        int tMap;
        int tMode;
        if (int.TryParse(ipf_map.text, out tMap) && int.TryParse(ipf_mode.text, out tMode))
        {
            ServerEvents.StartMatching(tMap, tMode, 0);
        }
        else
        {
            Debug.LogErrorFormat("参数错误");
        }
    }

    public void Logout()
    {
        KBEngine.Event.fireIn("logout");
    }
}
