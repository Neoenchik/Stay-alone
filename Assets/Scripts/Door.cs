using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    //private Animator[] m_Animator = new Animator(4);
    public Animator m_Animator1,
        m_Animator2,
        m_Animator3,
        m_Animator4,
        m_Animator5;
    public bool IsOpen;

    void Start()
    {
        if (IsOpen)
        {
            m_Animator1.SetBool("IsOpen", true);
            m_Animator2.SetBool("IsOpen", true);
            m_Animator3.SetBool("IsOpen", true);
            m_Animator4.SetBool("IsOpen", true);
            m_Animator5.SetBool("IsOpen", true);
        }
    }

    public string GetDescription()
    {
        if (IsOpen) return "Press [E] to <color=red>close</color> the door";
        else return "Press [E] to <color=green>open</color> the door";
    }

    public void Interact()
    {
        IsOpen = !IsOpen;
        if (IsOpen)
        {
            m_Animator1.SetBool("IsOpen", true);
            m_Animator2.SetBool("IsOpen", true);
            m_Animator3.SetBool("IsOpen", true);
            m_Animator4.SetBool("IsOpen", true);
            m_Animator5.SetBool("IsOpen", true);
            this.GetComponent<BoxCollider>().isTrigger = false;
        }
        else
        {
            m_Animator1.SetBool("IsOpen", false);
            m_Animator2.SetBool("IsOpen", false);
            m_Animator3.SetBool("IsOpen", false);
            m_Animator4.SetBool("IsOpen", false);
            m_Animator5.SetBool("IsOpen", false);
            this.GetComponent<BoxCollider>().isTrigger = true;
        }
    }
}
