using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    public int damage = 30;

    // 충돌이 시작될 때 호출
    void OnCollisionEnter(Collision collision)
    {
        
    }

    // 충돌이 유지되는 동안 호출
    void OnCollisionStay(Collision collision)
    {

    }

    // 충돌이 끝날 때 호출
    void OnCollisionExit(Collision collision)
    {

        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("적 충돌! ");
            //// 만약에 게임오브젝트의 체력에 0이되면 삭제
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.health -= damage;
                Debug.Log("적 충돌! " + enemy.health);
                if (enemy.health < 0)
                    Destroy(collision.gameObject);
            }
          
        }
               
        else if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Stage")
        {
            Debug.Log("충돌 종료: " + collision.gameObject.name);
            Destroy(collision.gameObject);
        }
    }

}
