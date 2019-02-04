using System.Collections.Generic;
using UnityEngine;

public class Placing : Executable
{
    public GameObject Holder;
    public GameObject Parent;

    private List<GameObject> _sprites;

    public void SaveChildrensFromParent()
    {
        _sprites = Helper.GetChildsFromParent(Parent);
    }

    public override void Execute()
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