using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using Unity.VisualScripting;

public class buttonTrigger : MonoBehaviour
{

    

    [field: Header("buttonConfirm")]
    [field: SerializeField] public EventReference confirmSFX {get; private set;}

    [field: Header("buttonBack")]
    [field: SerializeField] public EventReference backSFX {get; private set;}
    public static buttonTrigger Instance {get; private set;}



        public void PlayConfirm()
    {
        RuntimeManager.PlayOneShotAttached(confirmSFX, this.gameObject);
    }
        public void PlayBack()
    {
        RuntimeManager.PlayOneShotAttached(backSFX, this.gameObject);
    }
}
