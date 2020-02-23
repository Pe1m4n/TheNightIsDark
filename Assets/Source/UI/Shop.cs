using DefaultNamespace;
using Fight.State;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private Text _healthCountText;
        [SerializeField] private Text _healthPriceText;
        [SerializeField] private Text _ammoCountText;
        [SerializeField] private Text _ammoPriceText;
        [SerializeField] private Text _minePriceText;
        [SerializeField] private Text _barrelPriceText;

        private ShopData _data;
        private PlayerState _playerState;
        
        [Inject]
        public void SetUp(ShopData shopData, PlayerState playerState)
        {
            _data = shopData;
            _playerState = playerState;
            _healthCountText.text = $"X{_data.HealthShopData.Count}";
            _healthPriceText.text = $"{_data.HealthShopData.Price}";
            _ammoCountText.text = $"X{_data.AmmoShopData.Count}";
            _ammoPriceText.text = $"{_data.AmmoShopData.Price}";
            _minePriceText.text = $"{_data.MineShopData.Price}";
            _barrelPriceText.text = $"{_data.BarrelShopData.Price}";
        }

        public void TryBuyHealth()
        {
            if (_playerState.InventoryState.Dollars < _data.HealthShopData.Price)
            {
                return;
            }

            _playerState.InventoryState.Dollars -= _data.HealthShopData.Price;
            _playerState.HealthState.CurrentHealth += _data.HealthShopData.Count;
        }
        
        public void TryBuyAmmo()
        {
            if (_playerState.InventoryState.Dollars < _data.AmmoShopData.Price)
            {
                return;
            }

            _playerState.InventoryState.Dollars -= _data.AmmoShopData.Price;
            _playerState.InventoryState.AmmoCount += _data.AmmoShopData.Count;
        }
        
        public void TryBuyMine()
        {
            if (_playerState.InventoryState.Dollars < _data.MineShopData.Price)
            {
                return;
            }

            _playerState.InventoryState.Dollars -= _data.MineShopData.Price;
            _playerState.InventoryState.MineCount += _data.MineShopData.Count;
        }
        
        public void TryBuyBarrel()
        {
            if (_playerState.InventoryState.Dollars < _data.BarrelShopData.Price)
            {
                return;
            }

            _playerState.InventoryState.Dollars -= _data.BarrelShopData.Price;
            _playerState.InventoryState.BarrelCount += _data.BarrelShopData.Count;
        }
    }
}