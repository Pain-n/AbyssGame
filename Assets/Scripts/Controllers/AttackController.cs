using UnityEngine;

public class AttackController : MonoBehaviour
{
    public PlayerController Controller;
    public ComboSO Combo;

    private int comboCounter;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) Attack();
    }

    private void Attack()
    {
        if (!Controller.PlayerData.Animator.GetBool("CanAttack")) return;
        Controller.PlayerData.IsAttacking = true;
        if (comboCounter >= Combo.ComboList.Count) comboCounter = 0;
        Controller.PlayerData.Animator.runtimeAnimatorController = Combo.ComboList[comboCounter].AnimOV;
        Controller.PlayerData.Animator.Play("Attack",0,0);
        Controller.PlayerData.Animator.SetBool("Attacking", true);
        Controller.PlayerData.Animator.SetBool("CanAttack", false);

        int ComboAttackFlags = (int)Combo.ComboList[comboCounter].AttackColliders;

        foreach (var item in Controller.PlayerData.AttackCollidersList.CollidersList)
        {
            int flags = (int)item.BodyPart;
            if((ComboAttackFlags & flags) != 0) item.Collider.enabled = true;
            else item.Collider.enabled = false;
        }

        comboCounter++;
    }

    public void CanAttackEnable()
    {
        Controller.PlayerData.Animator.SetBool("CanAttack", true);
    }

    public void AttackEnd()
    {
        Controller.PlayerData.IsAttacking = false;
        Controller.PlayerData.Animator.SetBool("Attacking", false);
        comboCounter = 0;
        foreach (var item in Controller.PlayerData.AttackCollidersList.CollidersList)
        {
            item.Collider.enabled = false;
        }
    }
}
