using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupObject : MonoBehaviour
{
    [SerializeField] GameObject player;
    private GameManager mushroomsCount;
    public GameObject pickupText; //asign in inspector
    public Text mushroomsPickedText; //asign in inspector
    public AudioSource pickupAudio;

    private void Start()
    {
        mushroomsCount = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        //Debug.Log(mushroomsCount.mushroomsPicked);
    }

    void Update()
    {
        //NOTE: gameObject refers to the object this script is attached to!

        float distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
        bool keypressed = false;

        if (distance <= 2.0f)
        {
            Debug.Log("PRESS E TO PICKUP MUSHROOM");
            pickupText.SetActive(true);
            keypressed = (Input.GetKey("e"));

            if (keypressed)
            {
                pickupAudio.Play();
                mushroomsCount.mushroomCountUpdate();
                Destroy(pickupText);
                Destroy(gameObject);
            }
        }
        else
        {
            pickupText.SetActive(false);
        }
    }
}
