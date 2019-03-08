using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MatchingBehavior : MonoBehaviour
{
    public Text txt_matching;

    private WaitForSeconds m_wfs = new WaitForSeconds(1f);

    // Use this for initialization
    void Start()
    {
        StartCoroutine(MatchingUI());
    }

    IEnumerator MatchingUI()
    {
        int i = 0;
        while (gameObject.activeSelf)
        {
            i++;
            txt_matching.text = string.Format("Matching{0}", new string(',', i % 3 + 1));
            yield return m_wfs;
        }
    }
}
