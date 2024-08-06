using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngredientScript : MonoBehaviour
{
    public DestinationTrigger dest;
    public ParticleSystem failureParticles;
    float delay = 2f;
    public DrawLine line;
    Vector3[] positions;
    bool startMove = false; //this to check if line is drawing rn or not
    int moveIndex = 0;
    float speed = 5f;
    void OnMouseDown()
    {
        line.StartLine(transform.position);

    }

    void OnMouseDrag()
    {
        line.UpdateLine();
    }

    void OnMouseUp()
    {
        positions = new Vector3[line.line.positionCount]; //make an array with all positions of the line
        line.line.GetPositions(positions); //gets all positions
    }
    public void Move()
    {
        if (positions == null) { startMove = false; }
        else { startMove = true; }

    }

    private void Update()
    {
        if (startMove)
        {
            Vector2 currPos = positions[moveIndex];
            transform.position = Vector2.MoveTowards(transform.position, currPos, speed * Time.deltaTime);


            float distance = Vector2.Distance(currPos, transform.position);
            if (distance <= 0.05f) { moveIndex++; }
            if (moveIndex == positions.Length - 1)
            {
                startMove = false;
            }


        }

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Untagged"))
        {
            dest.FailureExplosion(this, other);
            this.gameObject.SetActive(false);
        }
        // StartCoroutine(HandleTriggerEvent(other));

    }
    /* IEnumerator HandleTriggerEvent(Collider2D other)
     {
         yield return new WaitForSeconds(delay);

         {
             Debug.Log(this.tag);
             Debug.Log(other.tag);
             Stars.IncrementMistakes();
             SceneManager.LoadScene(SceneManager.GetActiveScene().name);
         }

     }*/
}
