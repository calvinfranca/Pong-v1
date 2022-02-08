using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PlayerColorChange : MonoBehaviour
{
    public Color playerColor;
    [Header("References")]
    public Image uiImage;
    public Player myPlayer;
    

    // Start is called before the first frame update
    void Start()
    {
        uiImage.color = playerColor;
    }

    private void OnValidate()
    {
        uiImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        myPlayer.ChangeColor(playerColor);
    }
}
