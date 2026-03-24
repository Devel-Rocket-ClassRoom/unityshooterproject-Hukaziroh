using UnityEngine;

public class Bullet : MonoBehaviour
{
    int damage = 30;
    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("맞았다");
            Player player = collision.gameObject.GetComponent<Player>();
            if(player != null)
            {                            
                if (!player.Damage(damage))
                {
                    Debug.Log("당신은 죽었습니다");
                    Destroy(collision.gameObject);
                }
            }


        }
    }
}
