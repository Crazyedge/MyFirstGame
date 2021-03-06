﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    public _debug _Debug;
    public GridSystem GridSystem;
    public MonoManager MonoManager;
    private void Awake()
    {
        GameObject obj = new GameObject();
        obj.name = "MonoManager";
        obj.transform.parent = gameObject.transform;
        MonoManager = obj.AddComponent<MonoManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        EventManager.Getinstance().AddListener<object>("Game_OnStart", OnGameStart);
        EventManager.Getinstance().EventTrigger("Game_OnStart");
        EventManager.Getinstance().AddListener<CubeCell>("Grid_OnSelected",UI_Units.Getinstance().CellSelected);
    }
    void OnGameStart(object info)
    {
        Debug.Log("[消息]游戏开始");
        RoundSystem.Getinstance().Init(GameObject.Find("UI/Canvas/HUD/RoundsPanel/Text").GetComponent<UnityEngine.UI.Text>(),1);
        UIManager.Getinstance().Init();
        AudioManager.Getinstance().PlayBGM("1");
        AudioManager.Getinstance().PlaySound("GameMain/GameStart",0.1f);
        UIManager.Getinstance().MsgOnScreen("游戏开始啦!");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public GameMain()
    {
        TheGame.Getinstance().SetGameMain(this);
    }
}
public class TheGame : BaseManager<TheGame>
{
    private GameMain gameMain;
    public GameMain GameMain { get { return gameMain; } }
    public _debug Debug()
    {
        return gameMain._Debug;
    }
    public void SetGameMain(GameMain _gameMain)
    {
        gameMain = _gameMain;
    }
}