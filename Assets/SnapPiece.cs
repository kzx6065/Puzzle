using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SnapPiece : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Debug.Log("Dopped object was: " + eventData.pointerDrag);
            eventData.pointerDrag.transform.position = transform.position;

            //제대로 된 위치에 드랍되었다면 번쩍이게 함.
            if (IsRightPosition(eventData.pointerDrag))
            {
                setBlink(eventData.pointerDrag);
            }
        }
    }

    private bool IsRightPosition(GameObject pointerDrag)
    {
        return pointerDrag.name == name;
    }

    private void setBlink(GameObject pointerDrag)
    {
        //방식 1 코루틴
        //StartCoroutine(setBlinkCo(pointerDrag)); // 함수로 실행하는 방식 -> 추천
        //StartCoroutine("setBlinkCo", pointerEnter); //이름으로 실행하는 방식

        //방식 2 애니메이터
        pointerDrag.GetComponent<Animator>().SetTrigger("Blink");
        
    }

    private IEnumerator setBlinkCo(GameObject pointerDrag)
    {
        pointerDrag.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        pointerDrag.GetComponent<Image>().color = Color.white;
    }


}
