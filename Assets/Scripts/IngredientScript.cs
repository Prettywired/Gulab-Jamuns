using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngredientScript : MonoBehaviour
{
    public Stars stars;
    public DrawLine line;
    Vector3[] positions;
    bool startMove = false; //this to check if line is drawing rn or not
    int moveIndex = 0;
    float speed = 10f;
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
        Debug.Log(other.tag);
        this.gameObject.SetActive(false);
        if (this.CompareTag("Healthy") && other.CompareTag("Rotten") || other.CompareTag("Obstacle"))
        {
            Debug.Log(this.tag);
            Debug.Log(other.tag);
            stars.IncrementMistakes();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
