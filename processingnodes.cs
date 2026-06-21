using UnityEngine;
using EcoBastion.Data;
using EcoBastion.Core;

namespace EcoBastion.Nodes
{
    public class ProcessingNode : MonoBehaviour
    {
        public TowerData runtimeSpecs;
        public float accumulatedHeat = 0f;
        
        private WasteCreep _activeTarget;
        private float _targetScanTimer = 0.5f;

        private void Update()
        {
            HandleTargeting();
            ProcessPyrolysis();
            DissipateHeat();
        }

        private void HandleTargeting()
        {
            _targetScanTimer -= Time.deltaTime;
            if (_targetScanTimer > 0 && _activeTarget != null) return;
            _targetScanTimer = 0.3f;

            Collider[] targetsInRadius = Physics.OverlapSphere(transform.position, runtimeSpecs.processingRadius);
            float shortestDistance = Mathf.Infinity;
            WasteCreep nearestCreep = null;

            foreach (var col in targetsInRadius)
            {
                WasteCreep creep = col.GetComponent<WasteCreep>();
                if (creep != null)
                {
                    float dist = Vector3.Distance(transform.position, col.transform.position);
                    if (dist < shortestDistance)
                    {
                        shortestDistance = dist;
                        nearestCreep = creep;
                    }
                }
            }
            _activeTarget = nearestCreep;
        }

        private void ProcessPyrolysis()
        {
            if (_activeTarget == null) return;

            // Thermal throttling logic if the tower gets too hot
            float processingMultiplier = accumulatedHeat > 75f ? 0.5f : 1.0f;
            float workThisFrame = runtimeSpecs.baseThroughput * processingMultiplier * Time.deltaTime;

            float damageApplied = Mathf.Min(workThisFrame, _activeTarget.currentIntegrity);
            _activeTarget.TakeDamage(damageApplied);

            // Accumulate thermal energy
            accumulatedHeat += (damageApplied * 0.15f) / (1f + runtimeSpecs.efficiency);

            // Calculate resource conversion rates
            CalculateYields(damageApplied, _activeTarget.materialProfile);
        }

        private void CalculateYields(float workAmount, MaterialType type)
        {
            float oilYield = 0f;
            float syngasYield = 0f;
            float carbonYield = 0f;

            if (type == MaterialType.Polyethylene)
            {
                oilYield = workAmount * 0.60f * runtimeSpecs.efficiency;
                syngasYield = workAmount * 0.25f * runtimeSpecs.efficiency;
            }
            else if (type == MaterialType.RubberTires)
            {
                oilYield = workAmount * 0.40f * runtimeSpecs.efficiency;
                carbonYield = workAmount * 0.35f * runtimeSpecs.efficiency;
            }

            ResourceBank.Instance.AddResources(syngasYield, oilYield, carbonYield);
        }

        private void DissipateHeat()
        {
            if (accumulatedHeat > 0)
            {
                accumulatedHeat -= runtimeSpecs.thermalDissipationRate * Time.deltaTime;
                accumulatedHeat = Mathf.Max(0f, accumulatedHeat);
            }
        }

        public void InjectCoolantFlush()
        {
            if (ResourceBank.Instance.SpendSyngas(30f))
            {
                accumulatedHeat = Mathf.Max(0f, accumulatedHeat - 40f);
            }
        }
    }
}


