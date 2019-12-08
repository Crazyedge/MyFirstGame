﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UnitMain : MonoBehaviour
{
    private UI ui_script;
    virtual public Shuxing Shuxing { get; set; }
    public float Top_Offset=new float();
    // Start is called before the first frame update
    void Start()
    {
        ui_script = GameObject.Find("/UI").GetComponent<UI>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(gameObject==null)
        //    Debug.Log("null");
        //if (!shuxing.isBeingPlaced)
        //{
        //    ui_script.LockObjectToGround(gameObject, 0f);
        //}
        CheckHp();  //检查HP 为零销毁
    }

    void CheckHp()
    {
        if (Shuxing.Hp <= 0)
        {
            //Qizi.ShuxingList.Remove();
            GameObject.Destroy(gameObject);
        }
    }
}

public abstract class Shuxing
{
    #region 本身属性
    public string Name;
    public uint Hp;
    public uint Attack;
    public uint Attackrange;
    #endregion
    #region 功能属性
    public bool isBeingPlaced;
    public int BelongToWho;
    #endregion
    //public int Burned;
    //public int Frozen;
    //public int Poisoned;
    //public int Vulnerable;
    //public bool Lightsheld;
    //public bool Charge;
    //public bool Assistance;
    //public bool Triumphal;
    //public int Crazy;
    //public bool NoArmour;
    //public bool Combo;

    public Shuxing(uint a, uint b, uint c)
    {
        Hp = a;
        Attack = b;
        Attackrange = c;
    }

    public string GetState()   //显示人物属性
    {
        string content = "属性：";
        content += ("\nHP：" + Hp.ToString());
        content += ("\n攻击力：" + Attack.ToString());
        content += ("\n攻击范围：" + Attackrange.ToString());
        return content;
    }
    private string BoolToString(bool a)
    {
        if (a)
            return "拥有";
        else
            return "无";
    }

}