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
                successParticles.Play();
            }
            else
            {
                failureParticles.Play();
                StartCoroutine(HandleNegativeCase());

            }
        }
        else if (this.CompareTag("Trash"))
        {
            if (other.CompareTag("Rotten"))
            {
                isSuccess = true;
                Debug.Log("Success!");
                successParticles.Play();
            }
            else
            {
                failureParticles.Play();
                StartCoroutine(HandleNegativeCase());
            }
        }
    }
    IEnumerator HandleNegativeCase()
    {
        yield return new WaitForSeconds(delay);
        failureParticles.Stop();
        Stars.IncrementMistakes();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public bool GetSuccess()
    {

        return isSuccess;

    }

}
