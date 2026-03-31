using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 20f;

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (transform.position.z > 80f)
        {
            EnemyBulletPool.Instance.ReturnBullet(gameObject);

            if (transform.position.z < -80f)
            {
                EnemyBulletPool.Instance.ReturnBullet(gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {   
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.LoseLife();
            if (GameManager.Instance.life <= 0)
            {
                Destroy(other.gameObject);
            }
            EnemyBulletPool.Instance.ReturnBullet(gameObject);
        }
    }
}
