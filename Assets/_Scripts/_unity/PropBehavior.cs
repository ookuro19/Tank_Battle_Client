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
    }

    [Tooltip("道具类型")]
    public EPropType _propType;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            ServerEvents.Instance.GetProps((int)_propType);
            gameObject.SetActive(false);
        }
    }
}
