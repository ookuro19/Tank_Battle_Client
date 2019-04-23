using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    private float moveSpeed = 7f;
    private float rotateSpeed = 7f;

    private Vector3 centerPos;
    private Vector3 randomPoint;
    private Vector3 destination;

    private Vector3 nextForward;
    private bool isRandomE;

    RaycastHit hitResult;

    void Start()
    {
        centerPos = GameObject.Find("CenterPos").transform.position;
        destination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CreateRandomPoint();
        CurveSwim();
    }

    //判断当前目标点及生成下一个随机目标点
    void CreateRandomPoint()
    {
        if (Vector3.Distance(destination, transform.position) < 0.3f)
        {
            randomPoint = new Vector3(centerPos.x + Random.Range(-45f, 45f), transform.position.y, centerPos.z + Random.Range(-45f, 45f));
            destination = randomPoint;
            isRandomE = true;
            // Debug.LogFormat("destination is : {0}", destination);
        }
        nextForward = destination - transform.position;
        // Debug.LogFormat("nextForward is : {0}", nextForward);
    }

    //曲线游动路径
    void CurveSwim()
    {
        // if (isRandomE)
        // {
        //     nextForward = Quaternion.Euler(Random.Range(-45f, 45f), 0, Random.Range(-45f, 45f)) * nextForward;
        //     nextForward.y = transform.position.y;

        //     isRandomE = false;
        // }
        transform.forward = Vector3.Lerp(transform.forward, nextForward, rotateSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        // Debug.LogFormat("forward is : ({0},{1},{2})", transform.forward.x, transform.forward.y, transform.forward.z);
    }

}
