using System;
using UnityEngine;

namespace Core
{
    public class GameTick : MonoBehaviour
    {
        public class OnTickEventArgs : EventArgs
        {
            public int Tick;
        }

        public static event EventHandler<OnTickEventArgs> OnTick;

        public const float TICK_INTERVAL = .1f;

        [SerializeField] private int _tick;
        private float _tickTimer;

        private void Update()
        {
            _tickTimer += Time.deltaTime;

            if (_tickTimer >= TICK_INTERVAL)
            {
                _tickTimer -= TICK_INTERVAL;
                _tick++;
                OnTick?.Invoke(this, new OnTickEventArgs { Tick = _tick });
            }
        }
    }
}
