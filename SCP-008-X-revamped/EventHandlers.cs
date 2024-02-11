// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Exiled.Events.EventArgs.Player;
using InventorySystem;

namespace SCP_008_X_revamped
{
    internal class EventHandlers
    {
        public void OnHurting(HurtingEventArgs ev)
        {
            var player = ev.Player;
            if (!player.IsHuman || player.IsTutorial)
                return;

            if (ev.DamageHandler.Type == Exiled.API.Enums.DamageType.Crushed)
                return;

            bool isDamageDeadly = !((player.Health - ev.Amount) > 0.0);

            if (!isDamageDeadly)
                return;

            ev.IsAllowed = false;

            player.Inventory.ServerDropEverything();
            player.Role.Set(PlayerRoles.RoleTypeId.Scp0492);
        }
    }
}
