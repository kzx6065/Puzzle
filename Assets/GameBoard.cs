using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBoard : MonoBehaviour
{
    [SerializeField] //private 속성을 보이게 해줌.
    private Sprite[] sprites;
    public Image[] images;

    [ContextMenu ("이미지 배치")]

    void SetImage()
    {
        print("SetImage");
        for(int i = 0; i < sprites.Length; i++)
        {
            images[i].sprite = sprites[i];
        }
    }
}
