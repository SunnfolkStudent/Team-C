using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    private float Timer;
    private bool HitGround = false;
    private Rigidbody2D m_Rigidbody2D;
    public float UpTimerCount;
    public float DownTimerCount;
    public string action = "idle";

    private void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        Timer = DownTimerCount;
        m_Rigidbody2D.gravityScale = 0;
    }
    
    private void Update()
    {
        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
        else if (Timer <= 0 && HitGround == false)
        {
            m_Rigidbody2D.gravityScale = 2.2f;
            action = "down";
        }
        else if (Timer <= 0 && HitGround == true)
        {
            transform.Translate(Vector2.up * Time.deltaTime * 2.8f);
            action = "up";
        }

  
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            m_Rigidbody2D.gravityScale = 0;
            HitGround = true;
            Timer = UpTimerCount;
            action = "attack";
        }
        else if (other.transform.CompareTag("Top"))
        {
            HitGround = false;
            Timer = DownTimerCount;
            action = "idle";
        }
    }
}