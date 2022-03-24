using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private Camera _camera;
    private Hvost _score;
   
    private void Start()
    {
        _score = FindObjectOfType<Hvost>();
         _camera = Camera.main;
    }

    void Update()
    {
        _scoreText.text = _score.circleHvost.Count.ToString();
        Vector3 pos = _score.playerPos.position + new Vector3(0f, 0.5f, 0f);
        pos = _camera.WorldToScreenPoint(pos);
        pos.z = 0f;
        _scoreText.transform.position = pos;
       
    }

    
}
