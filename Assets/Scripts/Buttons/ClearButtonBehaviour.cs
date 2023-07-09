using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearButtonBehaviour : ButtonBehaviour
{
    public BlueprintController blueprintController;

    public override void OnClick(MouseController mouseController)
    {
        audioSource.Play();
        blueprintController.ClearBlueprint();
    }
}
