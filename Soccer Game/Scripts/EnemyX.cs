using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed=200.0F;
    private Rigidbody enemyRb;
    private GameObject playerGoal;
    private SpawnManagerX enemyBehav;

    
    

    // Start is called before the first frame update
    void Start()
    {
        
        enemyBehav = GameObject.Find("Spawn Manager").GetComponent<SpawnManagerX>() ;
        playerGoal = GameObject.Find("Player Goal");
        enemyRb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {

        float enhanceSpeed = 20*enemyBehav.waveCount;

        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * (speed+enhanceSpeed) * Time.deltaTime);

        
    }

    private void OnCollisionEnter(Collision other)    
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }

    }

}
