using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopLineElementBehaviour : LineElementBehaviour
{
    public Map map;

    public void ChangeMap(Map map)
    {
        this.map = map;
    }
}
