using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 게임의 전반적인 상황을 다룸
/// </summary>
public class GameManager
{
    public bool IsGameEnd { get; set; } = false;
    public bool BGMOn { get; set; }
    public bool EffectSoundOn { get; set; }

    public event System.Action<Vector2> onMoveDirChanged;

    public Vector2 MoveDir { get; set; }
}
