using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSetter : MonoBehaviour
{
    [ContextMenu("이미지 랜덤한 위치에 배치")]
    
    public void SetRandomPosition()
    {
        var allChildImage = transform.GetComponentsInChildren<Image>();

        foreach (var childImage in allChildImage)
        {
            if (childImage.transform == transform) continue;

            childImage.transform.position = new Vector3(
                Random.Range(0, Camera.main.pixelWidth),
                Random.Range(0, Camera.main.pixelHeight),
                0);
        }
    }
}
