// -------------------------------------------------------------------------------------------------------------------
// Generated code, do not edit
// Command Line:  DomGen "DotaObjects.xsd" "DotaObjectsSchema.cs" "Worldsmith" "WorldsmithATF"
// -------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

using Sce.Atf.Dom;

namespace WorldsmithATF
{
    public static class DotaObjectsSchema
    {
        public const string NS = "Worldsmith";

        public static void Initialize(XmlSchemaTypeCollection typeCollection)
        {
            Initialize((ns,name)=>typeCollection.GetNodeType(ns,name),
                (ns,name)=>typeCollection.GetRootElement(ns,name));
        }

        public static void Initialize(IDictionary<string, XmlSchemaTypeCollection> typeCollections)
        {
            Initialize((ns,name)=>typeCollections[ns].GetNodeType(name),
                (ns,name)=>typeCollections[ns].GetRootElement(name));
        }

        private static void Initialize(Func<string, string, DomNodeType> getNodeType, Func<string, string, ChildInfo> getRootElement)
        {
            ProjectType.Type = getNodeType("Worldsmith", "ProjectType");
            ProjectType.NameAttribute = ProjectType.Type.GetAttributeInfo("Name");
            ProjectType.FilesChild = ProjectType.Type.GetChildInfo("Files");

            FileType.Type = getNodeType("Worldsmith", "FileType");
            FileType.PathAttribute = FileType.Type.GetAttributeInfo("Path");

            FolderType.Type = getNodeType("Worldsmith", "FolderType");
            FolderType.PathAttribute = FolderType.Type.GetAttributeInfo("Path");

            TextFileType.Type = getNodeType("Worldsmith", "TextFileType");
            TextFileType.PathAttribute = TextFileType.Type.GetAttributeInfo("Path");

            KVDocumentType.Type = getNodeType("Worldsmith", "KVDocumentType");
            KVDocumentType.PathAttribute = KVDocumentType.Type.GetAttributeInfo("Path");

            MapType.Type = getNodeType("Worldsmith", "MapType");
            MapType.PathAttribute = MapType.Type.GetAttributeInfo("Path");

            DotaUnitContainerType.Type = getNodeType("Worldsmith", "DotaUnitContainerType");
            DotaUnitContainerType.ContentsChild = DotaUnitContainerType.Type.GetChildInfo("Contents");

            DotaUnitType.Type = getNodeType("Worldsmith", "DotaUnitType");
            DotaUnitType.ClassNameAttribute = DotaUnitType.Type.GetAttributeInfo("ClassName");
            DotaUnitType.BaseClassAttribute = DotaUnitType.Type.GetAttributeInfo("BaseClass");
            DotaUnitType.ModelAttribute = DotaUnitType.Type.GetAttributeInfo("Model");
            DotaUnitType.SoundSetAttribute = DotaUnitType.Type.GetAttributeInfo("SoundSet");
            DotaUnitType.LevelAttribute = DotaUnitType.Type.GetAttributeInfo("Level");
            DotaUnitType.AbilityLayoutAttribute = DotaUnitType.Type.GetAttributeInfo("AbilityLayout");
            DotaUnitType.Ability1Attribute = DotaUnitType.Type.GetAttributeInfo("Ability1");
            DotaUnitType.Ability2Attribute = DotaUnitType.Type.GetAttributeInfo("Ability2");
            DotaUnitType.Ability3Attribute = DotaUnitType.Type.GetAttributeInfo("Ability3");
            DotaUnitType.Ability4Attribute = DotaUnitType.Type.GetAttributeInfo("Ability4");
            DotaUnitType.Ability5Attribute = DotaUnitType.Type.GetAttributeInfo("Ability5");
            DotaUnitType.Ability6Attribute = DotaUnitType.Type.GetAttributeInfo("Ability6");
            DotaUnitType.Ability7Attribute = DotaUnitType.Type.GetAttributeInfo("Ability7");
            DotaUnitType.Ability8Attribute = DotaUnitType.Type.GetAttributeInfo("Ability8");
            DotaUnitType.ArmorPhysicalAttribute = DotaUnitType.Type.GetAttributeInfo("ArmorPhysical");
            DotaUnitType.MagicalResistanceAttribute = DotaUnitType.Type.GetAttributeInfo("MagicalResistance");
            DotaUnitType.AttackCapabilitiesAttribute = DotaUnitType.Type.GetAttributeInfo("AttackCapabilities");
            DotaUnitType.AttackDamageMinAttribute = DotaUnitType.Type.GetAttributeInfo("AttackDamageMin");
            DotaUnitType.AttackDamageMaxAttribute = DotaUnitType.Type.GetAttributeInfo("AttackDamageMax");
            DotaUnitType.AttackDamageTypeAttribute = DotaUnitType.Type.GetAttributeInfo("AttackDamageType");
            DotaUnitType.AttackRateAttribute = DotaUnitType.Type.GetAttributeInfo("AttackRate");
            DotaUnitType.AttackAnimationPointAttribute = DotaUnitType.Type.GetAttributeInfo("AttackAnimationPoint");
            DotaUnitType.AttackAcquisitionRangeAttribute = DotaUnitType.Type.GetAttributeInfo("AttackAcquisitionRange");
            DotaUnitType.AttackRangeAttribute = DotaUnitType.Type.GetAttributeInfo("AttackRange");
            DotaUnitType.ProjectileModelAttribute = DotaUnitType.Type.GetAttributeInfo("ProjectileModel");
            DotaUnitType.ProjectileSpeedAttribute = DotaUnitType.Type.GetAttributeInfo("ProjectileSpeed");
            DotaUnitType.AttributePrimaryAttribute = DotaUnitType.Type.GetAttributeInfo("AttributePrimary");
            DotaUnitType.AttributeBaseStrengthAttribute = DotaUnitType.Type.GetAttributeInfo("AttributeBaseStrength");
            DotaUnitType.AttributeStrengthGainAttribute = DotaUnitType.Type.GetAttributeInfo("AttributeStrengthGain");
            DotaUnitType.AttributeBaseIntelligenceAttribute = DotaUnitType.Type.GetAttributeInfo("AttributeBaseIntelligence");
            DotaUnitType.AttributeIntelligenceGainAttribute = DotaUnitType.Type.GetAttributeInfo("AttributeIntelligenceGain");
            DotaUnitType.AttributeBaseAgilityAttribute = DotaUnitType.Type.GetAttributeInfo("AttributeBaseAgility");
            DotaUnitType.AttributeAgilityGainAttribute = DotaUnitType.Type.GetAttributeInfo("AttributeAgilityGain");
            DotaUnitType.BountyXPAttribute = DotaUnitType.Type.GetAttributeInfo("BountyXP");
            DotaUnitType.BountyGoldMinAttribute = DotaUnitType.Type.GetAttributeInfo("BountyGoldMin");
            DotaUnitType.BountyGoldMaxAttribute = DotaUnitType.Type.GetAttributeInfo("BountyGoldMax");
            DotaUnitType.BoundsHullNameAttribute = DotaUnitType.Type.GetAttributeInfo("BoundsHullName");
            DotaUnitType.RingRadiusAttribute = DotaUnitType.Type.GetAttributeInfo("RingRadius");
            DotaUnitType.MovementCapabilitiesAttribute = DotaUnitType.Type.GetAttributeInfo("MovementCapabilities");
            DotaUnitType.MovementSpeedAttribute = DotaUnitType.Type.GetAttributeInfo("MovementSpeed");
            DotaUnitType.MovementTurnRateAttribute = DotaUnitType.Type.GetAttributeInfo("MovementTurnRate");
            DotaUnitType.HasAggressiveStanceAttribute = DotaUnitType.Type.GetAttributeInfo("HasAggressiveStance");
            DotaUnitType.StatusHealthAttribute = DotaUnitType.Type.GetAttributeInfo("StatusHealth");
            DotaUnitType.StatusHealthRegenAttribute = DotaUnitType.Type.GetAttributeInfo("StatusHealthRegen");
            DotaUnitType.StatusManaAttribute = DotaUnitType.Type.GetAttributeInfo("StatusMana");
            DotaUnitType.StatusManaRegenAttribute = DotaUnitType.Type.GetAttributeInfo("StatusManaRegen");
            DotaUnitType.StatusStartingManaAttribute = DotaUnitType.Type.GetAttributeInfo("StatusStartingMana");
            DotaUnitType.TeamNameAttribute = DotaUnitType.Type.GetAttributeInfo("TeamName");
            DotaUnitType.CombatClassAttackAttribute = DotaUnitType.Type.GetAttributeInfo("CombatClassAttack");
            DotaUnitType.CombatClassDefendAttribute = DotaUnitType.Type.GetAttributeInfo("CombatClassDefend");
            DotaUnitType.UnitRelationshipClassAttribute = DotaUnitType.Type.GetAttributeInfo("UnitRelationshipClass");
            DotaUnitType.VisionDaytimeRangeAttribute = DotaUnitType.Type.GetAttributeInfo("VisionDaytimeRange");
            DotaUnitType.VisionNighttimeRangeAttribute = DotaUnitType.Type.GetAttributeInfo("VisionNighttimeRange");
            DotaUnitType.HasInventoryAttribute = DotaUnitType.Type.GetAttributeInfo("HasInventory");
            DotaUnitType.HealthBarOffsetAttribute = DotaUnitType.Type.GetAttributeInfo("HealthBarOffset");
            DotaUnitType.IdleSoundLoopAttribute = DotaUnitType.Type.GetAttributeInfo("IdleSoundLoop");
            DotaUnitType.IsAncientAttribute = DotaUnitType.Type.GetAttributeInfo("IsAncient");
            DotaUnitType.IsNeutralUnitTypeAttribute = DotaUnitType.Type.GetAttributeInfo("IsNeutralUnitType");
            DotaUnitType.SelectionGroupAttribute = DotaUnitType.Type.GetAttributeInfo("SelectionGroup");
            DotaUnitType.SelectOnSpawnAttribute = DotaUnitType.Type.GetAttributeInfo("SelectOnSpawn");
            DotaUnitType.CanBeDominatedAttribute = DotaUnitType.Type.GetAttributeInfo("CanBeDominated");
            DotaUnitType.IgnoreAddSummonedToSelectionAttribute = DotaUnitType.Type.GetAttributeInfo("IgnoreAddSummonedToSelection");
            DotaUnitType.AutoAttacksByDefaultAttribute = DotaUnitType.Type.GetAttributeInfo("AutoAttacksByDefault");
            DotaUnitType.AttackRangeBufferAttribute = DotaUnitType.Type.GetAttributeInfo("AttackRangeBuffer");
            DotaUnitType.FollowRangeAttribute = DotaUnitType.Type.GetAttributeInfo("FollowRange");
            DotaUnitType.AttackDesireAttribute = DotaUnitType.Type.GetAttributeInfo("AttackDesire");
            DotaUnitType.WakesNeutralsAttribute = DotaUnitType.Type.GetAttributeInfo("WakesNeutrals");

            DotaBaseUnitType.Type = getNodeType("Worldsmith", "DotaBaseUnitType");
            DotaBaseUnitType.ClassNameAttribute = DotaBaseUnitType.Type.GetAttributeInfo("ClassName");
            DotaBaseUnitType.BaseClassAttribute = DotaBaseUnitType.Type.GetAttributeInfo("BaseClass");
            DotaBaseUnitType.ModelAttribute = DotaBaseUnitType.Type.GetAttributeInfo("Model");
            DotaBaseUnitType.SoundSetAttribute = DotaBaseUnitType.Type.GetAttributeInfo("SoundSet");
            DotaBaseUnitType.LevelAttribute = DotaBaseUnitType.Type.GetAttributeInfo("Level");
            DotaBaseUnitType.AbilityLayoutAttribute = DotaBaseUnitType.Type.GetAttributeInfo("AbilityLayout");
            DotaBaseUnitType.Ability1Attribute = DotaBaseUnitType.Type.GetAttributeInfo("Ability1");
            DotaBaseUnitType.Ability2Attribute = DotaBaseUnitType.Type.GetAttributeInfo("Ability2");
            DotaBaseUnitType.Ability3Attribute = DotaBaseUnitType.Type.GetAttributeInfo("Ability3");
            DotaBaseUnitType.Ability4Attribute = DotaBaseUnitType.Type.GetAttributeInfo("Ability4");
            DotaBaseUnitType.Ability5Attribute = DotaBaseUnitType.Type.GetAttributeInfo("Ability5");
            DotaBaseUnitType.Ability6Attribute = DotaBaseUnitType.Type.GetAttributeInfo("Ability6");
            DotaBaseUnitType.Ability7Attribute = DotaBaseUnitType.Type.GetAttributeInfo("Ability7");
            DotaBaseUnitType.Ability8Attribute = DotaBaseUnitType.Type.GetAttributeInfo("Ability8");
            DotaBaseUnitType.ArmorPhysicalAttribute = DotaBaseUnitType.Type.GetAttributeInfo("ArmorPhysical");
            DotaBaseUnitType.MagicalResistanceAttribute = DotaBaseUnitType.Type.GetAttributeInfo("MagicalResistance");
            DotaBaseUnitType.AttackCapabilitiesAttribute = DotaBaseUnitType.Type.GetAttributeInfo("AttackCapabilities");
            DotaBaseUnitType.AttackDamageMinAttribute = DotaBaseUnitType.Type.GetAttributeInfo("AttackDamageMin");
            DotaBaseUnitType.AttackDamageMaxAttribute = DotaBaseUnitType.Type.GetAttributeInfo("AttackDamageMax");
            DotaBaseUnitType.AttackDamageTypeAttribute = DotaBaseUnitType.Type.GetAttributeInfo("AttackDamageType");
            DotaBaseUnitType.AttackRateAttribute = DotaBaseUnitType.Type.GetAttributeInfo("AttackRate");
            DotaBaseUnitType.AttackAnimationPointAttribute = DotaBaseUnitType.Type.GetAttributeInfo("AttackAnimationPoint");
            DotaBaseUnitType.AttackAcquisitionRangeAttribute = DotaBaseUnitType.Type.GetAttributeInfo("AttackAcquisitionRange");
            DotaBaseUnitType.AttackRangeAttribute = DotaBaseUnitType.Type.GetAttributeInfo("AttackRange");
            DotaBaseUnitType.ProjectileModelAttribute = DotaBaseUnitType.Type.GetAttributeInfo("ProjectileModel");
            DotaBaseUnitType.ProjectileSpeedAttribute = DotaBaseUnitType.Type.GetAttributeInfo("ProjectileSpeed");
            DotaBaseUnitType.AttributePrimaryAttribute = DotaBaseUnitType.Type.GetAttributeInfo("AttributePrimary");
            DotaBaseUnitType.AttributeBaseStrengthAttribute = DotaBaseUnitType.Type.GetAttributeInfo("AttributeBaseStrength");
            DotaBaseUnitType.AttributeStrengthGainAttribute = DotaBaseUnitType.Type.GetAttributeInfo("AttributeStrengthGain");
            DotaBaseUnitType.AttributeBaseIntelligenceAttribute = DotaBaseUnitType.Type.GetAttributeInfo("AttributeBaseIntelligence");
            DotaBaseUnitType.AttributeIntelligenceGainAttribute = DotaBaseUnitType.Type.GetAttributeInfo("AttributeIntelligenceGain");
            DotaBaseUnitType.AttributeBaseAgilityAttribute = DotaBaseUnitType.Type.GetAttributeInfo("AttributeBaseAgility");
            DotaBaseUnitType.AttributeAgilityGainAttribute = DotaBaseUnitType.Type.GetAttributeInfo("AttributeAgilityGain");
            DotaBaseUnitType.BountyXPAttribute = DotaBaseUnitType.Type.GetAttributeInfo("BountyXP");
            DotaBaseUnitType.BountyGoldMinAttribute = DotaBaseUnitType.Type.GetAttributeInfo("BountyGoldMin");
            DotaBaseUnitType.BountyGoldMaxAttribute = DotaBaseUnitType.Type.GetAttributeInfo("BountyGoldMax");
            DotaBaseUnitType.BoundsHullNameAttribute = DotaBaseUnitType.Type.GetAttributeInfo("BoundsHullName");
            DotaBaseUnitType.RingRadiusAttribute = DotaBaseUnitType.Type.GetAttributeInfo("RingRadius");
            DotaBaseUnitType.MovementCapabilitiesAttribute = DotaBaseUnitType.Type.GetAttributeInfo("MovementCapabilities");
            DotaBaseUnitType.MovementSpeedAttribute = DotaBaseUnitType.Type.GetAttributeInfo("MovementSpeed");
            DotaBaseUnitType.MovementTurnRateAttribute = DotaBaseUnitType.Type.GetAttributeInfo("MovementTurnRate");
            DotaBaseUnitType.HasAggressiveStanceAttribute = DotaBaseUnitType.Type.GetAttributeInfo("HasAggressiveStance");
            DotaBaseUnitType.StatusHealthAttribute = DotaBaseUnitType.Type.GetAttributeInfo("StatusHealth");
            DotaBaseUnitType.StatusHealthRegenAttribute = DotaBaseUnitType.Type.GetAttributeInfo("StatusHealthRegen");
            DotaBaseUnitType.StatusManaAttribute = DotaBaseUnitType.Type.GetAttributeInfo("StatusMana");
            DotaBaseUnitType.StatusManaRegenAttribute = DotaBaseUnitType.Type.GetAttributeInfo("StatusManaRegen");
            DotaBaseUnitType.StatusStartingManaAttribute = DotaBaseUnitType.Type.GetAttributeInfo("StatusStartingMana");
            DotaBaseUnitType.TeamNameAttribute = DotaBaseUnitType.Type.GetAttributeInfo("TeamName");
            DotaBaseUnitType.CombatClassAttackAttribute = DotaBaseUnitType.Type.GetAttributeInfo("CombatClassAttack");
            DotaBaseUnitType.CombatClassDefendAttribute = DotaBaseUnitType.Type.GetAttributeInfo("CombatClassDefend");
            DotaBaseUnitType.UnitRelationshipClassAttribute = DotaBaseUnitType.Type.GetAttributeInfo("UnitRelationshipClass");
            DotaBaseUnitType.VisionDaytimeRangeAttribute = DotaBaseUnitType.Type.GetAttributeInfo("VisionDaytimeRange");
            DotaBaseUnitType.VisionNighttimeRangeAttribute = DotaBaseUnitType.Type.GetAttributeInfo("VisionNighttimeRange");
            DotaBaseUnitType.HasInventoryAttribute = DotaBaseUnitType.Type.GetAttributeInfo("HasInventory");
            DotaBaseUnitType.HealthBarOffsetAttribute = DotaBaseUnitType.Type.GetAttributeInfo("HealthBarOffset");
            DotaBaseUnitType.IdleSoundLoopAttribute = DotaBaseUnitType.Type.GetAttributeInfo("IdleSoundLoop");

            DotaDataObjectType.Type = getNodeType("Worldsmith", "DotaDataObjectType");
            DotaDataObjectType.ClassNameAttribute = DotaDataObjectType.Type.GetAttributeInfo("ClassName");
            DotaDataObjectType.BaseClassAttribute = DotaDataObjectType.Type.GetAttributeInfo("BaseClass");

            DefaultUnitContainerType.Type = getNodeType("Worldsmith", "DefaultUnitContainerType");
            DefaultUnitContainerType.ContentsChild = DefaultUnitContainerType.Type.GetChildInfo("Contents");

            DotaHeroType.Type = getNodeType("Worldsmith", "DotaHeroType");
            DotaHeroType.ClassNameAttribute = DotaHeroType.Type.GetAttributeInfo("ClassName");
            DotaHeroType.BaseClassAttribute = DotaHeroType.Type.GetAttributeInfo("BaseClass");
            DotaHeroType.ModelAttribute = DotaHeroType.Type.GetAttributeInfo("Model");
            DotaHeroType.SoundSetAttribute = DotaHeroType.Type.GetAttributeInfo("SoundSet");
            DotaHeroType.LevelAttribute = DotaHeroType.Type.GetAttributeInfo("Level");
            DotaHeroType.AbilityLayoutAttribute = DotaHeroType.Type.GetAttributeInfo("AbilityLayout");
            DotaHeroType.Ability1Attribute = DotaHeroType.Type.GetAttributeInfo("Ability1");
            DotaHeroType.Ability2Attribute = DotaHeroType.Type.GetAttributeInfo("Ability2");
            DotaHeroType.Ability3Attribute = DotaHeroType.Type.GetAttributeInfo("Ability3");
            DotaHeroType.Ability4Attribute = DotaHeroType.Type.GetAttributeInfo("Ability4");
            DotaHeroType.Ability5Attribute = DotaHeroType.Type.GetAttributeInfo("Ability5");
            DotaHeroType.Ability6Attribute = DotaHeroType.Type.GetAttributeInfo("Ability6");
            DotaHeroType.Ability7Attribute = DotaHeroType.Type.GetAttributeInfo("Ability7");
            DotaHeroType.Ability8Attribute = DotaHeroType.Type.GetAttributeInfo("Ability8");
            DotaHeroType.ArmorPhysicalAttribute = DotaHeroType.Type.GetAttributeInfo("ArmorPhysical");
            DotaHeroType.MagicalResistanceAttribute = DotaHeroType.Type.GetAttributeInfo("MagicalResistance");
            DotaHeroType.AttackCapabilitiesAttribute = DotaHeroType.Type.GetAttributeInfo("AttackCapabilities");
            DotaHeroType.AttackDamageMinAttribute = DotaHeroType.Type.GetAttributeInfo("AttackDamageMin");
            DotaHeroType.AttackDamageMaxAttribute = DotaHeroType.Type.GetAttributeInfo("AttackDamageMax");
            DotaHeroType.AttackDamageTypeAttribute = DotaHeroType.Type.GetAttributeInfo("AttackDamageType");
            DotaHeroType.AttackRateAttribute = DotaHeroType.Type.GetAttributeInfo("AttackRate");
            DotaHeroType.AttackAnimationPointAttribute = DotaHeroType.Type.GetAttributeInfo("AttackAnimationPoint");
            DotaHeroType.AttackAcquisitionRangeAttribute = DotaHeroType.Type.GetAttributeInfo("AttackAcquisitionRange");
            DotaHeroType.AttackRangeAttribute = DotaHeroType.Type.GetAttributeInfo("AttackRange");
            DotaHeroType.ProjectileModelAttribute = DotaHeroType.Type.GetAttributeInfo("ProjectileModel");
            DotaHeroType.ProjectileSpeedAttribute = DotaHeroType.Type.GetAttributeInfo("ProjectileSpeed");
            DotaHeroType.AttributePrimaryAttribute = DotaHeroType.Type.GetAttributeInfo("AttributePrimary");
            DotaHeroType.AttributeBaseStrengthAttribute = DotaHeroType.Type.GetAttributeInfo("AttributeBaseStrength");
            DotaHeroType.AttributeStrengthGainAttribute = DotaHeroType.Type.GetAttributeInfo("AttributeStrengthGain");
            DotaHeroType.AttributeBaseIntelligenceAttribute = DotaHeroType.Type.GetAttributeInfo("AttributeBaseIntelligence");
            DotaHeroType.AttributeIntelligenceGainAttribute = DotaHeroType.Type.GetAttributeInfo("AttributeIntelligenceGain");
            DotaHeroType.AttributeBaseAgilityAttribute = DotaHeroType.Type.GetAttributeInfo("AttributeBaseAgility");
            DotaHeroType.AttributeAgilityGainAttribute = DotaHeroType.Type.GetAttributeInfo("AttributeAgilityGain");
            DotaHeroType.BountyXPAttribute = DotaHeroType.Type.GetAttributeInfo("BountyXP");
            DotaHeroType.BountyGoldMinAttribute = DotaHeroType.Type.GetAttributeInfo("BountyGoldMin");
            DotaHeroType.BountyGoldMaxAttribute = DotaHeroType.Type.GetAttributeInfo("BountyGoldMax");
            DotaHeroType.BoundsHullNameAttribute = DotaHeroType.Type.GetAttributeInfo("BoundsHullName");
            DotaHeroType.RingRadiusAttribute = DotaHeroType.Type.GetAttributeInfo("RingRadius");
            DotaHeroType.MovementCapabilitiesAttribute = DotaHeroType.Type.GetAttributeInfo("MovementCapabilities");
            DotaHeroType.MovementSpeedAttribute = DotaHeroType.Type.GetAttributeInfo("MovementSpeed");
            DotaHeroType.MovementTurnRateAttribute = DotaHeroType.Type.GetAttributeInfo("MovementTurnRate");
            DotaHeroType.HasAggressiveStanceAttribute = DotaHeroType.Type.GetAttributeInfo("HasAggressiveStance");
            DotaHeroType.StatusHealthAttribute = DotaHeroType.Type.GetAttributeInfo("StatusHealth");
            DotaHeroType.StatusHealthRegenAttribute = DotaHeroType.Type.GetAttributeInfo("StatusHealthRegen");
            DotaHeroType.StatusManaAttribute = DotaHeroType.Type.GetAttributeInfo("StatusMana");
            DotaHeroType.StatusManaRegenAttribute = DotaHeroType.Type.GetAttributeInfo("StatusManaRegen");
            DotaHeroType.StatusStartingManaAttribute = DotaHeroType.Type.GetAttributeInfo("StatusStartingMana");
            DotaHeroType.TeamNameAttribute = DotaHeroType.Type.GetAttributeInfo("TeamName");
            DotaHeroType.CombatClassAttackAttribute = DotaHeroType.Type.GetAttributeInfo("CombatClassAttack");
            DotaHeroType.CombatClassDefendAttribute = DotaHeroType.Type.GetAttributeInfo("CombatClassDefend");
            DotaHeroType.UnitRelationshipClassAttribute = DotaHeroType.Type.GetAttributeInfo("UnitRelationshipClass");
            DotaHeroType.VisionDaytimeRangeAttribute = DotaHeroType.Type.GetAttributeInfo("VisionDaytimeRange");
            DotaHeroType.VisionNighttimeRangeAttribute = DotaHeroType.Type.GetAttributeInfo("VisionNighttimeRange");
            DotaHeroType.HasInventoryAttribute = DotaHeroType.Type.GetAttributeInfo("HasInventory");
            DotaHeroType.HealthBarOffsetAttribute = DotaHeroType.Type.GetAttributeInfo("HealthBarOffset");
            DotaHeroType.IdleSoundLoopAttribute = DotaHeroType.Type.GetAttributeInfo("IdleSoundLoop");
            DotaHeroType.EnabledAttribute = DotaHeroType.Type.GetAttributeInfo("Enabled");
            DotaHeroType.BotImplementedAttribute = DotaHeroType.Type.GetAttributeInfo("BotImplemented");
            DotaHeroType.NewHeroAttribute = DotaHeroType.Type.GetAttributeInfo("NewHero");
            DotaHeroType.HeroPool1Attribute = DotaHeroType.Type.GetAttributeInfo("HeroPool1");
            DotaHeroType.HeroUnlockOrderAttribute = DotaHeroType.Type.GetAttributeInfo("HeroUnlockOrder");
            DotaHeroType.CMEnabledAttribute = DotaHeroType.Type.GetAttributeInfo("CMEnabled");
            DotaHeroType.CMTournamentIgnoreAttribute = DotaHeroType.Type.GetAttributeInfo("CMTournamentIgnore");
            DotaHeroType.new_player_enableAttribute = DotaHeroType.Type.GetAttributeInfo("new_player_enable");
            DotaHeroType.VoiceBackgroundSoundAttribute = DotaHeroType.Type.GetAttributeInfo("VoiceBackgroundSound");
            DotaHeroType.IdleExpressionAttribute = DotaHeroType.Type.GetAttributeInfo("IdleExpression");
            DotaHeroType.HUDAttribute = DotaHeroType.Type.GetAttributeInfo("HUD");
            DotaHeroType.override_heroAttribute = DotaHeroType.Type.GetAttributeInfo("override_hero");

        }

        public static class ProjectType
        {
            public static DomNodeType Type;
            public static AttributeInfo NameAttribute;
            public static ChildInfo FilesChild;
        }

        public static class FileType
        {
            public static DomNodeType Type;
            public static AttributeInfo PathAttribute;
        }

        public static class FolderType
        {
            public static DomNodeType Type;
            public static AttributeInfo PathAttribute;
        }

        public static class TextFileType
        {
            public static DomNodeType Type;
            public static AttributeInfo PathAttribute;
        }

        public static class KVDocumentType
        {
            public static DomNodeType Type;
            public static AttributeInfo PathAttribute;
        }

        public static class MapType
        {
            public static DomNodeType Type;
            public static AttributeInfo PathAttribute;
        }

        public static class DotaUnitContainerType
        {
            public static DomNodeType Type;
            public static ChildInfo ContentsChild;
        }

        public static class DotaUnitType
        {
            public static DomNodeType Type;
            public static AttributeInfo ClassNameAttribute;
            public static AttributeInfo BaseClassAttribute;
            public static AttributeInfo ModelAttribute;
            public static AttributeInfo SoundSetAttribute;
            public static AttributeInfo LevelAttribute;
            public static AttributeInfo AbilityLayoutAttribute;
            public static AttributeInfo Ability1Attribute;
            public static AttributeInfo Ability2Attribute;
            public static AttributeInfo Ability3Attribute;
            public static AttributeInfo Ability4Attribute;
            public static AttributeInfo Ability5Attribute;
            public static AttributeInfo Ability6Attribute;
            public static AttributeInfo Ability7Attribute;
            public static AttributeInfo Ability8Attribute;
            public static AttributeInfo ArmorPhysicalAttribute;
            public static AttributeInfo MagicalResistanceAttribute;
            public static AttributeInfo AttackCapabilitiesAttribute;
            public static AttributeInfo AttackDamageMinAttribute;
            public static AttributeInfo AttackDamageMaxAttribute;
            public static AttributeInfo AttackDamageTypeAttribute;
            public static AttributeInfo AttackRateAttribute;
            public static AttributeInfo AttackAnimationPointAttribute;
            public static AttributeInfo AttackAcquisitionRangeAttribute;
            public static AttributeInfo AttackRangeAttribute;
            public static AttributeInfo ProjectileModelAttribute;
            public static AttributeInfo ProjectileSpeedAttribute;
            public static AttributeInfo AttributePrimaryAttribute;
            public static AttributeInfo AttributeBaseStrengthAttribute;
            public static AttributeInfo AttributeStrengthGainAttribute;
            public static AttributeInfo AttributeBaseIntelligenceAttribute;
            public static AttributeInfo AttributeIntelligenceGainAttribute;
            public static AttributeInfo AttributeBaseAgilityAttribute;
            public static AttributeInfo AttributeAgilityGainAttribute;
            public static AttributeInfo BountyXPAttribute;
            public static AttributeInfo BountyGoldMinAttribute;
            public static AttributeInfo BountyGoldMaxAttribute;
            public static AttributeInfo BoundsHullNameAttribute;
            public static AttributeInfo RingRadiusAttribute;
            public static AttributeInfo MovementCapabilitiesAttribute;
            public static AttributeInfo MovementSpeedAttribute;
            public static AttributeInfo MovementTurnRateAttribute;
            public static AttributeInfo HasAggressiveStanceAttribute;
            public static AttributeInfo StatusHealthAttribute;
            public static AttributeInfo StatusHealthRegenAttribute;
            public static AttributeInfo StatusManaAttribute;
            public static AttributeInfo StatusManaRegenAttribute;
            public static AttributeInfo StatusStartingManaAttribute;
            public static AttributeInfo TeamNameAttribute;
            public static AttributeInfo CombatClassAttackAttribute;
            public static AttributeInfo CombatClassDefendAttribute;
            public static AttributeInfo UnitRelationshipClassAttribute;
            public static AttributeInfo VisionDaytimeRangeAttribute;
            public static AttributeInfo VisionNighttimeRangeAttribute;
            public static AttributeInfo HasInventoryAttribute;
            public static AttributeInfo HealthBarOffsetAttribute;
            public static AttributeInfo IdleSoundLoopAttribute;
            public static AttributeInfo IsAncientAttribute;
            public static AttributeInfo IsNeutralUnitTypeAttribute;
            public static AttributeInfo SelectionGroupAttribute;
            public static AttributeInfo SelectOnSpawnAttribute;
            public static AttributeInfo CanBeDominatedAttribute;
            public static AttributeInfo IgnoreAddSummonedToSelectionAttribute;
            public static AttributeInfo AutoAttacksByDefaultAttribute;
            public static AttributeInfo AttackRangeBufferAttribute;
            public static AttributeInfo FollowRangeAttribute;
            public static AttributeInfo AttackDesireAttribute;
            public static AttributeInfo WakesNeutralsAttribute;
        }

        public static class DotaBaseUnitType
        {
            public static DomNodeType Type;
            public static AttributeInfo ClassNameAttribute;
            public static AttributeInfo BaseClassAttribute;
            public static AttributeInfo ModelAttribute;
            public static AttributeInfo SoundSetAttribute;
            public static AttributeInfo LevelAttribute;
            public static AttributeInfo AbilityLayoutAttribute;
            public static AttributeInfo Ability1Attribute;
            public static AttributeInfo Ability2Attribute;
            public static AttributeInfo Ability3Attribute;
            public static AttributeInfo Ability4Attribute;
            public static AttributeInfo Ability5Attribute;
            public static AttributeInfo Ability6Attribute;
            public static AttributeInfo Ability7Attribute;
            public static AttributeInfo Ability8Attribute;
            public static AttributeInfo ArmorPhysicalAttribute;
            public static AttributeInfo MagicalResistanceAttribute;
            public static AttributeInfo AttackCapabilitiesAttribute;
            public static AttributeInfo AttackDamageMinAttribute;
            public static AttributeInfo AttackDamageMaxAttribute;
            public static AttributeInfo AttackDamageTypeAttribute;
            public static AttributeInfo AttackRateAttribute;
            public static AttributeInfo AttackAnimationPointAttribute;
            public static AttributeInfo AttackAcquisitionRangeAttribute;
            public static AttributeInfo AttackRangeAttribute;
            public static AttributeInfo ProjectileModelAttribute;
            public static AttributeInfo ProjectileSpeedAttribute;
            public static AttributeInfo AttributePrimaryAttribute;
            public static AttributeInfo AttributeBaseStrengthAttribute;
            public static AttributeInfo AttributeStrengthGainAttribute;
            public static AttributeInfo AttributeBaseIntelligenceAttribute;
            public static AttributeInfo AttributeIntelligenceGainAttribute;
            public static AttributeInfo AttributeBaseAgilityAttribute;
            public static AttributeInfo AttributeAgilityGainAttribute;
            public static AttributeInfo BountyXPAttribute;
            public static AttributeInfo BountyGoldMinAttribute;
            public static AttributeInfo BountyGoldMaxAttribute;
            public static AttributeInfo BoundsHullNameAttribute;
            public static AttributeInfo RingRadiusAttribute;
            public static AttributeInfo MovementCapabilitiesAttribute;
            public static AttributeInfo MovementSpeedAttribute;
            public static AttributeInfo MovementTurnRateAttribute;
            public static AttributeInfo HasAggressiveStanceAttribute;
            public static AttributeInfo StatusHealthAttribute;
            public static AttributeInfo StatusHealthRegenAttribute;
            public static AttributeInfo StatusManaAttribute;
            public static AttributeInfo StatusManaRegenAttribute;
            public static AttributeInfo StatusStartingManaAttribute;
            public static AttributeInfo TeamNameAttribute;
            public static AttributeInfo CombatClassAttackAttribute;
            public static AttributeInfo CombatClassDefendAttribute;
            public static AttributeInfo UnitRelationshipClassAttribute;
            public static AttributeInfo VisionDaytimeRangeAttribute;
            public static AttributeInfo VisionNighttimeRangeAttribute;
            public static AttributeInfo HasInventoryAttribute;
            public static AttributeInfo HealthBarOffsetAttribute;
            public static AttributeInfo IdleSoundLoopAttribute;
        }

        public static class DotaDataObjectType
        {
            public static DomNodeType Type;
            public static AttributeInfo ClassNameAttribute;
            public static AttributeInfo BaseClassAttribute;
        }

        public static class DefaultUnitContainerType
        {
            public static DomNodeType Type;
            public static ChildInfo ContentsChild;
        }

        public static class DotaHeroType
        {
            public static DomNodeType Type;
            public static AttributeInfo ClassNameAttribute;
            public static AttributeInfo BaseClassAttribute;
            public static AttributeInfo ModelAttribute;
            public static AttributeInfo SoundSetAttribute;
            public static AttributeInfo LevelAttribute;
            public static AttributeInfo AbilityLayoutAttribute;
            public static AttributeInfo Ability1Attribute;
            public static AttributeInfo Ability2Attribute;
            public static AttributeInfo Ability3Attribute;
            public static AttributeInfo Ability4Attribute;
            public static AttributeInfo Ability5Attribute;
            public static AttributeInfo Ability6Attribute;
            public static AttributeInfo Ability7Attribute;
            public static AttributeInfo Ability8Attribute;
            public static AttributeInfo ArmorPhysicalAttribute;
            public static AttributeInfo MagicalResistanceAttribute;
            public static AttributeInfo AttackCapabilitiesAttribute;
            public static AttributeInfo AttackDamageMinAttribute;
            public static AttributeInfo AttackDamageMaxAttribute;
            public static AttributeInfo AttackDamageTypeAttribute;
            public static AttributeInfo AttackRateAttribute;
            public static AttributeInfo AttackAnimationPointAttribute;
            public static AttributeInfo AttackAcquisitionRangeAttribute;
            public static AttributeInfo AttackRangeAttribute;
            public static AttributeInfo ProjectileModelAttribute;
            public static AttributeInfo ProjectileSpeedAttribute;
            public static AttributeInfo AttributePrimaryAttribute;
            public static AttributeInfo AttributeBaseStrengthAttribute;
            public static AttributeInfo AttributeStrengthGainAttribute;
            public static AttributeInfo AttributeBaseIntelligenceAttribute;
            public static AttributeInfo AttributeIntelligenceGainAttribute;
            public static AttributeInfo AttributeBaseAgilityAttribute;
            public static AttributeInfo AttributeAgilityGainAttribute;
            public static AttributeInfo BountyXPAttribute;
            public static AttributeInfo BountyGoldMinAttribute;
            public static AttributeInfo BountyGoldMaxAttribute;
            public static AttributeInfo BoundsHullNameAttribute;
            public static AttributeInfo RingRadiusAttribute;
            public static AttributeInfo MovementCapabilitiesAttribute;
            public static AttributeInfo MovementSpeedAttribute;
            public static AttributeInfo MovementTurnRateAttribute;
            public static AttributeInfo HasAggressiveStanceAttribute;
            public static AttributeInfo StatusHealthAttribute;
            public static AttributeInfo StatusHealthRegenAttribute;
            public static AttributeInfo StatusManaAttribute;
            public static AttributeInfo StatusManaRegenAttribute;
            public static AttributeInfo StatusStartingManaAttribute;
            public static AttributeInfo TeamNameAttribute;
            public static AttributeInfo CombatClassAttackAttribute;
            public static AttributeInfo CombatClassDefendAttribute;
            public static AttributeInfo UnitRelationshipClassAttribute;
            public static AttributeInfo VisionDaytimeRangeAttribute;
            public static AttributeInfo VisionNighttimeRangeAttribute;
            public static AttributeInfo HasInventoryAttribute;
            public static AttributeInfo HealthBarOffsetAttribute;
            public static AttributeInfo IdleSoundLoopAttribute;
            public static AttributeInfo EnabledAttribute;
            public static AttributeInfo BotImplementedAttribute;
            public static AttributeInfo NewHeroAttribute;
            public static AttributeInfo HeroPool1Attribute;
            public static AttributeInfo HeroUnlockOrderAttribute;
            public static AttributeInfo CMEnabledAttribute;
            public static AttributeInfo CMTournamentIgnoreAttribute;
            public static AttributeInfo new_player_enableAttribute;
            public static AttributeInfo VoiceBackgroundSoundAttribute;
            public static AttributeInfo IdleExpressionAttribute;
            public static AttributeInfo HUDAttribute;
            public static AttributeInfo override_heroAttribute;
        }
    }
}
