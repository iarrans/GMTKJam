using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendButtonBehaviour : ButtonBehaviour
{
    public BlueprintController blueprintController;

    public override void OnClick(MouseController mouseController)
    {
        Debug.Log("Enviamos Blueprint");
        blueprintController.SendBlueprint();
    }

}
