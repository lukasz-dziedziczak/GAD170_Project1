using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Text : MonoBehaviour
{
    [SerializeField] TMP_Text tmp_text;

    public void SetText(string text)
    {
        tmp_text.text = text;
    }
}
