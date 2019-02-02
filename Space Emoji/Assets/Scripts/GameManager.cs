using System.Security.Cryptography;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ParentGround;

//    public GameObject Building;
//    public GameObject Tree;

    private void Start()
    {
//        RandomSpawn(Building, 1, 1.3F, 0);
//        RandomSpawn(Tree, 2, 1.7F, 0.7F);
        
        
    }

    /*
    private void RandomSpawn(GameObject objectToSpawn, int count, float selfX, float byX)
    {
        var spriteTypes = objectToSpawn.GetComponents<MultiplySprites>();
        var randomTypeIndex = Random.Range(0, spriteTypes.Length);

        var sign = -1;
        for (var j = 0; j < 2; j++)
        {
            for (var i = 0; i < count; i++)
            {
                var instance = Instantiate(objectToSpawn, objectToSpawn.transform.position, Quaternion.identity);
                instance.transform.parent = ParentGround.transform;
                instance.GetComponents<MultiplySprites>()[randomTypeIndex].SetRandomSprite();

                instance.transform.localPosition =
                    new Vector3(selfX * sign - i * byX * sign, instance.transform.localPosition.y, 0);
            }

            sign = 1;
        }
    }
    */
}