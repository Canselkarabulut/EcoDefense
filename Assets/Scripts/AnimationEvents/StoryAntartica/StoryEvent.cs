using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryEvent : MonoBehaviour
{
    public GameObject deadExplore;
    public GameObject blackTransition;
    public void ActiveScatebord()
    {
        if (deadExplore != null)
        {
            deadExplore.SetActive(true);
            StartCoroutine(TransitionPlayer());
        }
    }

    IEnumerator TransitionPlayer()
    {
        yield return new WaitForSeconds(1.5f);
        blackTransition.SetActive(true);
        transform.gameObject.SetActive(false);
    }
}
