using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class BaseCharacterAttack : MonoBehaviour
{
    [SerializeField] private Transform attackController;

    [SerializeField] private float attackRadius;

    [SerializeField] private float attackDamage;

    public string player;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Punch();
        }
    }

    private void Punch()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(attackController.position, attackRadius);

        foreach (Collider2D collider in objects)
        {
            if (collider.CompareTag(player))
            {
                collider.transform.GetComponent<Damage>().GetDamage(attackDamage);
            }
        }
    }

    // Para ver en pruebas
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackController.position, attackRadius);
    }
}
