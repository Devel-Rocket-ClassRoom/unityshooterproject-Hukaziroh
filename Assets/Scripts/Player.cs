using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform cannonPoint;
    public GameObject projectile;
    public Transform spawnPoint;

    [SerializeField]
    int health = 100;
    void Start()
    {
       
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            BulletPool.Instance.GetBullet(spawnPoint.position, BulletPool.Instance.bulletPrefab.transform.rotation);
        }

        if (Input.GetKey(KeyCode.A) == true)
        {
            transform.Translate(-0.2f, 0, 0);
        }

        if (Input.GetKey(KeyCode.D) == true)
        {
            transform.Translate(0.2f, 0, 0);
        }

      
        float limitX = Mathf.Clamp(transform.position.x, -15f, 15f);
     
        transform.position = new Vector3(limitX, transform.position.y, transform.position.z);
    }

    public bool Damage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Destroy(this);
            return false;
        }
        return true;

    }


}
