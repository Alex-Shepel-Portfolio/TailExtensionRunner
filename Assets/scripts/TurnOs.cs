using UnityEngine;

public class TurnOs : MonoBehaviour
{
    public bool leftOrRight;
    PlayerControl choiseOs;
    CameraFollow camchoice;
    private void Awake()
    {
        choiseOs = FindObjectOfType<PlayerControl>();
        camchoice = FindObjectOfType<CameraFollow>();
    }

    
    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.tag == "Player")
        {
            choiseOs.controlOsZ = leftOrRight;
            camchoice.ChoiceOs = leftOrRight;
        }
    }
}
