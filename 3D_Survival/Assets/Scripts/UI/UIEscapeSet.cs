using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEscapeSet : MonoBehaviour
{
    public GameObject uIEscapeSet;

    [Header("Button")]
    public GameObject uIEscapeOff;


    private PlayerEscape playerEscape;

    private void Start()
    {
        playerEscape = CharacterManager.Instance.Player.escape;
        playerEscape.escape += Toggle;
        uIEscapeSet.SetActive(false);
    }
    public void Toggle()
    {
        if (IsOpen())
        {
            uIEscapeSet.SetActive(false);
        }
        else
        {
            uIEscapeSet.SetActive(true);
        }
    }
    public bool IsOpen()
    {
        return uIEscapeSet.activeInHierarchy;
    }
}
