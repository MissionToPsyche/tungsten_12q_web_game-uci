using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using Unity.VisualScripting;
using UnityEngine;

public class FMODevents : MonoBehaviour
{
    // Start is called before the first frame update
    [field: Header("Music")]
    [field: SerializeField] public EventReference bgm {get; private set;}

    [field: Header("PlayerMovement")]
    [field: SerializeField] public EventReference jumpSound {get; private set;}

    [field: SerializeField] public EventReference moveSound {get; private set;}
    public static FMODevents Instance {get; private set;}
    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one FMODEvent");
        }
        Instance = this;
    }

}
