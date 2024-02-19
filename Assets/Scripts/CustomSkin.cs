using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterCustomizationMenu : MonoBehaviour
{
    public TextMeshProUGUI skinNameText;
    public GameObject characterPrefab;
    public SpriteRenderer sr;
    public List<Sprite> skins = new List<Sprite>();
    private int selectedSkin=0;
    public GameObject playerSkin;

    private void Start()
    {
        UpdateSkinName();
    }

    public void NextSkin()
    {
        selectedSkin = (selectedSkin + 1) % skins.Count;
        UpdateSkinName();
        sr.sprite = skins[selectedSkin];
    }

    public void PreviousSkin()
    {
        selectedSkin = (selectedSkin - 1 + skins.Count) % skins.Count;
        UpdateSkinName();
        sr.sprite = skins[selectedSkin];
    }

    private void UpdateSkinName()
    {
        skinNameText.text = skins[selectedSkin].ToString().Remove(skins[selectedSkin].ToString().IndexOf(" "));
    }

    public void BackToMenu()
    {
        GameManager.instance.setSkin(skins[selectedSkin]);
        SceneManager.LoadScene("Menu");
    }
}
