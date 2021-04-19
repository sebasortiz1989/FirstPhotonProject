using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Movement;

namespace Photon.Control
{
    public class PlayerController : MonoBehaviour
    {
        void Update()
        {
            if (InteractWithMovement()) return;
        }

        private bool InteractWithMovement()
        {
            RaycastHit hitInformation;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hitInformation);
            if (hasHit)
            {
                if (Input.GetMouseButton(0))
                {
                    GetComponent<Mover>().StartMoveAction(hitInformation.point);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}
