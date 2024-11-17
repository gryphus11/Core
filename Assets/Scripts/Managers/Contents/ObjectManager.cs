using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using static Define;

/// <summary>
/// 오브젝트의 스폰, 디스폰을 관리
/// </summary>
public class ObjectManager
{
    public HashSet<BaseController> BaseControllers { get; } = new HashSet<BaseController>();

    public T Spawn<T>(Vector3 position, int templateID = 0, string prefabName = "") where T : BaseController
    {
        System.Type type = typeof(T);

        if (type == typeof(BaseController))
        {
            GameObject go = Managers.Resource.Instantiate("DataTableRef");
            go.transform.position = position;
            BaseController pc = go.GetOrAddComponent<BaseController>();
            //pc.SetInfo(templateID);

            return pc as T;
        }

        return null;
    }

    public void Despawn<T>(T obj) where T : BaseController
    {
        System.Type type = typeof(T);

        if (type == typeof(BaseController))
        {
            BaseControllers.Remove(obj as BaseController);
            Managers.Resource.Destroy(obj.gameObject);
        }
    }

    bool IsWithInCamera(Vector3 pos)
    {
        if (pos.x >= 0 && pos.x <= 1 && pos.y >= 0 && pos.y <= 1)
            return true;
        return false;
    }

    public List<Transform> GetFindMonstersInFanShape(Vector3 origin, Vector3 forward, float radius = 2, float angleRange = 80)
    {
        List<Transform> listMonster = new List<Transform>();
        LayerMask targetLayer = LayerMask.GetMask("Monster", "Boss");
        RaycastHit2D[] _targets = Physics2D.CircleCastAll(origin, radius, Vector2.zero, 0, targetLayer);

        // 타겟중에 부채꼴 안에 있는것만 리스트에 넣는다.
        foreach (RaycastHit2D target in _targets)
        {
            // '타겟-origin 벡터'와 '내 정면 벡터'를 내적
            float dot = Vector3.Dot((target.transform.position - origin).normalized, forward);
            // 두 벡터 모두 단위 벡터이므로 내적 결과에 cos의 역을 취해서 theta를 구함
            float theta = Mathf.Acos(dot);
            // angleRange와 비교하기 위해 degree로 변환
            float degree = Mathf.Rad2Deg * theta;
            // 시야각 판별
            if (degree <= angleRange / 2f)
                listMonster.Add(target.transform);
        }

        return listMonster;
    }

    public void Clear()
    { }
}
