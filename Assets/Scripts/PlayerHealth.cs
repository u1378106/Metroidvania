using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image heart1, heart2, heart3, gameOverScreen;

    private bool isAttacking;

    public void OnAttack()
    {
        StartCoroutine(StartDamageDeal());
    }

    IEnumerator StartDamageDeal()
    {
        if (!isAttacking)
        {
            isAttacking = true;
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

            isAttacking = false;
        }
    }
}
