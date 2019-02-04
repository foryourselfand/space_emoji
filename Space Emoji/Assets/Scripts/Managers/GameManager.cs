using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlacingManager PlacingManager;

    private void Start()
    {
        PlacingManager.PlaceAll();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            PlacingManager.PlaceAll();
    }
}