using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Executable> Spawnings;
    public List<Executable> Placings;

    private void Start()
    {
        ExecuteAll(Spawnings);
        foreach (var placing in Placings)
            placing.GetComponent<Placing>().SaveChildrensFromParent();

        ExecuteAll(Placings);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ExecuteAll(Placings);
    }

    private static void ExecuteAll(List<Executable> executables)
    {
        foreach (var executable in executables)
            executable.Execute();
    }
}