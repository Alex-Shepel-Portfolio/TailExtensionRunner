using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hvost : MonoBehaviour
{
    private FollovPath _speedCash;
    public Transform playerPos;
    public float Diametr,Timer = 2f;
    int plusPoint = 0, minusPoint = 0;

    public List<Transform> circleHvost = new List<Transform>();
    public List<Vector3> positiomList = new List<Vector3>();

    public GameObject[] startHvost;

   public  bool kill = false;


    private void Start()
    {
        _speedCash = FindObjectOfType<FollovPath>();
        positiomList.Add(playerPos.position);
        addStart();

    }

   private void Update()
    {
        Timer = Timer - 1 * Time.deltaTime;

        if (Timer < 0)
        {
            Timer = 2f;
            plusPoint = 0;
            minusPoint = 0;
        }
        float distance = ((Vector3)playerPos.position - positiomList[0]).magnitude;
        if(distance > Diametr)
        {
            Vector3 direction = ((Vector3)playerPos.position - positiomList[0]).normalized;
            positiomList.Insert(0, positiomList[0] + direction * Diametr);
            positiomList.RemoveAt(positiomList.Count - 1);

            distance -= Diametr;
        }
        for(int i = 0; i < circleHvost.Count; i++)
        {
            circleHvost[i].position = Vector3.Lerp(positiomList[i + 1], positiomList[i], distance / Diametr);
        }
        
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        
        if (collisionInfo.collider.tag == "Hvost")
        {
           
            plusPoint++;
            PointScore.Instance.AddText(plusPoint, gameObject.transform.position);

            collisionInfo.collider.isTrigger = true;
            collisionInfo.gameObject.transform.position = positiomList[positiomList.Count -1];
            circleHvost.Add(collisionInfo.transform);
            positiomList.Add(collisionInfo.transform.position); 

        }

        if (collisionInfo.collider.tag == "Enemy")
        {
           
            kill = true;
            _speedCash.Speed = 0;
            StartCoroutine(dest());
        }

    }

  
    void OnCollisionExit(Collision collisionInfo)
    {

        if (collisionInfo.collider.tag == "Enemy")
        {
            kill = false;
            _speedCash.Speed = 10;
            StopCoroutine(dest());
            
        }
    }
    

    IEnumerator dest()
    {
        while (kill)
        {
            minusPoint--;
            PointScore.Instance.AddText(minusPoint, gameObject.transform.position);
            DestroyHvost();

            yield return new WaitForSeconds(0.1f);
        }
          
    }

    public  void DestroyHvost()
    {
        if (circleHvost.Count > 1)
        {
            Destroy(circleHvost[0].gameObject);
            circleHvost.RemoveAt(0);
            positiomList.RemoveAt(1);
            
        }
        else
        {
            FindObjectOfType<GameManeger>().EndGame();
        }
    }

    private void addStart()
    {
        for(int i = 0; i < startHvost.Length; i++)
        {
            
            startHvost[i].transform.position = positiomList[positiomList.Count - 1];
            circleHvost.Add(startHvost[i].transform);
            positiomList.Add(startHvost[i].transform.position);
        }
        
    }


    
}
