if instance_exists(o_player)
{
    var _unit = choose(o_bandit_dog01, o_bandit_dog02, o_bandit_dog03)
    var _x = scr_round_cell(mouse_x)
    var _y = scr_round_cell(mouse_y)
    if (distance_check && (!(scr_pat_prototype(_x, _y, 0, 0))) && scr_is_ground(x, y))
    {
        if (scr_atr("classKey") == "Woodward")
            scr_random_speech("useTrapDirwin")
        else
            scr_random_speech("useTrap")
        with (scr_enemy_create(_x, _y, _unit, 0))
        {
            faction_id = "Companion"
            image_speed = 1
            is_cheack = 0
            owner = o_player
            gain_xp *= 0.1
            can_drop_loot = 0
            bEVS += ((owner.Vitality - 10) * 2)
            bHit_Chance += ((owner.WIL - 10) * 2)
            bFMB -= ((owner.WIL - 10) * 2)
            bHP += (((owner.Vitality / 3) * HP) - HP)
            ds_map_add(data, "Pure_Damage_Self", 1)
            alarm[0] = -1
            scr_audio_play_at(choose(snd_dog_alert_1, snd_dog_alert_2, snd_dog_alert_3, snd_dog_alert_4))
            scr_characterStatsUpdateAdd("usedTraps", 1)
        }
        with (parent)
            instance_destroy()
        event_user(15)
        scr_allturn()
        with (o_floor_target)
            alarm[2] = 1
    }
    else
        audio_play_sound(snd_mouse_skill_denied, 3, false)
}
else
    event_user(15)
