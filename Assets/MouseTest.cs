using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTest : MonoBehaviour
{
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
