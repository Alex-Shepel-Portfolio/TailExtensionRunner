using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public bool ChoiceOs { private get; set; }
    private Transform _objPos;
    [SerializeField] private float _movingSpeed;
    private Quaternion LeftOrRight = Quaternion.Euler(20f, 90f, 0f);
    private void Start()
    {
        _objPos = FindObjectOfType<FindPlayer>().FindPlayeAtScener();

    }


    private void Update()
    {

        LeftOrRight = ChoiceOs ? Quaternion.Euler(30f, 60f, 0f) : Quaternion.Euler(30f, -30f, 0f);

        transform.rotation = Quaternion.Lerp(transform.rotation, LeftOrRight, 1.5f * Time.deltaTime);


        Vector3 target;
    
            target = new Vector3()
            {
                x = ChoiceOs ? _objPos.position.x - 8: _objPos.position.x + 8,
                y = this._objPos.position.y + 8,
                z = this._objPos.position.z - 8 ,
            };

        Vector3 pos = Vector3.Lerp(a: this.transform.position, b: target, t: this._movingSpeed * Time.deltaTime);

        this.transform.position = pos;

    }

}
