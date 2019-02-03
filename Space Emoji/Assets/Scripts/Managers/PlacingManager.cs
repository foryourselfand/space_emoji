using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class PlacingManager : MonoBehaviour
{
    public GameObject BuildingsHolder;
    public GameObject TreesHolder;
    public GameObject AnimalsHolder;

    private GameObject[] _buildingsSprites;
    private GameObject[] _treesSprites;
    private GameObject[] _animalsSprites;

    private void Awake()
    {
        _buildingsSprites = GameObject.FindGameObjectsWithTag("Building");
        _treesSprites = GameObject.FindGameObjectsWithTag("Tree");
        _animalsSprites = GameObject.FindGameObjectsWithTag("Animal");
    }

    private void Start()
    {
        PlaceAll();
    }

    private void PlaceAll()
    {
        PlaceSpritesFromHolder(BuildingsHolder, _buildingsSprites);
        PlaceSpritesFromHolder(TreesHolder, _treesSprites);
        PlaceSpritesFromHolder(AnimalsHolder, _animalsSprites);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            PlaceAll();
    }

    public void PlaceSpritesFromHolder(GameObject holdingObject, GameObject[] spritesToPlace)
    {
        var holders = holdingObject.GetComponents<SpritesHolder>();
        var index = Random.Range(0, holders.Length);
        var chosenHolder = holders[index];

        foreach (var tempSprite in spritesToPlace)
        {
            if (Random.Range(0, 2) == 0)
            {
                tempSprite.SetActive(true);
                tempSprite.GetComponent<SpriteRenderer>().sprite = chosenHolder.GetRandomSprite();
            }
            else
            {
                tempSprite.SetActive(false);
            }
        }

        chosenHolder.ResetToDefault();
    }
}