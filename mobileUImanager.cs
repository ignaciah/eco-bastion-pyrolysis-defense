using UnityEngine;
using UnityEngine.UI;
using TMPro;
using EcoBastion.Core;
using EcoBastion.Nodes;

namespace EcoBastion.UI
{
    public class MobileUIManager : MonoBehaviour
    {
        [Header("Global HUD Elements")]
        [SerializeField] private TextMeshProUGUI syngasText;
        [SerializeField] private TextMeshProUGUI bioOilText;
        [SerializeField] private TextMeshProUGUI carbonText;

        [Header("Lower Context Panel")]
        [SerializeField] private GameObject detailPanelModal;
        [SerializeField] private TextMeshProUGUI selectedNodeNameText;
        [SerializeField] private Slider thermalLoadSlider;
        [SerializeField] private Image thermalSliderFill;

        private ProcessingNode _selectedNodeInstance;

        private void Start()
        {
            ResourceBank.Instance.OnResourcesChanged += UpdateGlobalHUD;
            detailPanelModal.SetActive(false);
            UpdateGlobalHUD();
        }

        private void Update()
        {
            HandleScreenTouches();
            UpdateActivePanelMetrics();
        }

        private void UpdateGlobalHUD()
        {
            syngasText.text = $"S: {Mathf.FloorToInt(ResourceBank.Instance.Syngas)}";
            bioOilText.text = $"O: {Mathf.FloorToInt(ResourceBank.Instance.BioOil)}";
            carbonText.text = $"C: {Mathf.FloorToInt(ResourceBank.Instance.CarbonBlack)}";
        }

        private void HandleScreenTouches()
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    ProcessingNode node = hit.collider.GetComponent<ProcessingNode>();
                    if (node != null)
                    {
                        SelectNodeInstance(node);
                    }
                }
            }
        }

        private void SelectNodeInstance(ProcessingNode node)
        {
            _selectedNodeInstance = node;
            selectedNodeNameText.text = node.runtimeSpecs.nodeName;
            detailPanelModal.SetActive(true);
        }

        private void UpdateActivePanelMetrics()
        {
            if (_selectedNodeInstance == null) return;

            thermalLoadSlider.value = _selectedNodeInstance.accumulatedHeat / 100f;
            
            // Visual warning feedback loop
            thermalSliderFill.color = _selectedNodeInstance.accumulatedHeat > 75f ? Color.red : Color.cyan;
        }

        public void TriggerPanelCoolantFlush()
        {
            if (_selectedNodeInstance != null)
            {
                _selectedNodeInstance.InjectCoolantFlush();
            }
        }

        public void DeselectActiveNode()
        {
            _selectedNodeInstance = null;
            detailPanelModal.SetActive(false);
        }
    }
}
