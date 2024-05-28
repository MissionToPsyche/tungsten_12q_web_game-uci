using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
public class rockSound : MonoBehaviour
{
    // Start is called before the first frame update
    private EventInstance playerMoveSound;

    public Rigidbody2D rb;
    void Start()
    {
        playerMoveSound = AudioManager.Instance.CreateEventInstance(FMODevents.Instance.moveSound);
    }

    private void UpdateSound(){
        if (rb.velocity.x !=0){
            PLAYBACK_STATE playbackState;
            playerMoveSound.getPlaybackState(out playbackState);
            if (playbackState.Equals(PLAYBACK_STATE.STOPPED)){
                playerMoveSound.start();
            }
        }
        else{
            playerMoveSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }

    private void FixedUpdate()
        {
            UpdateSound();
            //Movement speed of sprite
            
        }
}
