using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public Map activeMap;
    public MapGenerator mapGenerator;
    public Canvas tableCanvas;
    public Canvas reserveCanvas;

    // Start is called before the first frame update
    public void ChangeMap(Map newMap)
    {
        if (activeMap != null)
        {
            SetMapParent(reserveCanvas, activeMap);
        }
        SetMapParent(tableCanvas, newMap);
        activeMap = newMap;
    }

    public void SetMapParent(Canvas parent, Map map)
    {
        map.blueprint.transform.SetParent(parent.transform);
        map.blueprint.GetComponentInChildren<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, parent.GetComponent<RectTransform>().sizeDelta.x);
        map.blueprint.GetComponentInChildren<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, parent.GetComponent<RectTransform>().sizeDelta.y);
        map.blueprint.GetComponent<RectTransform>().localPosition = Vector3.zero;
    }

}