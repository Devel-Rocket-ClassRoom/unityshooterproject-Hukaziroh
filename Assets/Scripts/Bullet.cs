using UnityEditor.Build.Content;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        if (transform.position.z > 80f)
        {
            BulletPool.Instance.ReturnBullet(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            GameManager.Instance.AddScore(10);
            Destroy(other.gameObject);
            BulletPool.Instance.ReturnBullet(gameObject);
        }

        if (other.CompareTag("Player"))
        {
            GameManager.Instance.LoseLife();
            if(GameManager.Instance.life <=0)
            {
                Destroy(other.gameObject);
            }          
            BulletPool.Instance.ReturnBullet(gameObject);
        }
    }
   
   
}
