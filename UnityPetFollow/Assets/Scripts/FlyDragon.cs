using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyDragon : MonoBehaviour
{
    [Header("目標")]
    public Transform target;
    [Header("追蹤速度"), Range(0, 100)]
    public float speed = 5f;

    ////宝宝跟随的目标
    //public Transform target;
    //宝宝跟随目标的偏移量
    public Vector3 offset;
    // Use this for initialization


    private void Track()
    {
        //Vector3 v3A = transform.position;
        //Vector3 v3B = target.position;

        Quaternion r3A = transform.rotation;
        Quaternion r3B = target.rotation;

        ////v3B.z = -10;//必須確保攝影機在場景後才會有畫面
        ////v3B.y = Mathf.Clamp(v3B.y, -2f, 5f);

        ////乘上Time.deltaTime會依據不同平台禎數,做調整速度  
        ////ex: (1/60) * speed * 60(fps) = speed
        ////ex: (1/30) * speed * 30(fps) = speed
        //v3A = Vector3.Lerp(v3A, v3B, 5f * Time.deltaTime);

        //v3A.x = v3B.x;
        //v3A.z = v3B.z - 5;

        ////r3A.y = r3B.y;

        //transform.position = v3A;
        ////transform.rotation = r3A;


        offset = target.forward * -2 + target.up * 2;
        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime);
        transform.rotation = target.rotation;

        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    r3A.y = r3B.y + 0.5f;
        //    transform.rotation = r3A;
        //}



    }

    private void LateUpdate()
    {
        Track();
    }
}
