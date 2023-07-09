using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ButtonBehaviour : MonoBehaviour
{
    public AudioSource audioSource;

    public abstract void OnClick(MouseController mouseController);
}
