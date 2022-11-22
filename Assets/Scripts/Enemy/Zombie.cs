using UnityEngine;
using UnityEngine.UI;

public class Zombie : MonoBehaviour
{
    Transform target;
    public Transform borderCheck;
    public int enemyHP = 100;
    public Animator animator;
    public Slider enemyHealthBar;

    PlayerControllerStateMachine _sm;
    // Start is called before the first frame update
    void Start()
    {
        _sm = GameObject.FindObjectOfType<PlayerControllerStateMachine>();

        enemyHealthBar.value = enemyHP;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Physics2D.IgnoreCollision(target.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            if (!this.gameObject.name.Equals("BossZombie"))
            {
                if (target.position.x > transform.position.x)
                    transform.localScale = new Vector2(0.45f, 0.45f);
                else
                    transform.localScale = new Vector2(-0.45f, 0.45f);
            }
            else if (this.gameObject.name.Equals("BossZombie"))
            {
                if (target.position.x > transform.position.x)
                    transform.localScale = new Vector2(1.3f, 1.3f);             
                else              
                transform.localScale = new Vector2(-1.3f, 1.3f);
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {      
        if (other.gameObject.tag == "Kunai")
        {
            GameObject damageEffect = GameObject.Instantiate(_sm.abilitySet[0].damageEffect, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            if (this.gameObject.name.Equals("BossZombie"))
                TakeDamage(10);
            else
                TakeDamage(20);
        }     
    }

    public void TakeDamage(int damageAmount)
    {
        enemyHP -= damageAmount;
        enemyHealthBar.value = enemyHP;
        if (enemyHP > 0)
          {
            animator.SetTrigger("damage");
	    animator.SetBool("isChasing", true);
        }
        else
        {
            if(this.gameObject.name.Equals("BossZombie"))
            {
                GameObject.Find("BossManager").GetComponent<Boss>().isBossDead = true;
                GameObject.Find("BossManager").GetComponent<Boss>().FinalKey();
            }
            AudioManager.instance.Play("Damage");
            GameObject destroyEffect = GameObject.Instantiate(_sm.abilitySet[0].destroyEffect, transform.position, Quaternion.identity);
            animator.SetTrigger("death");
            GetComponent<CapsuleCollider2D>().enabled = false;
            enemyHealthBar.gameObject.SetActive(false);
            this.enabled = false;
        }
    }
}
