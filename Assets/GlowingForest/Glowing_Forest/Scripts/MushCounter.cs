using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MushCounter : MonoBehaviour
{
    GameManager gameManager;
    public Text mushCount;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        mushCount.text = gameManager.mushroomsPicked.ToString();
    }
}
