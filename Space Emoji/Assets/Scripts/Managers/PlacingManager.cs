using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingManager : MonoBehaviour
{
    public SpawningManager FlowersSpawner;

    public GameObject BuildingsHolder;
    public GameObject TreesHolder;
    public GameObject AnimalsHolder;
    public GameObject FlowerHolder;

    private GameObject[] _buildingsSprites;
    private GameObject[] _treesSprites;
    private GameObject[] _animalsSprites;
    private GameObject[] _flowersSprites;

    private void Awake()
    {
        _buildingsSprites = GameObject.FindGameObjectsWithTag("Building");
        _treesSprites = GameObject.FindGameObjectsWithTag("Tree");
        _animalsSprites = GameObject.FindGameObjectsWithTag("Animal");
        
        FlowersSpawner.Spawn();
        _flowersSprites = FlowersSpawner.Instances.ToArray();
    }

    public void PlaceAll()
    {
        PlaceSpritesFromHolder(BuildingsHolder, _buildingsSprites);
        PlaceSpritesFromHolder(TreesHolder, _treesSprites);
        PlaceSpritesFromHolder(AnimalsHolder, _animalsSprites);
        PlaceSpritesFromHolder(FlowerHolder, _flowersSprites);
    }

    public void PlaceSpritesFromHolder(GameObject holdingObject, GameObject[] spritesToPlace)
    {
        var holders = holdingObject.GetComponents<SpritesHolder>();
        var index = Random.Range(0, holders.Length);
        var chosenHolder = holders[index];

        foreach (var tempSprite in spritesToPlace)
        {
            tempSprite.GetComponent<SpriteRenderer>().sprite = chosenHolder.GetRandomSprite();
            tempSprite.SetActive(Random.Range(0, 2) == 0);
        }

        chosenHolder.ResetToDefault();
    }
}