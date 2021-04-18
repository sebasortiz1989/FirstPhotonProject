using UnityEngine;
using UnityEngine.AI;

namespace Photon.Movement
{
    public class Mover : MonoBehaviour
    {
        // Cached Component References
        NavMeshAgent navMeshAgent;
        Animator anim;

        // String const
        private const string SPEED_BLEND_VALUE = "fowardSpeed";

        // Initialize Variables
        float runSpeed = 5.662f;
        float walkSpeed = 3f;
        Vector3 velocity;
        Vector3 localVelocity;
        bool walkOrRun;
        private static bool rPressed;

        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            anim = GetComponent<Animator>();
        }

        void Update()
        {
            ChangePlayerWalkRunSpeed();
            UpdateAnimator();
        }

        private void ChangePlayerWalkRunSpeed()
        {
            // If Control is pressed
            if (Input.GetKeyDown(KeyCode.LeftControl))
                walkOrRun = true;
            else if (Input.GetKeyUp(KeyCode.LeftControl))
                walkOrRun = false;

            // If R is toggled
            if (!Input.GetKey(KeyCode.LeftControl))
            {
                if (!walkOrRun)
                {
                    if (Input.GetKeyDown(KeyCode.R))
                        rPressed = true;
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.R))
                        rPressed = false;
                }

                if (rPressed)
                    walkOrRun = true;
                else
                    walkOrRun = false;
            }

            // Change speed
            if (walkOrRun)
                navMeshAgent.speed = runSpeed;
            else
                navMeshAgent.speed = walkSpeed;
        }

        private void UpdateAnimator()
        {
            velocity = GetComponent<NavMeshAgent>().velocity;
            localVelocity = transform.InverseTransformDirection(velocity);
            anim.SetFloat(SPEED_BLEND_VALUE, Mathf.Abs(localVelocity.z));
        }

        public void StartMoveAction(Vector3 destination)
        {
            MoveTo(destination);
        }

        public void MoveTo(Vector3 destination)
        {
            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;
        }

        public void Cancel()
        {
            navMeshAgent.isStopped = true;
        }
    }
}