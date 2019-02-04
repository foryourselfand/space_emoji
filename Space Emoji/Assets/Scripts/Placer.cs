using System.Collections.Generic;
using UnityEngine;

public class Placer : MonoBehaviour
{
    public GameObject Holder;
    public GameObject Parent;

    private List<GameObject> _sprites;

    private void Awake()
    {
        _sprites = Helper.GetChildsFromParent(Parent);
    }

    public void PlaceSpritesFromHolder()
    {
        var holders = Holder.GetComponents<SpritesHolder>();
        var index = Random.Range(0, holders.Length);
        var chosenHolder = holders[index];

        foreach (var tempSprite in _sprites)
        {
            tempSprite.GetComponent<SpriteRenderer>().sprite = chosenHolder.GetRandomSprite();
            tempSprite.SetActive(Random.Range(0, 2) == 0);
        }

        chosenHolder.ResetToDefault();
    }
}