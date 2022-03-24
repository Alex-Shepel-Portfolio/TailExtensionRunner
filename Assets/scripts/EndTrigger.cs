
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManeger gameManeger;

    void OnTriggerEnter()
    {

        gameManeger.CompleteLevl(); 

    }

}
