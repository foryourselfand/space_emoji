using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class PlacingManager : MonoBehaviour
{
    public GameObject BuildingsHolder;
    public GameObject TreesHolder;

    private GameObject[] _buildingsSprites;
    private GameObject[] _treesSprites;

    private void Awake()
    {
        _buildingsSprites = GameObject.FindGameObjectsWithTag("Building");
        _treesSprites = GameObject.FindGameObjectsWithTag("Tree");
    }

    private void Start()
    {
        PlaceSpritesFromHolder(BuildingsHolder, _buildingsSprites);
        PlaceSpritesFromHolder(TreesHolder, _treesSprites);
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
    }
}