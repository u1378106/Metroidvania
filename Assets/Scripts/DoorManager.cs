 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoorManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> doors;

    [SerializeField]
    private List<GameObject> keys;

    [SerializeField]
    private TextMeshProUGUI keyCounterText, keyRequiredText;

    [HideInInspector]
    public int keyCounter;

    // Start is called before the first frame update
    void Start()
    {
        keyCounter = 0;
        keyCounterText.text = ": " + keyCounter;

        keyRequiredText.gameObject.SetActive(false);
    }

    public void OnKeyAcquired()
    {
        if (keyCounter == 0)
        {
            AudioManager.instance.Play("KeyAcquired");
            keyCounter++;
            keyCounterText.text = ": " + keyCounter;
        }
    }

    public void UseKey()
    {
        if (keyCounter > 0)
        {
            AudioManager.instance.Play("DoorOpen");
            keyCounter--;
            keyCounterText.text = ": " + keyCounter;
        }
        else
        {
            StartCoroutine(KeyRequired());
        }
    }

    IEnumerator KeyRequired()
    {
        AudioManager.instance.Play("Error");
        keyRequiredText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        keyRequiredText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
