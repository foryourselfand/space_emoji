using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SpawnersManager SpawnersManager;
    public PlacingManager PlacingManager;

    private void Start()
    {
        ActionAll();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ActionAll();
    }

    private void ActionAll()
    {
        SpawnersManager.SpawnAll();
        PlacingManager.PlaceAll();   
    }
}