using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    Animator m_anim;
    public float health = 50f;
    private bool dead = false;
    public void TakeDamage(float amount)
    {
        m_anim = GetComponent<Animator>();
        health -= amount;
        /*if(dead)
        {
            if (!m_anim.GetCurrentAnimatorStateInfo(0).IsName("Layer.dead"))
            {
                Destroy(gameObject);
                Debug.Log("dead blyat");
            }
        }
        else*/
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        m_anim.SetTrigger("dead");
        //health = 1;
        //Destroy(gameObject, m_anim.GetCurrentAnimatorStateInfo(0).length);

    }
}
