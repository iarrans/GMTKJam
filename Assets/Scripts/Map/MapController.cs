using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public Map activeMap;
    public LineBehaviour lineBehaviour;
    public MapGenerator mapGenerator;
    public Canvas tableCanvas;
    public Canvas reserveCanvas;

    public void ChangeMap(Map newMap, LineBehaviour lineBehaviour)
    {
        if (activeMap != null)
        {
            SetMapParent(reserveCanvas, activeMap);
        }
        if(newMap != null) SetMapParent(tableCanvas, newMap);
        activeMap = newMap;
        if (this.lineBehaviour != null) this.lineBehaviour.OnNoFocusLine();
        lineBehaviour.OnFocusLine();
        this.lineBehaviour = lineBehaviour;
    }

    public void SetMapParent(Canvas parent, Map map)
    {
        map.blueprint.transform.SetParent(parent.transform);
        map.blueprint.GetComponentInChildren<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, parent.GetComponent<RectTransform>().sizeDelta.x);
        map.blueprint.GetComponentInChildren<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, parent.GetComponent<RectTransform>().sizeDelta.y);
        map.blueprint.GetComponent<RectTransform>().localPosition = Vector3.zero;
    }

}