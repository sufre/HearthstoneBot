using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System;
using UnityEngine;

namespace HearthstoneBot
{
    public class PrivateHacker
    {
        public static object get_private_field(object o, String name)
        {
            FieldInfo myFieldInfo = o.GetType().GetField(name, BindingFlags.NonPublic | BindingFlags.Instance);
            return myFieldInfo.GetValue(o);
        }

        public static void set_private_field(object o, String name, object val)
        {
            FieldInfo myFieldInfo = o.GetType().GetField(name, BindingFlags.NonPublic | BindingFlags.Instance);
            myFieldInfo.SetValue(o, val);
        }

        public static object call_private_method(object o, string name, object[] args)
        {
            MethodInfo dynMethod = o.GetType().GetMethod(name, BindingFlags.NonPublic | BindingFlags.Instance);
            return dynMethod.Invoke(o, args);
        }

        public static void ForceManaUpdate(Entity entity)
        {
            call_private_method(InputManager.Get(), "ForceManaUpdate", new object[] { entity });
        }

        public static void HandleClickOnCard(Card c)
        {
            call_private_method(InputManager.Get(), "HandleClickOnCard", new object[] { c.gameObject });
        }

        public static void HandleClickOnCardInBattlefield(Card c)
        {
            call_private_method(InputManager.Get(), "HandleClickOnCardInBattlefield", new object[] { c.GetEntity() });
        }

        public static void GrabCard(Card c)
        {
            call_private_method(InputManager.Get(), "GrabCard", new object[] { c.gameObject });
        }

        public static bool PlayPowerUpSpell(Card c)
        {
            return (bool) call_private_method(InputManager.Get(), "PlayPowerUpSpell", new object[] { c });
        }

        public static bool PlayPlaySpell(Card c)
        {
            return (bool) call_private_method(InputManager.Get(), "PlayPlaySpell", new object[] { c });
        }

        public static ZonePlay get_m_myPlayZone()
        {
            return (ZonePlay) get_private_field(InputManager.Get(), "m_myPlayZone");
        }

        public static ZoneHand get_m_myHandZone()
        {
            return (ZoneHand) get_private_field(InputManager.Get(), "m_myHandZone");
        }

        public static List<MulliganReplaceLabel> get_m_UIbuttons()
        {
            return (List<MulliganReplaceLabel>) get_private_field(MulliganManager.Get(), "m_UIbuttons");
        }

        public static ZoneWeapon get_m_myWeaponZone()
        {
            return (ZoneWeapon) get_private_field(InputManager.Get(), "m_myWeaponZone");
        }

        public static void set_m_battlecrySourceCard(Card val)
        {
            set_private_field(InputManager.Get(), "m_battlecrySourceCard", val);
        }

        public static void set_m_lastZoneChangeList(ZoneChangeList val)
        {
            set_private_field(InputManager.Get(), "m_lastZoneChangeList", val);
        }

        public static void set_m_activityDetected(bool val)
        {
            set_private_field(InactivePlayerKicker.Get(), "m_activityDetected", val);
        }

        public static void set_TargetReticleManager_s_instance(TargetReticleManager i)
        {
            FieldInfo myFieldInfo = typeof(TargetReticleManager).GetField("s_instance", BindingFlags.NonPublic | BindingFlags.Static);
            myFieldInfo.SetValue(null, i);
        }
    }
}
