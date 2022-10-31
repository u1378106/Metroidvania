using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimationController : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;

    private void Start()
    {      
        animator = GetComponent<Animator>();
    }
    public void OnCursorEnter()
    {
        animator.SetTrigger("Cursor On Button");
        AudioManager.instance.Play("MouseOverUI");
    }
    public void OnCursorExit()
    {
        animator.SetTrigger("Cursor Off Button");
    }
    public void OnMouseClick()
    {
        AudioManager.instance.Play("MouseClick");
        animator.SetTrigger("Clicked");
    }
}
