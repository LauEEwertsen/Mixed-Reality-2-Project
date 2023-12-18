using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDisplay : MonoBehaviour
{

    TextMeshProUGUI layerText;

    // Start is called before the first frame update
    void Start()
    {
        layerText = FindObjectOfType<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (gameObject.tag == "Dirt")
        {
            Debug.Log("Dirt!");
            layerText.text = "Dirt!";
        }
        else if (gameObject.tag == "Sand")
        {
            Debug.Log("Sand!");
            layerText.text = "Sand!";
        }
        else if (gameObject.tag == "Chalk")
        {
            Debug.Log("Chalk!");
            layerText.text = "Chalk!";
        }
        else if (gameObject.tag == "Stone")
        {
            Debug.Log("Stone!");
            layerText.text = "Stone!";
        }
        else if (gameObject.tag == "Clay")
        {
            Debug.Log("Clay!");
            layerText.text = "Clay!";
        }
    }
    
}
