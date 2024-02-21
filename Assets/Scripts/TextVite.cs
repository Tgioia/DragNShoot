using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextVite : MonoBehaviour
{
    public TextMeshProUGUI vite;
    public TextMeshProUGUI text;
    void Update()
    {
        text.text = vite.text;
    }
}
