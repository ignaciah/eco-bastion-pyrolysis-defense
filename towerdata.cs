using UnityEngine;

namespace EcoBastion.Data
{
    [CreateAssetMenu(fileName = "NewTowerTier", menuName = "EcoBastion/Tower Tier Configuration")]
    public class TowerData : ScriptableObject
    {
        public string nodeName;
        public int tier;
        public float processingRadius;
        public float baseThroughput;
        public float thermalDissipationRate;
        public float efficiency;
        public float upgradeCostOil;
    }
}


