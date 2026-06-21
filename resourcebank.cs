using System;
using UnityEngine;

namespace EcoBastion.Core
{
    public class ResourceBank : MonoBehaviour
    {
        public static ResourceBank Instance { get; private set; }

        public float Syngas { get; private set; } = 100f;
        public float BioOil { get; private set; } = 300f;
        public float CarbonBlack { get; private set; } = 0f;

        public event Action OnResourcesChanged;

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        public void AddResources(float syngas, float oil, float carbon)
        {
            Syngas += syngas;
            BioOil += oil;
            CarbonBlack += carbon;
            OnResourcesChanged?.Invoke();
        }

        public bool SpendBioOil(float amount)
        {
            if (BioOil >= amount)
            {
                BioOil -= amount;
                OnResourcesChanged?.Invoke();
                return true;
            }
            return false;
        }

        public bool SpendSyngas(float amount)
        {
            if (Syngas >= amount)
            {
                Syngas -= amount;
                OnResourcesChanged?.Invoke();
                return true;
            }
            return false;
        }
    }
}


