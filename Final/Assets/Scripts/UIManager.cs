using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] TextMeshProUGUI spedometer;
    [SerializeField] TextMeshProUGUI distanceText;

    void Start()
    {
        Debug.Assert(player != null, "Player is not linked to the UI");
    }

    void Update()
    {
        int speed = (int)Mathf.Round(player.GetComponent<Rigidbody>().velocity.magnitude * 3.6f);
        spedometer.text = "Speed: " + speed +"km/h";
        int distance = (int)Mathf.Round(player.GetComponent<Rigidbody>().position.z);
        distanceText.text = "Distance Driven: " + distance + "m";
    }
}
