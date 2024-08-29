alarm[7] = 1
if instance_exists(target)
{
    with (target)
    {
        if is_flying
            is_flying = 0
    }
}
