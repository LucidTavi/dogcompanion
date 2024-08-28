is_ready = 1
if instance_exists(owner)
{
    if (!ds_list_empty(owner.lock_items))
        is_ready = 0
}
