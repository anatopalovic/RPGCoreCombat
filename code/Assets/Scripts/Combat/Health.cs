using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float health = 100f;

        public void TakeDamage(float damage)
        {
            if (health - damage < 0)
                health = 0;
            else
                health -= damage;
            Debug.Log(health);
        }
    }
}

