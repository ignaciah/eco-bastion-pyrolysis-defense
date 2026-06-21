using UnityEngine;
using EcoBastion.Data;

namespace EcoBastion.Nodes
{
    public class WasteCreep : MonoBehaviour
    {
        public MaterialType materialProfile;
        public float totalMass = 10f;
        public float currentIntegrity = 15f;
        public float speed = 2f;

        [HideInInspector] public Transform[] pathWaypoints;
        private int _waypointIndex = 0;

        private void Update()
        {
            if (pathWaypoints == null || _waypointIndex >= pathWaypoints.Length) return;

            transform.position = Vector3.MoveTowards(transform.position, 
                pathWaypoints[_waypointIndex].position, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, pathWaypoints[_waypointIndex].position) < 0.2f)
            {
                _waypointIndex++;
            }
        }

        public void TakeDamage(float amount)
        {
            currentIntegrity -= amount;
            if (currentIntegrity <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

