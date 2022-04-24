
using RPG.Core;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour, IAction
    {

        NavMeshAgent navMeshAgent;

        void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            // Move On Cursor Hit
            //      If only on one click then GetMouseButtonDown(..) method
            //      Next four lines of code are commented 
            //          because we are gonna do this in PlayerController class

            // if (Input.GetMouseButton(0))
            // {
            //     MoveToCursor();
            // }

            // ---

            // Move our player pretty
            UpdateAnimator();
            // ---

        }

        // Destinquishing moving and starting an action of moving so we can stop a previous attack
        public void StartMovingAction(Vector3 destination)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            MoveTo(destination);
        }

        // Called from PlayerController
        public void MoveTo(Vector3 destination)
        {
            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;
        }
        // ---

        public void Cancel()
        {
            navMeshAgent.isStopped = true;
        }


        // Move our player pretty
        private void UpdateAnimator()
        {
            Vector3 velocity = navMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }
        // ---
    }

}
