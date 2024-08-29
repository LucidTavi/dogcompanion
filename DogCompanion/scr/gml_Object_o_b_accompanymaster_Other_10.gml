var _lvl = target.LVL
adjacent_enemies = 0
var R = 1
with (o_enemy)
{
    if (!(scr_instance_exists_in_list(o_b_accompanymaster, buffs)))
    {
        if (id != other.target && HP > 0 && scr_tile_distance(id, other.target) <= R)
            other.adjacent_enemies = 1
    }
}

with (target)
{
    ai_script = gml_Script_scr_enemy_choose_state
    flee_limit = 1
    VSN = 8
    Poison_Immunity = 0
    isLootDropped = 0
    can_drop_loot = 0
    ArmorDurability = 1
    isMiniboss = 0
    can_speak = 0
}
if instance_exists(o_player)
{
    if (check == 3)
    {
        var _shomar = 0
        with (o_enemy)
        {
            if (scr_round_cell(point_distance(x, y, o_player.x, o_player.y)) < 182)
            {
                if (visible & is_visible())
                {
                    if (!(scr_instance_exists_in_list(o_b_accompanymaster, buffs)))
                        _shomar++
                }
            }
        }
        if _shomar
            target.state = "npc combat"
        else
        {
            with (target)
            {
                state = -4
                if ds_list_empty(lock_turn)
                {
                    with (o_controller)
                        mp_grid_clear_cell(grid, (other.x / 26), (other.y / 26))
                    scr_selfcell(0)
                    var access = 0
                    path = path_add()
                    access = mp_grid_path(o_controller.grid, path, x, y, (((o_player.x div 26) * 26) + 13), (((o_player.y div 26) * 26) + 13), true)
                    scr_selfcell(1)
                    if access
                    {
                        var _x = path_get_point_x(path, step)
                        var _y = path_get_point_y(path, step)
                        if (mp_grid_get_cell(o_controller.grid, (_x / 26), (_y / 26)) == 0)
                        {
                            if (xx != _x || yy != _y)
                            {
                                xx = _x
                                yy = _y
                                is_true = 1
                            }
                        }
                    }
                }
            }
        }
    }
    else
    {
        if (check == 1)
        {
            with (target)
            {
                state = -4
                if ds_list_empty(lock_turn)
                {
                    with (o_controller)
                        mp_grid_clear_cell(grid, (other.x / 26), (other.y / 26))
                    scr_selfcell(0)
                    access = 0
                    path = path_add()
                    access = mp_grid_path(o_controller.grid, path, x, y, (((o_player.x div 26) * 26) + 13), (((o_player.y div 26) * 26) + 13), true)
                    scr_selfcell(1)
                    if access
                    {
                        _x = path_get_point_x(path, step)
                        _y = path_get_point_y(path, step)
                        if (mp_grid_get_cell(o_controller.grid, (_x / 26), (_y / 26)) == 0)
                        {
                            if (xx != _x || yy != _y)
                            {
                                xx = _x
                                yy = _y
                                is_true = 1
                            }
                        }
                    }
                }
            }
        }
        else if (check == 0)
            target.state = "npc combat"
        if (check == 2 && (!adjacent_enemies))
        {
            state = -4
            if (selected_positionX && selected_positionY)
            {
                with (target)
                {
                    if other.selected_target
                        state = "npc combat"
                    else
                        state = -4
                    if ds_list_empty(lock_turn)
                    {
                        with (o_controller)
                            mp_grid_clear_cell(grid, (other.x / 26), (other.y / 26))
                        scr_selfcell(0)
                        access = 0
                        path = path_add()
                        access = mp_grid_path(o_controller.grid, path, x, y, (((other.selected_positionX div 26) * 26) + 13), (((other.selected_positionY div 26) * 26) + 13), true)
                        scr_selfcell(1)
                        if access
                        {
                            _x = path_get_point_x(path, step)
                            _y = path_get_point_y(path, step)
                            if (mp_grid_get_cell(o_controller.grid, (_x / 26), (_y / 26)) == 0)
                            {
                                if (xx != _x || yy != _y)
                                {
                                    xx = _x
                                    yy = _y
                                    is_true = 1
                                }
                            }
                        }
                    }
                }
            }
        }
        else if (check == 2 && adjacent_enemies)
            target.state = "npc combat"
    }
}
