using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopLineButtonBehaviour : ButtonBehaviour
{
    public TopLineElementBehaviour topLineElementBehaviour;

    public MapController mapController;

    public MapGenerator mapGenerator;

    private void Start()
    {
       topLineElementBehaviour.map = mapGenerator.GenerateMap();
    }

    public override void OnClick(MouseController mouseController)
    {
        Debug.Log(mapController);
        Debug.Log(topLineElementBehaviour);
        mapController.ChangeMap(topLineElementBehaviour.map);
    }


}
