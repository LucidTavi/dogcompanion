function scr_bw_checker(argument0) //gml_Script_scr_tavi_checker
{
    if (!__is_undefined(argument0))
    {
        if (argument0.faction_id == "Companion")
            instance_create(x, y, o_accompany_creator)
    }
}
