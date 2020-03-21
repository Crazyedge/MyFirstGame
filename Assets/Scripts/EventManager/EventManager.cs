﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 事件管理器
/// </summary>
public class EventManager: BaseManager <EventManager>
{
    private Dictionary<string, UnityAction<object>> EventDic = new Dictionary<string, UnityAction<object>>();
    /// <summary>
    /// 添加事件
    /// </summary>
    /// <param name="name">事件名</param>
    /// <param name="action">事件动作</param>
    public void AddListenner(string name,UnityAction<object> action)
    {
        if (EventDic.ContainsKey(name))
            EventDic[name] += action;
        else
        {
            EventDic.Add(name, action);
            Debug.Log("[事件]添加事件:" + name);
        } 
    }
    /// <summary>
    /// 触发事件
    /// </summary>
    /// <param name="name">事件名</param>
    /// <param name="info">参数</param>
    public void EventTrigger(string name,object info)
    {
        if (EventDic.ContainsKey(name))
        {
            Debug.Log("[事件]触发事件:" + name);
            EventDic[name].Invoke(info);
        }
        else
            Debug.LogError(string.Format("[事件]事件名({0})不存在!", name));
    }
    /// <summary>
    /// 删除事件
    /// </summary>
    /// <param name="name">事件名</param>
    public void RemoveListener(string name)
    {
        if (EventDic.ContainsKey(name))
        {
            EventDic.Remove(name);
            Debug.Log("[事件]删除事件:" + name);
        }
        else
            Debug.LogError(string.Format("[事件]事件名({0})不存在!", name));
    }
}