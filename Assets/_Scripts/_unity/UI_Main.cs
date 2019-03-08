using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Main : MonoBehaviour
{
    public void StartMatching()
    {
        ServerEvents.StartMatching(0, 0);
    }
}
