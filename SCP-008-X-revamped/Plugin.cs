// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Exiled.API.Features;
using System;
using Player = Exiled.Events.Handlers.Player;

namespace SCP_008_X_revamped
{
    public class SCP008X : Plugin<Config, Translations>
    {
        public static SCP008X Instance;
        public override Version Version => new Version(0, 0, 1);
        public override string Author => "Oplkill";
        public override string Name => "SCP-008-X-revamped";
        public override string Prefix => "SCP-008-X";

        private EventHandlers _eventHandler;

        public override void OnEnabled()
        {
            Instance = this;
            RegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnRegisterEvents();
            Instance = null;
            base.OnDisabled();
        }

        private void RegisterEvents()
        {
            _eventHandler = new EventHandlers();

            Player.Hurting += _eventHandler.OnHurting;
        }

        private void UnRegisterEvents()
        {
            Player.Hurting -= _eventHandler.OnHurting;

            _eventHandler = null;
        }
    }
}
