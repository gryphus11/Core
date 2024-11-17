using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Define
{
    public enum UIEvent
    {
        Click,
        Pressed,
        PointerDown,
        PointerUp,
        BeginDrag,
        Drag,
        EndDrag,
    }


    public enum SceneType
    {
        Unknown,
        Title,
        Lobby,
        Game,
    }

    public enum Sound
    {
        Bgm,
        SubBgm,
        Effect,
        MaxCount,
    }

    public enum ObjectType
    {
        Unknown,
        Player,
        Monster,
    }

    #region sortingOrder
    public static readonly int UI_GAMESCENE_SORT_CLOSED = 321;
    public static readonly int DROP_SORT = 105;

    public static readonly int UI_GAMESCENE_SORT_OPEN = 323;
    public static readonly int DROP_GETITEM_SORT = 322;
    #endregion
}
