using System.Collections;
using UnityEngine;
using TMPro;

public class Plata : MonoBehaviour
{
    public TextMeshProUGUI plataScore;

    private FollovPath _speedCash;
    public Hvost Hvost;
    public int costProezda = 5;
    private bool _work;

    private void Start()
    {
        Hvost = FindObjectOfType<Hvost>();
        _speedCash = FindObjectOfType<FollovPath>();
       
    }
    private void Update()
    {
        plataScore.text = costProezda.ToString();
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.GetComponent<PlayerControl>()) 
        {
            _work = true;
            _speedCash.Speed = 0;
            StartCoroutine(dest());



        }  
    }
    void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.collider.GetComponent<PlayerControl>())
        {
            _work = false;
            _speedCash.Speed = 10;
            StopCoroutine(dest());
         

        }
    }
    IEnumerator dest()
    {
       
        while (_work)
        {
            if (costProezda > 0)
            {
                Hvost.DestroyHvost();
                costProezda--;
            }
            else
            {
                StopCoroutine(dest());
                _speedCash.Speed = 10;
                Destroy(gameObject);
            }

            yield return new WaitForSeconds(0.1f);
        }
        
    }
   
}
