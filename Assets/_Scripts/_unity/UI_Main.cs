using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Main : MonoBehaviour
{
    [Range(1, 100)]
    public int tProcess;

    void Update()
    {
        ServerEvents.Instance.UpdateLoadingProgress(tProcess);
    }

    public void StartMatching()
    {
        ServerEvents.StartMatching(0, 0);
    }

    public void Logout()
    {
        KBEngine.Event.fireIn("logout");
    }
}
