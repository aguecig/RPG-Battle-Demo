using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    [SerializeField]
    private Text _text;

    [SerializeField]
    private GameObject _statusImage;

    void Start()
    {
        WriteStatusText(10, 4, false);
    }

    public void WriteStatusText(int hp, int mp, bool poisoned)
    {
        _text.text = "HP: " + hp + "\n" + "MP: " + mp;

        if (poisoned == true)
        {
            _statusImage.SetActive(true);
        }
    }
}
