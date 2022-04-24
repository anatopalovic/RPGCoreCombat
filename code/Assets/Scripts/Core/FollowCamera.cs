using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    public class FollowCamera : MonoBehaviour
    {

        // Making out follow camera
        [SerializeField] Transform target;
        // ---

        //      It's not just Update() method because we want our 
        //          FollowCamera to move AFTER our player
        void LateUpdate()
        {

            // Making out follow camera
            transform.position = target.position;
            // ---
        }
    }

}
