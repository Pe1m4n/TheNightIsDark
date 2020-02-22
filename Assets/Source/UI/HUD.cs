using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class HUD : MonoBehaviour
    {
        public Text _ammoAmountText;
        public Text _healthAmountText;
        public Text _dollarsAmountText;

        [Inject]
        public void SetUp()
        {
            
        }
    }
}