#! /usr/bin/env python

from gimpfu import *

import os
import re

def create_thumbnail(file_name) :
    timg = gimp.image_list()[0]
    shadow_layer = timg.active_layer.copy()
    shadow_layer.name = "shadow"
    pdb.gimp_image_add_layer(timg, shadow_layer, 1)
    pdb.plug_in_gauss_rle2(timg, shadow_layer, 25, 25)
    pdb.gimp_brightness_contrast(shadow_layer, -127, 127)
    pdb.plug_in_autocrop(timg, shadow_layer)
    pdb.gimp_xcf_save(0, timg, shadow_layer, file_name + ".xcf", file_name)
    merged_layer = pdb.gimp_image_merge_visible_layers(timg, CLIP_TO_IMAGE)
    pdb.file_png_save_defaults(timg, merged_layer, file_name + ".png", file_name)

register (
    "createThumbnail",         # Name registered in Procedure Browser
    "Creates level thumbnail", # Widget title
    "Creates level thumbnail", # 
    "Jakub Gruszecki",         # Author
    "Jakub Gruszecki",         # Copyright Holder
    "December 2017",            # Date
    "Create thumbnail", # Menu Entry
    "*",     # Image Type - No image required
    [
        (PF_FILE, "file_name", "Save as", "Level00")
    ],
    [],
    create_thumbnail,   # Matches to name of function being defined
    menu = "<Image>/Marbles"  # Menu Location
    )   # End register

main()