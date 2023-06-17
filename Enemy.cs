using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum EnemyTypes {Normal, Indestructible}
    public EnemyTypes enemyTypes;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "swipeActivators";   
    }
    public void CollidedWithPlayer(PlayerMovement _pm)
    {
        if (enemyTypes == EnemyTypes.Normal)
        {
            Debug.Log("Normal Enemy Detected: Destroy me");
            _pm.changeAbility(1);
        }
        else if (enemyTypes == EnemyTypes.Indestructible)
        {
            Debug.Log("Indestructible Enemy Detected: Destroy player");
        }
    }

}
