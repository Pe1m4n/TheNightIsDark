using System.Collections.Generic;
using Fight.Enemies;
using Fight.State;
using UnityEngine;
using Zenject;

namespace Fight.Gadgets
{
    public class GadgetFactory<TData, TView> : PlaceholderFactory<TData, Vector3, TView> where TView: GadgetView
    {
        private readonly DiContainer _container;
        private readonly FightState _fightState;
        private readonly TView _prefab;

        public GadgetFactory(DiContainer container, FightState fightState, TView prefab)
        {
            _container = container;
            _fightState = fightState;
            _prefab = prefab;
        }

        public override TView Create(TData data, Vector3 position)
        {
            var gadget = _container.InstantiatePrefabForComponent<TView>(_prefab,
                position, Quaternion.identity, 
                null, new List<object>(){data});
            
            _fightState.GadgetViews.Add(gadget);
            
            return gadget;
        }
    }
}