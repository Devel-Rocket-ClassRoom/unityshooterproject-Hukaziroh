using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    int health = 100;
    void Start()
    {
        
    }

    void Update()
    {
        
    }


    //리턴이 true면 데미지 받음 false면 죽음
    public bool Damage(int dmg)
    {
        health -= dmg;
        if(health <= 0)
        {
            Destroy(this);
            return false;
        }
        return true;
       
    }
}
