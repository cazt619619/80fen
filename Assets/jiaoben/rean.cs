using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class rean : MonoBehaviour
{
    public static rean _intance;

    public Sprite[] spritepai;

    List<pai> paijihe1 = new List<pai>();//把MONO删掉才可以
    List<pai> paijihe2 = new List<pai>();
    public List<pai> play1list = new List<pai>();
    public List<pai> play2list = new List<pai>();
    public List<pai> play3list = new List<pai>();
    public List<pai> play4list = new List<pai>();
    public List<pai> dipailist = new List<pai>();

    int i = 0;
    int x = 0;
    void Awake()
    {
        _intance = this;
    }

    void Start()
    {
        PaiName();
        LiPai();
    }

    void PaiName()
    {//从精灵表里把名字抽出来放到LIST中，标记方块=1，红桃=2，,草花=3，黑桃=4，王=5,并按顺序编号，便于进行大小比较
        int num = 0;
        foreach (var item in spritepai)
        {
            if (i % 13 == 0)
            {
                num++;
                if (num == 5)
                {
                    x = 1;
                }
            }
            paijihe1.Add(new pai() { name = item, fenlei = num, bianhao = i, wangpai = x });

            i++;
        }
        print("取完");
        ChouPai();
    }

    void ChouPai()
    {
        print("抽牌");
        i = 1;
        for (int z = 0; z < 54 - 2; z++)
        {
            int r1 = Random.Range(0, paijihe1.Count);

            paijihe2.Add(paijihe1[r1]);

            if (i == 1)
            {
                play1list.Add(paijihe1[r1]);
                paijihe1.Remove(paijihe1[r1]);
            }
            if (i == 2)
            {
                play2list.Add(paijihe1[r1]);
                paijihe1.Remove(paijihe1[r1]);
            }
            if (i == 3)
            {
                play3list.Add(paijihe1[r1]);
                paijihe1.Remove(paijihe1[r1]);
            }
            if (i == 4)
            {
                play4list.Add(paijihe1[r1]);
                paijihe1.Remove(paijihe1[r1]);
                i = 0;
            }

            i++;
        }

        for (int z = 0; z < 2; z++)
        {
            paijihe2.Add(paijihe1[z]);
            dipailist.Add(paijihe1[z]);

        }
        paijihe1.Clear();



        for (int z = 0; z < 54 - 6; z++)
        {
            int r1 = Random.Range(0, paijihe2.Count);

            paijihe1.Add(paijihe2[r1]);

            if (i == 1)
            {
                play1list.Add(paijihe2[r1]);
                paijihe2.Remove(paijihe2[r1]);
            }
            if (i == 2)
            {
                play2list.Add(paijihe2[r1]);
                paijihe2.Remove(paijihe2[r1]);
            }
            if (i == 3)
            {
                play3list.Add(paijihe2[r1]);
                paijihe2.Remove(paijihe2[r1]);
            }
            if (i == 4)
            {
                play4list.Add(paijihe2[r1]);
                paijihe2.Remove(paijihe2[r1]);
                i = 0;
            }

            i++;
        }
        for (int z = 0; z < 6; z++)
        {
            paijihe1.Add(paijihe2[z]);
            dipailist.Add(paijihe2[z]);

        }
        paijihe2.Clear();

        print(play1list.Count);
        print("dipai" + dipailist.Count);

    }

    void LiPai()
    {

        //LIST SORT 多重排序
        play1list.Sort(delegate(pai x, pai y)
        {
            int a = y.wangpai.CompareTo(x.wangpai);
            if (a==0)
            {
                a = y.bianhao.CompareTo(x.bianhao);
            }
            return a;
        });
        
    }
}
