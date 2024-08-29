with (target)
{
    is_neutral = 1
    loot_script = -4
    if (object_is_ancestor(object_index, o_animals) || object_is_ancestor(object_index, o_Carnivore) || object_is_ancestor(object_index, o_Herbivore) || object_is_ancestor(object_index, o_deer_w) || object_is_ancestor(object_index, o_saiga_w))
        loot_corpse = o_empty
}
if instance_exists(o_player)
    alarm[6] = 1
