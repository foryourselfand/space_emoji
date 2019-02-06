using System.Collections;
using UnityEngine;

public class GameCycle : MonoBehaviour
{
    public static bool CanClick;

    public ButtonsParent ButtonsParent;

    private void Start()
    {
        CanClick = false;
        StartCoroutine(ShowButtons());
    }

    private IEnumerator ShowButtons()
    {
        yield return ButtonsParent.ShowButtons();
        Debug.Log("END");
    }
}