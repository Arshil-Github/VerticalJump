using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float swipeForceMag;

    public int abilityCount = 0;
    public int abilityCount_max = 0;
    public bool isAbilityCharged = false;
    
    GameManager gm;

    [HideInInspector] public bool swiped;
    [HideInInspector] public Vector2 swipeVector;
    [HideInInspector] public bool canSwipe;
    
    // Start is called before the first frame update
    void Start()
    {
        canSwipe = true;
        gm = GameObject.Find("_GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (swiped == true && canSwipe == true)
        {
            gm.freeze = false;

            swiped = false;

            Vector2 n_swipeVector = new Vector2();
            n_swipeVector = swipeForceMag * swipeVector / swipeVector.magnitude;

            rb.AddForce(n_swipeVector, ForceMode2D.Impulse);

            canSwipe = false;


            print("Moved");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("swipeActivators"))
        {
            canSwipe = true;
            swiped = false;

            Enemy collidedEnemy = new Enemy();
            if (collision.gameObject.TryGetComponent<Enemy>(out collidedEnemy))
            {
                collidedEnemy.CollidedWithPlayer(this);
            }

            StartCoroutine(freezeDelay());
        } 
        else
        {
            player_Death();
        }
    }

    IEnumerator freezeDelay()
    { 

        yield return new  WaitForSeconds(0.1f);

        gm.freeze = true;
    }
    public void player_Death()
    {
        Debug.Log("Dead");
    }
    public void changeAbility(int toBeAdded)
    {
        abilityCount += toBeAdded;

        if (abilityCount == abilityCount_max && isAbilityCharged == false)
        {
            isAbilityCharged = true;
            abilityCount = 0;
        }
    }
}
