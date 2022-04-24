using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Combat;

namespace RPG.Controller
{
    public class PlayerController : MonoBehaviour
    {

        [SerializeField] Camera myCamera;

        void Update()
        {
            // If we make an attack we shouldn't move! We either attack or move.
            if (InteractWithCombat()) return;
            // Move On Cursor Hit
            //      If only on one click then GetMouseButtonDown(..) method
            if (InteractWithMovement()) return;
            // ---
        }

        // Get our player to attack
        private bool InteractWithCombat()
        {
            RaycastHit[] allHits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in allHits)
            {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if (target == null) continue;

                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Fighter>().Attack(target);
                }
                return true;
            }
            return false;
        }
        // ---

        // Move on cursor hit 
        private bool InteractWithMovement()
        {
            Ray ray = GetMouseRay();
            RaycastHit hit;
            bool hasHit = Physics.Raycast(ray, out hit);

            if (hasHit)
            {
                if (Input.GetMouseButton(0))
                {
                    GetComponent<Mover>().StartMovingAction(hit.point);
                }
                return true;
            }
            return false;
        }

        // ---

        private Ray GetMouseRay()
        {
            return myCamera.ScreenPointToRay(Input.mousePosition);
        }
    }

}
