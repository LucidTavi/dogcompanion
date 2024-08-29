if is_activate
{
    var _x = scr_round_cell(mouse_x)
    var _y = scr_round_cell(mouse_y)
    if (scr_tile_distance_xy(o_player.x, o_player.y, _x, _y) <= 1 && (!(ds_grid_get(o_controller.markgrid, (_x div 26), (_y div 26)))) && (!(ds_grid_get(o_controller.posgrid, (_x div 26), (_y div 26)))))
    {
        distance_check = 1
        draw_sprite(s_wardog_set_indicator, scr_pat_prototype(_x, _y, 0, 0), scr_round_cell(mouse_x), scr_round_cell(mouse_y))
    }
    else
        distance_check = 0
}
