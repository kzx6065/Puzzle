using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSetter : MonoBehaviour
{
    [ContextMenu("이미지 랜덤한 위치에 배치")]
    
    void SetRandomPosition()
    {
        var allChildImage = transform.GetComponentsInChildren<Image>();

    }
}
