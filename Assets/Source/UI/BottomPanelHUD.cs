using System;
using Fight.State;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class BottomPanelHUD : MonoBehaviour
    {
        public Text _barrelCountText;
        public Text _mineCountText;

        private CompositeDisposable _disposable = new CompositeDisposable();
        
        [Inject]
        public void SetUp(IObservable<FightState> state)
        {
            state.Select(s => s.PlayerState.InventoryState.BarrelCount).DistinctUntilChanged()
                .Subscribe(count => _barrelCountText.text = $"{count}").AddTo(_disposable);
            
            state.Select(s => s.PlayerState.InventoryState.MineCount).DistinctUntilChanged()
                .Subscribe(count => _mineCountText.text = $"{count}").AddTo(_disposable);
        }

        private void OnDestroy()
        {
            _disposable?.Dispose();
        }
    }
}