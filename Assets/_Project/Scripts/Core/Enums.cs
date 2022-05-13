using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Core
{
    public enum Genders
    {
        Male, Female,
        Number, None
    }

    public enum EquipmentSlot
    {
        Right_Hand, Left_Hand, Head, Armor, Back, Hands, Feet, Neck, Finger_Left, Finger_Right,
        Number, None
    }
    
    public enum SkillCategory
    {
        Combat, Magic, Utility,
        Number, None
    }

    public enum ItemType
    {
        Head_Armor, Backpack, Cloak, Armor, Hand_Armor, Foot_Armor, 
        Finger, Necklace,
        Shield,
        Ammo,
        Sword, Axe, Dagger, Hammer, Mace, Staff, Scepter, Polearm, Firearm, Instrument, Bow,
        Potion, Drink, Food, Bomb, Scroll, Spellbook,
        Ingredient, 
        Number, None
    }

    public enum ItemNameFormat
    {
        Material_First, Material_Middle, Material_Last,
        Number, None
    }

    public enum ItemMaterialAllowed
    {
        Any, Hard, Soft, Wood, Stone, Metal, Cloth, Leather, Food, Drink, Potion, Paper, Book,
        Number, None
    }

    public enum Hands
    {
        Left, Right, Both, Either,
        Number, None
    }
    
    public enum AccessoryType
    {
        Food, Drink, Potion, Scroll, Spellbook, Bomb,
        Number, None
    }
    
    public enum ItemCategory { Accessories, Ammo, Ingredient, Shields, Weapons, Wearable, Number, None }

    public enum GenerateItemType
    {
        Head_Armor, Backpack, Cloak, Ammo, Armor, Hand_Armor, Foot_Armor, Finger, Necklace,
        Shield,
        Arrow,
        Axe, Bow, Dagger, Firearm, Hammer, Instrument, Mace, Polearm, Scepter, Staff, Sword,
        Potion, Drink, Food, Bomb, Scroll, Spellbook,
        Any, Any_Weapon, Any_Armor, Any_Shield, Any_Accessory,
        Number, None
    }

    public enum ItemMaterialType
    {
        Leather, Cloth, Wood, Stone, Metal, Organic, Food, Drink, Potion, Paper, Book,
        Number, None
    }

    public enum EnchantmentType
    {
        Quality, Prefix, Suffix,
        Number, None
    }
    
    public enum WearableType
    {
        Head, Armor, Gloves, Feet, Back, Neck, Finger, 
        Number, None
    }

    public enum HeadCoverType
    {
        Full_Head, Hair, No_Hair, No_Facial_Hair,
        Number, None
    }

    public enum EnchantmentUsability
    {
        Permanent, Usable,
        Number, None
    }

    public enum GameScenes
    {
        Main_Menu, Overworld, Underground,
        Number, None
    }
    
    public enum EnemyGroups
    {
        Goblinoid, Undead, Viking, Bandit,
        Number, None
    }

    public enum Directions
    {
        North, East, South, West, Number, None
    }

    public enum GameEntityTypes
    {
        Hero, Enemy,
        Number, None
    }
}