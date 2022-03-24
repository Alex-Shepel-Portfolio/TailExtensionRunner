using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public bool controlOsZ { private get; set; }
  
    void Update()
    {
        if (controlOsZ) { transform.rotation = Quaternion.Euler(0f, 90f, 0f); } else transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += transform.right * 5 * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += -transform.right * 5 * Time.deltaTime;
        }

        if (transform.position.y < -3f)
        {
            FindObjectOfType<GameManeger>().EndGame();
        }

    }
}
