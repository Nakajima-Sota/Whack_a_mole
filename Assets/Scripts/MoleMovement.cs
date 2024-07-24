using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleMovement : MonoBehaviour
{
    public float upPositionY = 1.0f; 
    public float downPositionY = -1.0f; 
    public float speed = 1.0f; 

    private bool isUp = false;
    private bool hasBeenHit = false; 
    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>(); 
    }

    void Update()
    {
        float targetY = isUp ? upPositionY : downPositionY;
        Vector3 targetPosition = new Vector3(transform.position.x, targetY, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
    }

    public void SetUp(bool up)
    {
        isUp = up;
        if (isUp)
        {
            hasBeenHit = false; 
        }
    }

    void OnMouseDown()
    {   

        if (isUp && !hasBeenHit)
        {
            
            hasBeenHit = true; 
            scoreManager.AddScore(3); 
            StartCoroutine(HitReaction());
        }
    }

    private IEnumerator HitReaction()
    {
        yield return new WaitForSeconds(0.1f); 
        SetUp(false); 
    }
}


