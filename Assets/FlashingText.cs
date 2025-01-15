using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashingText : MonoBehaviour
{
    public Text textToFlash;
    public float flashInterval = 0.5f;

    private void Start()
    {
        textToFlash = GameObject.FindGameObjectWithTag("HelloMSG").GetComponent<Text>();
        StartCoroutine(FlashText());
    }

    IEnumerator FlashText()
    {
        while (true)
        {
            textToFlash.enabled = !textToFlash.enabled;
            yield return new WaitForSeconds(flashInterval);
        }
    }
}
