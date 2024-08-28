using System.ComponentModel;
using ModShardLauncher;
using ModShardLauncher.Mods;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace DogCompanion;
    public class ScriptSet
    {
        public string Name;
        public string File;
        public EventType Type;
        public uint Subtype;

        public ScriptSet(string myName, string myFile, EventType myType = EventType.Create, uint mySubtype = 0)
        {
            Name = myName;
            File = myFile;
            Type = myType;
            Subtype = mySubtype;
        }
    }

    public class DogCompanion : Mod
    {
        public override string Author => "Lucid Tavi, CommissarAmethyst, BW";
        public override string Name => "Dog Companion";
        public override string Description => "A mercenary's best friend.";
        public override string Version => "0.1.0";

        public override void PatchMod()
        {
            Msl.AddCreditDisclaimerRoom(Name, Author);

            CreateGameObject("o_loot_dogcage", "s_loot_DogCage", "o_consument_loot");

            CreateGameObject("o_inv_dogcage", "s_inv_dogcage", "o_inv_consum_active", true);
            CreateGameObject("o_skill_set_dog", "", "o_skills_like", true);

            CreateGameObject("o_b_accompanymaster", "", "o_class_skills", true);

            CreateGameObject("o_accompany_creator", "", "", false);

            ScriptSet[] scriptsToAdd = new ScriptSet[]
            {
                // Dog cage object
                new ScriptSet("o_loot_dogcage", "gml_Object_o_loot_dogcage_Create_0.gml"),

                new ScriptSet("o_inv_dogcage", "gml_Object_o_inv_dogcage_Create_0.gml"),
                new ScriptSet("o_inv_dogcage", "gml_Object_o_inv_dogcage_Other_24.gml", EventType.Other, 24),

                // Skill setting the dog down from dog cage
                new ScriptSet("o_skill_set_dog", "gml_Object_o_skill_set_dog_Other_25.gml", EventType.Other, 25),
                new ScriptSet("o_skill_set_dog", "gml_Object_o_skill_set_dog_Other_14.gml", EventType.Other, 14),
                new ScriptSet("o_skill_set_dog", "gml_Object_o_skill_set_dog_Other_19.gml", EventType.Other, 19),
                new ScriptSet("o_skill_set_dog", "gml_Object_o_skill_set_dog_Other_15.gml", EventType.Other, 15),
                new ScriptSet("o_skill_set_dog", "gml_Object_o_skill_set_dog_Other_13.gml", EventType.Other, 13),
                new ScriptSet("o_skill_set_dog", "gml_Object_o_skill_set_dog_Other_17.gml", EventType.Other, 17),
                new ScriptSet("o_skill_set_dog", "gml_Object_o_skill_set_dog_Step_0.gml", EventType.Step),
                new ScriptSet("o_skill_set_dog", "gml_Object_o_skill_set_dog_Alarm_1.gml", EventType.Alarm, 1),
                new ScriptSet("o_skill_set_dog", "gml_Object_o_skill_set_dog_Create_0.gml"),
                new ScriptSet("o_skill_set_dog", "gml_Object_o_skill_set_dog_Draw_0.gml", EventType.Draw, 0),

                // Accompany or serve player
                //new ScriptSet("o_b_accompanymaster", "gml_Object_o_b_accompanymaster_Create_0.gml"),
                //new ScriptSet("o_b_accompanymaster", "gml_Object_o_b_accompanymaster_Alarm_2.gml", EventType.Alarm, 2),
                //new ScriptSet("o_b_accompanymaster", "gml_Object_o_b_accompanymaster_Alarm_7.gml", EventType.Alarm, 7),
                //new ScriptSet("o_b_accompanymaster", "gml_Object_o_b_accompanymaster_Alarm_6.gml", EventType.Alarm, 6),
                //new ScriptSet("o_b_accompanymaster", "gml_Object_o_b_accompanymaster_Alarm_8.gml", EventType.Alarm, 8),
                //new ScriptSet("o_b_accompanymaster", "gml_Object_o_b_accompanymaster_Step_0.gml", EventType.Step, 0),
                //new ScriptSet("o_b_accompanymaster", "gml_Object_o_b_accompanymaster_Other_10.gml", EventType.Other, 10),
                //new ScriptSet("o_b_accompanymaster", "gml_Object_o_b_accompanymaster_PreCreate_0.gml", EventType.PreCreate, 0),

                // Accompany or buff player
                //new ScriptSet("o_accompany_creator", "gml_Object_o_accompany_creator_Create_0.gml"),
                //new ScriptSet("o_accompany_creator", "gml_Object_o_accompany_creator_Alarm_1.gml", EventType.Alarm, 1),
                //new ScriptSet("o_accompany_creator", "gml_Object_o_accompany_creator_Alarm_2.gml", EventType.Alarm, 2),
                //new ScriptSet("o_accompany_creator", "gml_Object_o_accompany_creator_PreCreate_0.gml", EventType.PreCreate, 0)
            };

            // Creates all listed scripts
            foreach (var newScript in scriptsToAdd)
            {
                Msl.AddNewEvent(
                    newScript.Name,
                    ModFiles.GetCode(newScript.File),
                    newScript.Type,
                    newScript.Subtype
                );
            }

            // Adds dog cage to the table
            Msl.LoadGML("gml_GlobalScript_table_Modifiers")
                .MatchAll()
                .ReplaceBy(ModFiles, "gml_GlobalScript_table_Modifiers.gml")
                .Save();

            Msl.LoadGML("gml_GlobalScript_scr_penalty_player_attack")
            .MatchFrom("instance_exists(o_player)")
            .InsertAbove("if (faction_id != \"Companion\"){")
            .MatchFrom("return 1")
            .InsertBelow("}")
            .Save();
                    
//            Msl.LoadGML("gml_Object_o_enemy_Mouse_5")
//            .MatchFrom("global.skill_test\nscr_create_context_menu(\"Test_Skill\")")
//            .ReplaceBy(@"if (faction_id == ""Companion"")
//{
//scr_create_context_menu(""Atack"", ""Explore"", ""Swap"")
//}")
//            .Save();

//        Msl.LoadGML("gml_Object_o_Bandit_Draw_0")
//            .MatchFrom("image_index = 0")
//            .InsertBelow(@"if (faction_id == ""Companion"")
//{
//if (object_index == o_bandit_dog01)
//sprite_index = s_bandit_dog01
//if (object_index == o_bandit_dog02)
//sprite_index = s_bandit_dog01
//if (object_index == o_bandit_dog03)
//sprite_index = s_bandit_dog01
//}")
//            .Save();

            // Create faction
            List<string>? ai_table = ModLoader.GetTable("gml_GlobalScript_table_animals_ai");
            List<string> new_ai_elements = new() { 
                "Companion;", 
                "3;", // moose
                "3;", // saiga
                "3;", // deer
                "1;", // bear
                "2;", // wolf
                "1;", // gulon
                "1;", // young troll
                "3;", // fox
                "3;", // boar
                "2;", // bison
                "3;", // squirrel
                "3;", // rabbit
                "3;", // hedgehog
                "3;", // snake
                "1;", // forest buzzer
                "1;", // brigand
                ";", // grandMagistrate
                ";", // rotten willow
                "1;", // undead
                "1;", // vampire
                "1;", // carnivore
                "1;", // omnivore
                "1;", // dog
                "1;", // crawler
                "1;", // harpy
                "Companion;1;1;1;1;1;1;3;1;1;1;1;1;1;1;1;1;;;1;1;1;1;1;1;1;;",
            };
            if (ai_table != null)
            {
                int i;
                for(i = 0; i < ai_table.Count; i++)
                {
                    if (ai_table[i].Contains("1;- Combat")) break;
                    ai_table[i] = ai_table[i] + new_ai_elements[i];
                }
                ai_table.Insert(i, new_ai_elements[i]);
                ModLoader.SetTable(ai_table, "gml_GlobalScript_table_animals_ai");
            }


            // Localization for the description of the dog cage 
            LocalizationItem localizationTable = new(
                "dogcage",
                "Dog Cage",
                "A ~lg~Tool~/~ to release your own war dog.",
                "A mercenary's best friend."
            );
            localizationTable.InjectTable();

            // Adds into the table of consumable for dog cage
            Msl.InjectTableConsumableParameters(Msl.ConsumParamMetaGroup.TOOLS, "dogcage", Msl.ConsumParamCategory.tool, Msl.ConsumParamMaterial.metal, Msl.ConsumParamWeight.Heavy, Msl.ConsumParamSubCategory.none, Msl.ConsumParamTags.common, 300);

            //Msl.InjectTableSkillsStat(Msl.SkillsStatMetaGroup.BEASTS, "set_dog", "o_set_dog", Msl.SkillsStatTarget.TargetPoint, "1", 0, 0, 0, 0, 0, 0, false, Msl.SkillsStatPattern.normal, Msl.SkillsStatClass.skill, false, "", Msl.SkillsStatBranch.none, false, false, Msl.SkillsStatMetacategory.none, 0, "", false, false, false, false, false);

            // Sell to traders - test
            Msl.LoadGML("gml_Object_o_npc_Innkeeper_Create_0")
                .MatchAll()
                .InsertBelow("ds_list_add(selling_loot_object, choose(o_inv_dogcage), 5)")
                .Save();

            UndertaleSprite s_wardog_set_indicator = Msl.GetSprite("s_wardog_set_indicator");
            s_wardog_set_indicator.OriginX = 26;
            s_wardog_set_indicator.OriginY = 15;
            s_wardog_set_indicator.IsSpecialType = true;
            s_wardog_set_indicator.SVersion = 3;
            s_wardog_set_indicator.GMS2PlaybackSpeed = 1f;
            s_wardog_set_indicator.GMS2PlaybackSpeedType = AnimSpeedType.FramesPerGameFrame;

            base.PatchMod();
        }
        public UndertaleGameObject CreateGameObject(string objName, string sprName = "", string perName = "", bool persistent = false, bool awake = true)
        {
            UndertaleGameObject tempObject = Msl.AddObject(objName);
            if (sprName != "")
                tempObject.Sprite = Msl.GetSprite(sprName);
            tempObject.Visible = true;
            if (perName != "")
                tempObject.ParentId = Msl.GetObject(perName);
            tempObject.Persistent = persistent;
            tempObject.Awake = awake;
            return tempObject;
        }
    
}