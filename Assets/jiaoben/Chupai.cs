﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chupai : MonoBehaviour
{
    //层级数
    int targetMask;
    private List<Sprite> spritename = new List<Sprite>();

    // Use this for initialization
    void Start()
    {
        //获得值，自定的层级名
        targetMask = LayerMask.GetMask("play1");
        print(targetMask);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //从摄像机放出一条射线
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //存放射线碰撞到物体的信息
            RaycastHit hitInfo;

            //光线投射判断方法，线，信息，距离，指定的层级，和物体碰撞了，返回true
            if (Physics.Raycast(ray, out hitInfo, 30f, targetMask))
            {
                if (hitInfo.transform.position.y == -3.25f)
                {
                    hitInfo.transform.position = new Vector3(hitInfo.transform.position.x, -3.0f, hitInfo.transform.position.z);
                    spritename.Add(hitInfo.transform.GetComponent<SpriteRenderer>().sprite);
                }
                else
                {
                    hitInfo.transform.position = new Vector3(hitInfo.transform.position.x, -3.25f, hitInfo.transform.position.z);
                    spritename.Remove(hitInfo.transform.GetComponent<SpriteRenderer>().sprite);
                }
            }
        }

    }

    public void MieDiPai() {
        foreach (var item in spritename)
        {
            print(item);
        }
    
    }

}
