using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIManager
{
    UI_Base _sceneUI;

    Stack<UI_Base> _uiStack = new Stack<UI_Base>();

    public T GetSceneUI<T>() where T : UI_Base
    {
        return _sceneUI as T;
    }

    public T ShowSceneUI<T>() where T : UI_Base
    {
        if (_sceneUI != null)
        {
            return GetSceneUI<T>();
        }

        string key = $"{typeof(T).Name}.prefab";
        _sceneUI = Managers.Resource.Instantiate(key, pooling: true).GetOrAddComponent<T>();
        return _sceneUI as T;
    }

    public T ShowPopup<T>() where T : UI_Base
    {
        string key = $"{typeof(T).Name}.prefab";
        var ui = Managers.Resource.Instantiate(key, pooling: true).GetOrAddComponent<T>();
        _uiStack.Push(ui);
        RefreshTimeScale();
        return ui;
    }

    public T FindPopup<T>() where T : UI_Base
    {
        return _uiStack.Where(x => x.GetType() == typeof(T)).FirstOrDefault() as T;
    }

    public T PeekPopupUI<T>() where T : UI_Base
    {
        if (_uiStack.Count == 0)
            return null;

        return _uiStack.Peek() as T;
    }

    public void ClosePopup(UI_Base popup)
    {
        if (_uiStack.Count == 0)
            return;

        if (_uiStack.Peek() != popup)
        {
            Debug.Log("Close Popup Failed");
            return;
        }

        ClosePopup();
    }

    public void ClosePopup()
    {
        if (_uiStack.Count == 0)
            return;

        var ui = _uiStack.Pop();
        Managers.Resource.Destroy(ui.gameObject);
        ui = null;
        RefreshTimeScale();
    }

    public void CloseAllPopup()
    {
        while (_uiStack.Count > 0)
            ClosePopup();
    }

    public void Clear()
    {
        CloseAllPopup();
        _sceneUI = null;
    }


    public void RefreshTimeScale()
    { 
        if(_uiStack.Count > 0)
            Time.timeScale = 0.0f;
        else
            Time.timeScale = 1.0f;
    }
}
