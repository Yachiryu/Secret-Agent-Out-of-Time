using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovientoMenu : MonoBehaviour
{
    [SerializeField] 
    private float intensidadM;

    private float mouseX;
    private float mouseY;

    void Update()
    {
        mouseX = Input.mousePosition.x;
        mouseY = Input.mousePosition.y;

        this.GetComponent<RectTransform>().position = new Vector2(
            (mouseX/Screen.width) * intensidadM + (Screen.width/2),
            (mouseY/Screen.height) * intensidadM + (Screen.height/2));
    }
}
