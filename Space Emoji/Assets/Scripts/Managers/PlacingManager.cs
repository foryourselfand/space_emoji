using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingManager : MonoBehaviour
{
    public List<Placer> Placers;

    public void PlaceAll()
    {
        foreach (var tempPlaces in Placers)
            tempPlaces.PlaceSpritesFromHolder();
    }
}