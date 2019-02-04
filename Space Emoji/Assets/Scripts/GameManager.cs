using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject SpawningParent;
    public GameObject SpritingParent;

    private List<IExecutable> _spawnings;
    private List<IExecutable> _spritings;

    private void Awake()
    {
        _spawnings = Helper.GetChildsFromParent<IExecutable>(SpawningParent);
        _spritings = Helper.GetChildsFromParent<IExecutable>(SpritingParent);
    }

    private void Start()
    {
        ExecuteAll(_spawnings);
        
//        foreach (var placing in _spritings)
//            placing.GetComponent<Spriting>().SaveChildrensFromParent();

        ExecuteAll(_spritings);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ExecuteAll(_spritings);
    }

    private static void ExecuteAll(List<IExecutable> executables)
    {
        foreach (var executable in executables)
            executable.Execute();
    }
}