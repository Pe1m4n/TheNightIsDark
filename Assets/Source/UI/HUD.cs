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

        private CompositeDisposable _disposable = new CompositeDisposable();
        private FightState _state;
        
        [Inject]
        public void SetUp(IObservable<FightState> observableState, FightState state)
        {
            _state = state;
            observableState.Select(s => s.PlayerState.InventoryState.AmmoCount).DistinctUntilChanged().
                Subscribe(SetTotalAmmoCount).AddTo(_disposable);
            observableState.Select(s => s.PlayerState.CurrentWeapon.AmmoLoaded).DistinctUntilChanged().
                Subscribe(SetCurrentAmmoCount).AddTo(_disposable);
            observableState.Select(s => s.PlayerState.InventoryState.Dollars).DistinctUntilChanged().
                Subscribe(SetDollars).AddTo(_disposable);
            observableState.Select(s => s.PlayerState.HealthState.CurrentHealth).DistinctUntilChanged().
                Subscribe(SetHealth).AddTo(_disposable);
        }

        private void SetTotalAmmoCount(int count)
        {
            _ammoAmountText.text = $"{_state.PlayerState.CurrentWeapon.AmmoLoaded}/{count}";
        }
        
        private void SetCurrentAmmoCount(int count)
        {
            _ammoAmountText.text = $"{count}/{_state.PlayerState.InventoryState.AmmoCount}";
        }

        private void SetDollars(int dollars)
        {
            _dollarsAmountText.text = $"{dollars}";
        }

        private void SetHealth(int health)
        {
            _healthAmountText.text = $"{health}/{_state.PlayerState.HealthState.Data.TotalHealth}";
        }

        private void OnDestroy()
        {
            _disposable?.Dispose();;
        }
    }
}