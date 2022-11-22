using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image heart1, heart2, heart3, gameOverScreen;

    [HideInInspector]
    public bool isAttackingZombie = false;
    [HideInInspector]
    public bool isAttackingSpike = false;

    private float damageTime = 1f;

    private SpriteRenderer sr;

    public float minimum = 0.3f;
    public float maximum = 1f;
    public float cyclesPerSecond = 2.0f;
    private float a;
    private bool increasing = true;
    Color color;

    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        color = sr.color;
        a = maximum;
    }


    public void OnAttackZombie()
    {
        StartCoroutine(StartDamageDealZombie());
    }

    public void OnAttackSpike()
    {
        //isAttackingSpike = true;
        StartCoroutine(StartDamageDealSpike());
    }

    IEnumerator StartDamageDealZombie()
    {
        if (!isAttackingZombie)
        {
            isAttackingZombie = true;
            AudioManager.instance.Play("ZombieScream");
            yield return new WaitForSeconds(1f);

            if (heart1.fillAmount != 0)
            {
                heart1.fillAmount -= 0.25f;
            }

            else if (heart2.fillAmount != 0)
            {
                heart2.fillAmount -= 0.25f;
            }

            else if (heart3.fillAmount != 0)
            {
                heart3.fillAmount -= 0.25f;
            }

            else
            {
                Debug.Log("game over");
                gameOverScreen.gameObject.SetActive(true);
            }

            isAttackingZombie = false;
        }
    }

    IEnumerator StartDamageDealSpike()
    {
        if (!isAttackingSpike)
        {
            isAttackingSpike = true;
   
            yield return new WaitForSeconds(1f);

            if (heart1.fillAmount != 0)
            {
                heart1.fillAmount -= 0.25f;
            }

            else if (heart2.fillAmount != 0)
            {
                heart2.fillAmount -= 0.25f;
            }

            else if (heart3.fillAmount != 0)
            {
                heart3.fillAmount -= 0.25f;
            }

            else
            {
                Debug.Log("game over");
                gameOverScreen.gameObject.SetActive(true);
            }

            isAttackingSpike = false;
        }
    }

    private void Update()
    {
        if (isAttackingSpike || isAttackingZombie)
        {
            float t = Time.deltaTime;
            if (a >= maximum) increasing = false;
            if (a <= minimum) increasing = true;
            a = increasing ? a += t * cyclesPerSecond * 2 : a -= t * cyclesPerSecond;
            color.a = a;
            sr.color = color;
        }
        else
        {
            color.a = 1;
            sr.color = color;
        }
    }
}
