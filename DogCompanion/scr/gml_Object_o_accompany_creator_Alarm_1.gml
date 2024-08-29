with (o_enemy)
{
    if (faction_id == "Companion")
    {
        if (!(scr_instance_exists_in_list(o_b_accompanymaster, buffs)))
            scr_effect_create(o_b_accompanymaster, o_damage_dealer, id, id)
    }
}
