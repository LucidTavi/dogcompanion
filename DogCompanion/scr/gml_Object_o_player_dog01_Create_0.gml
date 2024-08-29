event_inherited()
id_name = "player_dog01"
scr_param("Guard Dog")
loot_weapon = 5
loot_chance = 90
hide_type = "o_loot_hide_wardog01"
netSize = "small"
netOffset = [-4, 2]
netWaterDeepOffset = [-2, 4]
netWaterDeepDrawLimit = 22
shadow_spr_shift = [-3, 1]
waterwaveShallowOffset = [-1, -1]
waterwaveDeepOffset = [-1, -1]
faction_id = "Companion"
faction = "Companion"

scr_set_hl()
scr_create_skill_map("Loud_Barking")
scr_create_skill_map("Grab_Em")
ai_script = gml_Script_scr_enemy_choose_state
