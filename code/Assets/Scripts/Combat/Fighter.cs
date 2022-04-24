using UnityEngine;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float weaponRange = 2f;

        // Making our player move as attacking with a pause
        [SerializeField] float timeBetweenAttacks = 1f;
        // ---

        // Making our target get damage
        [SerializeField] float weaponDamage = 5f;
        // ---

        float timeSinceLastAttack = 0;
        Transform target;

        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;

            // Before anything so we don't call stop everytime 
            //      we don't have a target, making our player easier to move
            if (target == null) return;

            // Making our player stop at a distance when he attacks
            if (!isInRange())
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                AttackBehaviour();
                GetComponent<Mover>().Cancel();
            }
        }

        private void AttackBehaviour()
        {
            // Here the Hit() event is triggered!!
            // Making our player move as attacking with a pause
            if (timeSinceLastAttack < timeBetweenAttacks) return;
            GetComponent<Animator>().SetTrigger("attack");
            timeSinceLastAttack = 0;
            // ---
        }

        // ---

        // Animation event - to prevent the error when we hit
        void Hit()
        {
            Health healthComponent = target.GetComponent<Health>();
            // Making our target get damage
            healthComponent.TakeDamage(weaponDamage);
        }
        // ---


        private bool isInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;
            Debug.Log("Take that you peasant!");
        }

        // Cancelling our attack
        public void Cancel()
        {
            target = null;
        }
        // ---

        

    }
}