using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class picUpObj : MonoBehaviour
{

    private Transform PlayerPos;
    [SerializeField] private float movingSpeed;
    bool pickUp = false;
    public GameObject GuidesPoint;
    public List<GameObject> GuidesPoints = new List<GameObject>();
    public float spaceBtwPoint;

    private void Start()
    {
        
        GuidesPoints.Add(this.gameObject);
        PlayerPos = FindObjectOfType<FindPlayer>().FindPlayeAtScener(); 
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "hvost")
        {

            pickUp = true;
                GuidesPoints.Add(collisionInfo.gameObject);
            collisionInfo.gameObject.transform.position = PlayerPos.position;


        }
    }
    private void Update()
    {
        if (pickUp)
        {
            for (int i = 0; i < GuidesPoints.Count; i++)
            {
                GuidesPoints[i].transform.position = PointPosition(i * spaceBtwPoint, i);
            }
        }
    }

    
    Vector3 PointPosition(float t, int i)
    {
        
        Vector3 target = new Vector3()
        {
            x = this.PlayerPos.position.x,
            y = this.PlayerPos.position.y,
            z = this.PlayerPos.position.z - t,
        };

        Vector3 position = Vector3.Lerp(a: GuidesPoints[i].transform.position, b: target, t: 20*i * Time.deltaTime );
      
        return position;
    }
}
//это можно использовать для толпы и игратьтся с расположением и будет автоматом сетка
//Vector3 PointPosition(float t, int i)
//{

//    Vector3 target = new Vector3()
//    {
//        x = this.PlayerPos.position.x,
//        y = this.PlayerPos.position.y,
//        z = this.PlayerPos.position.z - t,
//    };

//    Vector3 position = Vector3.Lerp(a: GuidesPoints[i].transform.position, b: target, t: 20 * i * Time.deltaTime);

//    return position;
//}