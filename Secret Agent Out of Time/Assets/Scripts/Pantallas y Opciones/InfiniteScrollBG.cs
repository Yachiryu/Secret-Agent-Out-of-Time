using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InfiniteScrollBG : MonoBehaviour
{
    Rect rect;
    [SerializeField] RawImage scrollabeBG; 

    [SerializeField]
    [Range(0.1f,1)] float scrollSpeed;

    [SerializeField] Vector2 directionScroll;
  

    private void Start()
    {
        rect = scrollabeBG.uvRect;
    }
    private void Update()
    {
        rect.x += directionScroll.x * scrollSpeed * Time.deltaTime;
        rect.y += directionScroll.y * scrollSpeed * Time.deltaTime;
        scrollabeBG.uvRect = rect;
    }

}
