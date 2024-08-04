using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestinationTrigger : MonoBehaviour
{

    public ParticleSystem successParticles;
    public ParticleSystem failureParticles;
    bool isSuccess = false;
    float delay = 2f;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (this.CompareTag("Pot"))
        {
            if (other.CompareTag("Healthy"))
            {
                Debug.Log("Success");
                isSuccess = true;
               Instantiate(successParticles, this.transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(failureParticles, new Vector3(0, 0, 0), Quaternion.identity);
                StartCoroutine(HandleNegativeCase());

            }
        }
        else if (this.CompareTag("Trash"))
        {
            if (other.CompareTag("Rotten"))
            {
                isSuccess = true;
                Debug.Log("Success!");
                 Instantiate(successParticles, this.transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(failureParticles, new Vector3(0, 0, 0), Quaternion.identity);
                StartCoroutine(HandleNegativeCase());
            }
        }
    }
    public void FailureExplosion(IngredientScript collider, Collider2D collider2)
    {
        if (collider.CompareTag("Healthy") && collider2.CompareTag("Rotten") || collider2.CompareTag("Obstacle"))
        {
            Instantiate(failureParticles, new Vector3(0, 0, 0), Quaternion.identity);
            StartCoroutine(HandleNegativeCase());
        }
    }
    IEnumerator HandleNegativeCase()
    {
        yield return new WaitForSeconds(delay);

        Stars.IncrementMistakes();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public bool GetSuccess()
    {

        return isSuccess;

    }

}
