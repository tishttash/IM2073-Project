using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStarter5 : MonoBehaviour
{
    public GameObject[] firegroup;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        StartCoroutine(fireStarter());
    }

    IEnumerator fireStarter()
    {
        for (int i = 0; i < 6; i++)
        {
            firegroup[i].SetActive(false);
        }
        yield return new WaitForSeconds(135);
        if (!gameManager.gameWin)
        {
            for (int i = 0; i < 6; i++)
            {
                firegroup[i].SetActive(true);
            }
        }
    }
}
