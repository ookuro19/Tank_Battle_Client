/*
 * @Description: 道具行为
 * @Author: ookuro19 
 * @Date: 2019-03-19 11:55:35 
 * @Last Modified by: ookuro19
 * @Last Modified time: 2019-03-19 15:03:08
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropBehavior : MonoBehaviour
{
    void Awake()
    {
        Props2Pydata.AppendProps(gameObject.name, transform.position, (int)_propType);

        Color tColor = Color.white;

        switch (_propType)
        {
            case EPropType.ePT_Bullet:
                {
                    tColor = Color.red;
                    break;
                }
            case EPropType.ePT_Shell:
                {
                    tColor = Color.green;
                    break;
                }
            case EPropType.ePT_Mine:
                {
                    tColor = Color.yellow;
                    break;
                }
            default:
                {
                    break;
                }
        }
        gameObject.GetComponentInChildren<MeshRenderer>().material.color = tColor;
        ClientCore.g_propDict[gameObject.name] = this;
    }

    [Tooltip("道具类型")]
    public EPropType _propType;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            ServerEvents.Instance.GetProps(gameObject.name, (int)_propType);
            gameObject.SetActive(false);
        }
    }

    public void DisableProp()
    {
        gameObject.SetActive(false);
    }

    public void ResetProp()
    {
        gameObject.SetActive(true);
    }
}
