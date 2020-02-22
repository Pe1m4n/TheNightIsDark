using System;
using Fight.State;
using UniRx;
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

        private CompositeDisposable _disposable;
        private FightState _state;
        
        [Inject]
        public void SetUp(IObservable<FightState> observableState, FightState state)
        {
            _state = state;
            observableState.Select(s => s.PlayerState.InventoryState.AmmoCount).DistinctUntilChanged().Subscribe(SetInventoryData);
        }

        private void SetInventoryData(int count)
        {
            _ammoAmountText.text = $"{count}";
        }

        private void OnDestroy()
        {
            _disposable?.Dispose();;
        }
    }
}