using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class gamemanage : MonoBehaviour
{

    public Transform play1zm;
    public Transform play2zm;
    public Transform play3zm;
    public Transform play4zm;

    public GameObject paibei;

    public GameObject paizhengman;

    public Transform[] dipaidian;

    private List<GameObject> play1pai = new List<GameObject>();


    private bool kaiguan = false;
    private int num = 0;
    private int num1 = 0;
    private int num2 = 0;
    // Use this for initialization
    void Start()
    {

    }

    //Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space))
        {
            kaiguan = true;
        }
        if (kaiguan == true)
        {

            num++;
            if (num % 30 == 0)
            {
                Play1FaPai();
                // Play2FaPai();
                // Play3FaPai();
                // Play4FaPai();
                print(num);

                num1++;
                print(num1);
                if (num1 == 25)
                {
                    LiuDi();
                    kaiguan = false;

                }
            }
        }
    }

    void Play1FaPai()
    {
        //牌从中心点向play1移动
        print(111);
        Transform tempweizhi = paibei.transform;
        Transform play = GameObject.Find("play1").transform;

        //拿取算好的牌//给play1发牌
        paizhengman.GetComponent<SpriteRenderer>().sprite = rean._intance.play1list[num2].name;

        GameObject peimian = GameObject.Instantiate(paizhengman, tempweizhi.position, tempweizhi.rotation) as GameObject;

        iTween.MoveTo(peimian, play1zm.position, 0.5f);

        peimian.transform.SetParent(play);

        play1pai.Add(peimian);

        num2++;

        //第一张牌不动，其余牌向后移动

        for (int c = 1; c < play1pai.Count; c++)
        {
            iTween.MoveTo(play1pai[c], play1pai[c - 1].transform.position + new Vector3(0.3f, 0, -c / 100f), 0.1f);
        }
    }
    void Play2FaPai()
    {

        Transform tempweizhi = paibei.transform;
        Transform play = GameObject.Find("play2").transform;
        //给play2发牌
        GameObject peimian = GameObject.Instantiate(paibei, tempweizhi.position, tempweizhi.rotation) as GameObject;
        iTween.MoveTo(peimian, play2zm.position, 0.5f);

        peimian.transform.SetParent(play);
    }
    void Play3FaPai()
    {

        Transform tempweizhi = paibei.transform;
        Transform play = GameObject.Find("play3").transform;
        //给play3发牌
        GameObject peimian = GameObject.Instantiate(paibei, tempweizhi.position, tempweizhi.rotation) as GameObject;
        iTween.MoveTo(peimian, play3zm.position, 0.5f);

        peimian.transform.SetParent(play);
    }
    void Play4FaPai()
    {

        Transform tempweizhi = paibei.transform;
        Transform play = GameObject.Find("play4").transform;
        //给play4发牌
        GameObject peimian = GameObject.Instantiate(paibei, tempweizhi.position, tempweizhi.rotation) as GameObject;
        iTween.MoveTo(peimian, play4zm.position, 0.5f);

        peimian.transform.SetParent(play);
    }

    void LiuDi()
    {
        print(1111);
        Transform liudi = GameObject.Find("liudi").transform;


        for (int i = 0; i < dipaidian.Length; i++)
        {
            paizhengman.GetComponent<SpriteRenderer>().sprite = rean._intance.dipailist[i].name;
            GameObject dipai = GameObject.Instantiate(paizhengman, dipaidian[i].position, Quaternion.identity) as GameObject;
            dipai.transform.SetParent(liudi);

        }






    }
}
