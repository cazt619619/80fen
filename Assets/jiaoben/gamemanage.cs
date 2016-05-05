using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class gamemanage : MonoBehaviour
{

    public Transform play1zm;
    public Transform play2zm;
    public Transform play3zm;
    public Transform play4zm;

    public GameObject paibei;

    public GameObject paizhengman;

    public GameObject root;

    public Text daojishi;
    public Text daji;

    public Transform[] dipaidian;

    private List<GameObject> play1pai = new List<GameObject>();


    private bool kaiguan1 = false;
    private bool kaiguan2 = false;
    private bool kaiguan3 = false;

    private int num = 0;
    private int num1 = 0;
    private int num2 = 0;
    private int numtime = 0;
    private int timer = 10;


    // Use this for initialization
    void Start()
    {
        daojishi.GetComponent<Text>().enabled = false;

        daji.GetComponent<Text>().text = rean._intance.dajihao.ToString();

        root = GameObject.Find("Canvas");

    }

    //Update is called once per frame
    void Update()
    {

        if (kaiguan1 == true)
        {
            num++;
            if (num % 30 == 0)
            {
                QuPai();

                num1++;
                if (num1 == rean._intance.play1list.Count)
                {
                    kaiguan1 = false;
                    kaiguan2 = true;
                    num = num1 = 0;
                    daojishi.GetComponent<Text>().enabled = true;
                }
            }
        }

        if (kaiguan2 == true)
        {
            JiShiQi();
            if (timer == 0)
            {
                QinLiZuoMian();
                daojishi.GetComponent<Text>().enabled = false;
                kaiguan2 = false;
                kaiguan3 = true;
            }
        }

        if (kaiguan3 == true)
        {
            num++;
            if (num % 30 == 0)
            {
                LiPai();

                num1++;

                if (num1 == rean._intance.play1list.Count)
                {

                    kaiguan3 = false;
                }
            }

        }
    }

    public void KaiShi()
    {

        kaiguan1 = true;

        GameObject.Find("kaishi").SetActive(false);
        //一个奇怪的显示方式
        //GameObject root = GameObject.Find("Canvas");
        GameObject map = root.transform.Find("chupai").gameObject;
        map.SetActive(true);



    }

    void QuPai()
    {
        Vector3 t0 = new Vector3(0, 0, 0);

        paizhengman.GetComponent<SpriteRenderer>().sprite = rean._intance.play1list[num2].name;

        if (rean._intance.play1list[num2].wangpai == 1)
        {
            JiaoZhuButton(rean._intance.play1list[num2].fenlei);
        }

        Vector3 t1 = play1zm.position;

        FaPai(t0, t1);

        play1zm.position = play1zm.position + new Vector3(0.3f, 0, -0.01f);

        num2++;


    }

    void FaPai(Vector3 t0, Vector3 t1)
    {
        Transform p1 = GameObject.Find("play1").transform;

        GameObject peimian = GameObject.Instantiate(paizhengman, t0, Quaternion.identity) as GameObject;

        peimian.transform.SetParent(p1);

        iTween.MoveTo(peimian, t1, 0.3f);

        play1pai.Add(peimian);

    }

    void LiPai()
    {
        num2--;

        print("num2 : " + num2);

        if (num2 < 0)
        {
            num2 = 0;
        }

        rean._intance.PaiXu();

        Vector3 t0 = play1zm.position;

        paizhengman.GetComponent<SpriteRenderer>().sprite = rean._intance.play1list[num2].name;

        Vector3 t1 = play1zm.position;

        FaPai(t0, t1);

        play1zm.position = play1zm.position - new Vector3(0.3f, 0, -0.01f);

    }


    void QinLiZuoMian()
    {


        foreach (var item in play1pai)
        {
            Destroy(item);
        }

        Destroy(GameObject.Find("liudi"));
    }

    void LiuDi()
    {

        Transform liudi = GameObject.Find("liudi").transform;

        for (int i = 0; i < dipaidian.Length; i++)
        {
            paizhengman.GetComponent<SpriteRenderer>().sprite = rean._intance.dipailist[i].name;
            GameObject dipai = GameObject.Instantiate(paizhengman, dipaidian[i].position, Quaternion.identity) as GameObject;
            dipai.transform.SetParent(liudi);
        }
    }

    void JiaoZhuButton(int num)
    {
        switch (num)
        {
            case 1:
                GameObject t1 = root.transform.Find("fangkuai").gameObject;
                t1.SetActive(true);
                break;
            case 2:
                GameObject t2 = root.transform.Find("caohua").gameObject;
                t2.SetActive(true);
                break;
            case 3:
                GameObject t3 = root.transform.Find("hongtao").gameObject;
                t3.SetActive(true);
                break;
            case 4:
                GameObject t4 = root.transform.Find("heitao").gameObject;
                t4.SetActive(true);
                break;
            case 5:
                GameObject t5 = root.transform.Find("wujiang").gameObject;
                t5.SetActive(true);
                break;
        }
    }


    public void FangKuaiButton() { 
    
    }



    void JiShiQi()
    {
        numtime++;
        paibei.SetActive(false);
        if (numtime % 60 == 0)
        {
            timer--;
            daojishi.GetComponent<Text>().text = timer.ToString();
            LiuDi();
        }

    }
}
