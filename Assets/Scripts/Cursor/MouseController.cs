using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public DungeonItem item;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckRaycast();
        }
    }

    private void CheckRaycast()
    {
        // Raycast to check the clicked object
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            GameObject objectHit = hit.transform.gameObject;
            if (objectHit.tag == "button")
            {
                objectHit.GetComponent<ButtonBehaviour>().OnClick(this);
            }
            else
            {
                Debug.Log("No button clicked");
            }
        }
       
    }


}
