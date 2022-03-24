
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointScore : MonoBehaviour
{
    private class ActiveText
    {
        //public Text UIText;
        public TextMeshProUGUI UIText;
        public float maxTime;
        public float Timer;
        public Vector3 PlayerPos;

        public void MoveTExt(Camera camera)
        {
            float delta = 1.0f / (Timer / maxTime);
            Vector3 pos = PlayerPos + new Vector3(delta, delta, 0f);
            pos = camera.WorldToScreenPoint(pos);
            pos.z = 0f;
            UIText.transform.position = pos;
        }

        
    }
   
    public static PointScore Instance { get; private set; }

    //public Text m_TextScore;
    public TextMeshProUGUI m_TextScore; 
    const int POOL_SIZE = 10;

    //Queue<Text> m_TextPool = new Queue<Text>();
    Queue<TextMeshProUGUI> m_TextPool = new Queue<TextMeshProUGUI>();
    List<ActiveText> m_ActiveText = new List<ActiveText>();
   

    Camera m_Camera;
    Transform m_Transform;


    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_Camera = Camera.main;
        m_Transform = transform;


     

        for (int i = 0; i < POOL_SIZE; i++)
        {
            TextMeshProUGUI temp = Instantiate(m_TextScore, m_Transform);
            temp.gameObject.SetActive(false);
            m_TextPool.Enqueue(temp);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < m_ActiveText.Count; i++)
        {
            ActiveText at = m_ActiveText[i];
            at.Timer -= Time.deltaTime;

            if (at.Timer <= 0.0f)
            {
                at.UIText.gameObject.SetActive(true);
                m_TextPool.Enqueue(at.UIText);
                m_ActiveText.RemoveAt(i);
            }
            else
            {
                var color = at.UIText.color;
                color.a = at.Timer / at.maxTime;
                at.UIText.color = color;

                at.MoveTExt(m_Camera);
            }
        }
       
    }

    public void AddText(int score, Vector3 pos)
    {
        var t = m_TextPool.Dequeue();
        t.text = score.ToString();
        t.gameObject.SetActive(true);

        ActiveText at = new ActiveText() { maxTime = 1.0f };
        at.Timer = at.maxTime;
        at.UIText = t;
        at.PlayerPos = pos + Vector3.up;

        at.MoveTExt(m_Camera);
        m_ActiveText.Add(at);

    }
   
}
