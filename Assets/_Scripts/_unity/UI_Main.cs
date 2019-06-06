using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Main : MonoBehaviour
{
    public InputField ipf_map;
    public InputField ipf_mode;
    public InputField ipf_equip;
    public InputField ipf_gold;

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

    public void BuyEquipment()
    {
        int tEquip;
        if (int.TryParse(ipf_equip.text, out tEquip))
        {
            ClientCore.Instance.regBuyEquip(tEquip);
        }
    }

    public void ChangeEquipment()
    {
        int tEquip;
        if (int.TryParse(ipf_equip.text, out tEquip))
        {
            ClientCore.Instance.regChangeEquip(tEquip);
        }
    }
    
    public void GetGold()
    {
        int tGold;
        if (int.TryParse(ipf_gold.text, out tGold))
        {
            ClientCore.Instance.regGetGold(tGold);
        }
    }
    
    public void Logout()
    {
        KBEngine.Event.fireIn("logout");
    }
}
