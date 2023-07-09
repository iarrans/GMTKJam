using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopLineButtonBehaviour : ButtonBehaviour
{
    public TopLineElementBehaviour topLineElementBehaviour;

    public MapController mapController;

    public MapGenerator mapGenerator;

    public override void OnClick(MouseController mouseController)
    {
        if(topLineElementBehaviour.map != null) mapController.ChangeMap(topLineElementBehaviour.map, topLineElementBehaviour.lineBehaviour);
    }


}
