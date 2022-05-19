using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class with basic functions to make the control of fighters.
 */
public class FighterControllerBase : MonoBehaviour
{
    // Controle de elementos de vida
    public float life;
    public float spell;

    // Movimentacao
    public float speed;
    public float jumpForce;
    protected float direction = 1f;
    protected bool isGrounded = false;

    protected Rigidbody2D rigidbody2D;
    public Animator animator;

    // Health bar
    public ProgressBar healthBar;
    // Spell bar
    public ProgressBar spellBar;

    public void InitializeHealthAndSpellBars() {
        healthBar.SetMaxValue(life);
        healthBar.SetValue(life);
        spellBar.SetMaxValue(spell);
        spellBar.SetValue(spell);
    }

    protected void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag(Tag.GROUND) || collision2D.gameObject.CompareTag(Tag.ENEMY))
        {
            isGrounded = true;
            this.animator.SetTrigger("landed");
            this.animator.ResetTrigger("jump");
            Landed();
        }
    }

    protected void OnCollisionExit2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag(Tag.GROUND) || collision2D.gameObject.CompareTag(Tag.ENEMY))
        {
            isGrounded = false;
            animator.ResetTrigger("landed");
        }
    }

    protected void Move(float direction)
    {
        rigidbody2D.velocity = new Vector2(direction * speed * Time.deltaTime, rigidbody2D.velocity.y);
    }

    protected void Jump(ForceMode2D forceMode2D = ForceMode2D.Impulse)
    {
        animator.SetTrigger("jump");
        rigidbody2D.AddForce(Vector2.up * jumpForce, forceMode2D);
    }

    public void DecreaseLife(float value) {
        life -= value;
        healthBar.SetValue(life);
    }

    public void DecreaseSpell(float value) {
        spell -= value;
        spellBar.SetValue(spell);
    }

    public float GetHealthPoints(){
        return healthBar.GetValue();
    }

    public float GetSpellPoints(){
        return spellBar.GetValue();
    }

    public virtual void Landed() { }
    
}
