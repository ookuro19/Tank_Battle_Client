using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerRoomItem : MonoBehaviour
{
    public GameObject m_icon;
    public Slider sld_progress;
    public Text txt_name;

    public TankManager m_tankManager = null;

    // Update is called once per frame
    void Update()
    {
        if (m_tankManager != null)
        {
            if (m_tankManager.GetProgress() > 0)
            {
                sld_progress.gameObject.SetActive(true);
                sld_progress.value = m_tankManager.GetProgress() / 100f;
            }
        }
    }

    public void SetItem(TankManager tTankManager)
    {
        m_icon.SetActive(true);
        m_tankManager = tTankManager;
        txt_name.text = tTankManager.m_avatarName;
    }

    public void Reset()
    {
        m_icon.SetActive(false);
        sld_progress.gameObject.SetActive(false);
        sld_progress.value = 0f;
    }
}
