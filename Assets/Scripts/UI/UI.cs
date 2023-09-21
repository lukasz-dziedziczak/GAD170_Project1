using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] UI_Text textPrefab;
    [SerializeField] Transform textContainer;

    public static UI Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);
    }

    public static void DisplayText(string text)
    {
        UI_Text ui_text = Instantiate(Instance.textPrefab, Instance.textContainer);
        ui_text.SetText(text);
        Debug.Log(text);
    }

}
