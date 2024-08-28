event_inherited()
if is_activate
{
    var _x = scr_round_cell(mouse_x)
    var _y = scr_round_cell(mouse_y)
    if (scr_tile_distance_xy(o_player.x, o_player.y, _x, _y) <= 2)
        draw_sprite_ext(s_wardog_set_indicator, scr_pat_prototype(_x, _y, 0, 0), (scr_screenX((_x + 13)) + -5000), (scr_screenY((_y + 13)) + -5000), 1, 1, 0, c_white, 0.6)
}
