using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draggableObject : MonoBehaviour
{
    bool isDraggable = false;
    public Color newColor = Color.white;

    [SerializeField] private SpriteRenderer spriteRenderer;

    void Start()
    {
        
    }


    void Update()
    {
        spriteRenderer.color = newColor;
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        
        if (isDraggable)
        {
            print(isDraggable);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
        }

    }

    private void OnMouseDown()
    {
        isDraggable = true;
    }
    
    private void OnMouseUp()
    {
        isDraggable = false;
    }
}
