using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTapScript : MonoBehaviour
{
    private int touchIndex;
    
    void Update()
    {      
        GetTouchIndex();
        UpdateTouch();   
    }
    
    public static bool IsPointerOverGameObject(int n)
    {
        PointerEventData pointer = new PointerEventData(EventSystem.current) { position = Input.GetTouch(n).position };
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointer, raycastResults);
        return raycastResults.Count > 0;
    }
    
    void GetTouchIndex()
    {
        touchIndex = -1;
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (IsPointerOverGameObject(i)) continue;
            touchIndex = i;
        }
    }
    
    void UpdateTouch()
    {
        // No touches, so exit.
        if (touchIndex == -1) return; 
    
        if (Input.GetTouch(touchIndex).phase == TouchPhase.Moved)
        {
            // Yeah!!! We have our touch!!!!
            Vector3 touchPosition = Input.GetTouch(touchIndex).position;
        }  
    }
}
