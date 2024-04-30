
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System;


public class AudioManager : MonoBehaviour
{
    private List<EventInstance> eventInstances;

    private List<StudioEventEmitter> eventEmitters;

    private EventInstance musicEventInstance;

    public static AudioManager Instance {get; private set;}
 
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one Audio Manager");
        }
        Instance = this;
        eventInstances = new List<EventInstance>();
        eventEmitters = new List<StudioEventEmitter>();
    }

    public void Start(){
        InitializeMusic(FMODevents.Instance.bgm);
    }
    private void InitializeMusic(EventReference musicEventReference){
        musicEventInstance = CreateEventInstance(musicEventReference);
        musicEventInstance.start();
    }

    public EventInstance CreateEventInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        return eventInstance;
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound,worldPos);
    }
}
