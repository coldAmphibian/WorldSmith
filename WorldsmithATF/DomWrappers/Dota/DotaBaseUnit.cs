using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldsmithATF.ObjectTypes
{
    class DotaBaseUnit : DotaDataObject
    {
        public string Model
        {
            get { return GetAttribute<string>(DotaObjectsSchema.DotaBaseUnitType.ModelAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.ModelAttribute, value); }
        }

        public string SoundSet
        {
            get { return GetAttribute<string>(DotaObjectsSchema.DotaBaseUnitType.SoundSetAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.SoundSetAttribute, value); }
        }

        public int Level
        {
            get { return GetAttribute<int>(DotaObjectsSchema.DotaBaseUnitType.LevelAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.LevelAttribute, value); }
        }

        public int AbilityLayout
        {
            get { return GetAttribute<int>(DotaObjectsSchema.DotaBaseUnitType.AbilityLayoutAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.AbilityLayoutAttribute, value); }
        }

        public string Ability1
        {
            get { return GetAttribute<string>(DotaObjectsSchema.DotaBaseUnitType.Ability1Attribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.Ability1Attribute, value); }
        }

        public string Ability2
        {
            get { return GetAttribute<string>(DotaObjectsSchema.DotaBaseUnitType.Ability2Attribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.Ability2Attribute, value); }
        }

        public string Ability3
        {
            get { return GetAttribute<string>(DotaObjectsSchema.DotaBaseUnitType.Ability3Attribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.Ability3Attribute, value); }
        }

        public string Ability4
        {
            get { return GetAttribute<string>(DotaObjectsSchema.DotaBaseUnitType.Ability4Attribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.Ability4Attribute, value); }
        }

        public string Ability5
        {
            get { return GetAttribute<string>(DotaObjectsSchema.DotaBaseUnitType.Ability5Attribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.Ability5Attribute, value); }
        }

        public string Ability6
        {
            get { return GetAttribute<string>(DotaObjectsSchema.DotaBaseUnitType.Ability6Attribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.Ability6Attribute, value); }
        }

        public string Ability7
        {
            get { return GetAttribute<string>(DotaObjectsSchema.DotaBaseUnitType.Ability7Attribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.Ability7Attribute, value); }
        }

        public string Ability8
        {
            get { return GetAttribute<string>(DotaObjectsSchema.DotaBaseUnitType.Ability8Attribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.Ability8Attribute, value); }
        }

        public int ArmorPhysical
        {
            get { return GetAttribute<int>(DotaObjectsSchema.DotaBaseUnitType.ArmorPhysicalAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.ArmorPhysicalAttribute, value); }
        }

        public int MagicalResistance
        {
            get { return GetAttribute<int>(DotaObjectsSchema.DotaBaseUnitType.MagicalResistanceAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.MagicalResistanceAttribute, value); }
        }

        public string AttackCapabilities
        {
            get { return GetAttribute<string>(DotaObjectsSchema.DotaBaseUnitType.AttackCapabilitiesAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.AttackCapabilitiesAttribute, value); }
        }

        public int AttackDamageMin
        {
            get { return GetAttribute<int>(DotaObjectsSchema.DotaBaseUnitType.AttackDamageMinAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.AttackDamageMinAttribute, value); }
        }

        public int AttackDamageMax
        {
            get { return GetAttribute<int>(DotaObjectsSchema.DotaBaseUnitType.AttackDamageMaxAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.AttackDamageMaxAttribute, value); }
        }

        public string AttackDamageType
        {
            get { return GetAttribute<string>(DotaObjectsSchema.DotaBaseUnitType.AttackDamageTypeAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.AttackDamageTypeAttribute, value); }
        }

        public float AttackRate
        {
            get { return GetAttribute<float>(DotaObjectsSchema.DotaBaseUnitType.AttackRateAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.AttackRateAttribute, value); }
        }

        public float AttackAnimationPoint
        {
            get { return GetAttribute<float>(DotaObjectsSchema.DotaBaseUnitType.AttackAnimationPointAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.AttackAnimationPointAttribute, value); }
        }

        public bool AttackAcquisitionRange
        {
            get { return GetAttribute<bool>(DotaObjectsSchema.DotaBaseUnitType.AttackAcquisitionRangeAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.AttackAcquisitionRangeAttribute, value); }
        }

        public int AttackRange
        {
            get { return GetAttribute<int>(DotaObjectsSchema.DotaBaseUnitType.AttackRangeAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.AttackRangeAttribute, value); }
        }

        public string ProjectileModel
        {
            get { return GetAttribute<string>(DotaObjectsSchema.DotaBaseUnitType.ProjectileModelAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.ProjectileModelAttribute, value); }
        }

        public int ProjectileSpeed
        {
            get { return GetAttribute<int>(DotaObjectsSchema.DotaBaseUnitType.ProjectileSpeedAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.ProjectileSpeedAttribute, value); }
        }

        public string AttributePrimary
        {
            get { return GetAttribute<string>(DotaObjectsSchema.DotaBaseUnitType.AttributePrimaryAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.AttributePrimaryAttribute, value); }
        }

        public int AttributeBaseStrength
        {
            get { return GetAttribute<int>(DotaObjectsSchema.DotaBaseUnitType.AttributeBaseStrengthAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.AttributeBaseStrengthAttribute, value); }
        }

        public int AttributeStrengthGain
        {
            get { return GetAttribute<int>(DotaObjectsSchema.DotaBaseUnitType.AttributeStrengthGainAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.AttributeStrengthGainAttribute, value); }
        }

        public int AttributeBaseIntelligence
        {
            get { return GetAttribute<int>(DotaObjectsSchema.DotaBaseUnitType.AttributeBaseIntelligenceAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.AttributeBaseIntelligenceAttribute, value); }
        }

        public int AttributeIntelligenceGain
        {
            get { return GetAttribute<int>(DotaObjectsSchema.DotaBaseUnitType.AttributeIntelligenceGainAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.AttributeIntelligenceGainAttribute, value); }
        }

        public int AttributeBaseAgility
        {
            get { return GetAttribute<int>(DotaObjectsSchema.DotaBaseUnitType.AttributeBaseAgilityAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.AttributeBaseAgilityAttribute, value); }
        }

        public int AttributeAgilityGain
        {
            get { return GetAttribute<int>(DotaObjectsSchema.DotaBaseUnitType.AttributeAgilityGainAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.AttributeAgilityGainAttribute, value); }
        }

        public int BountyXP
        {
            get { return GetAttribute<int>(DotaObjectsSchema.DotaBaseUnitType.BountyXPAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.BountyXPAttribute, value); }
        }

        public int BountyGoldMin
        {
            get { return GetAttribute<int>(DotaObjectsSchema.DotaBaseUnitType.BountyGoldMinAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.BountyGoldMinAttribute, value); }
        }

        public int BountyGoldMax
        {
            get { return GetAttribute<int>(DotaObjectsSchema.DotaBaseUnitType.BountyGoldMaxAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.BountyGoldMaxAttribute, value); }
        }

        public string BoundsHullName
        {
            get { return GetAttribute<string>(DotaObjectsSchema.DotaBaseUnitType.BoundsHullNameAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.BoundsHullNameAttribute, value); }
        }

        public int RingRadius
        {
            get { return GetAttribute<int>(DotaObjectsSchema.DotaBaseUnitType.RingRadiusAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.RingRadiusAttribute, value); }
        }

        public string MovementCapabilities
        {
            get { return GetAttribute<string>(DotaObjectsSchema.DotaBaseUnitType.MovementCapabilitiesAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.MovementCapabilitiesAttribute, value); }
        }

        public int MovementSpeed
        {
            get { return GetAttribute<int>(DotaObjectsSchema.DotaBaseUnitType.MovementSpeedAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.MovementSpeedAttribute, value); }
        }

        public float MovementTurnRate
        {
            get { return GetAttribute<float>(DotaObjectsSchema.DotaBaseUnitType.MovementTurnRateAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.MovementTurnRateAttribute, value); }
        }

        public bool HasAggressiveStance
        {
            get { return GetAttribute<bool>(DotaObjectsSchema.DotaBaseUnitType.HasAggressiveStanceAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.HasAggressiveStanceAttribute, value); }
        }

        public int StatusHealth
        {
            get { return GetAttribute<int>(DotaObjectsSchema.DotaBaseUnitType.StatusHealthAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.StatusHealthAttribute, value); }
        }

        public float StatusHealthRegen
        {
            get { return GetAttribute<float>(DotaObjectsSchema.DotaBaseUnitType.StatusHealthRegenAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.StatusHealthRegenAttribute, value); }
        }

        public int StatusMana
        {
            get { return GetAttribute<int>(DotaObjectsSchema.DotaBaseUnitType.StatusManaAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.StatusManaAttribute, value); }
        }

        public float StatusManaRegen
        {
            get { return GetAttribute<float>(DotaObjectsSchema.DotaBaseUnitType.StatusManaRegenAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.StatusManaRegenAttribute, value); }
        }

        public int StatusStartingMana
        {
            get { return GetAttribute<int>(DotaObjectsSchema.DotaBaseUnitType.StatusStartingManaAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.StatusStartingManaAttribute, value); }
        }

        public string TeamName
        {
            get { return GetAttribute<string>(DotaObjectsSchema.DotaBaseUnitType.TeamNameAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.TeamNameAttribute, value); }
        }

        public string CombatClassAttack
        {
            get { return GetAttribute<string>(DotaObjectsSchema.DotaBaseUnitType.CombatClassAttackAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.CombatClassAttackAttribute, value); }
        }

        public string CombatClassDefend
        {
            get { return GetAttribute<string>(DotaObjectsSchema.DotaBaseUnitType.CombatClassDefendAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.CombatClassDefendAttribute, value); }
        }

        public string UnitRelationshipClass
        {
            get { return GetAttribute<string>(DotaObjectsSchema.DotaBaseUnitType.UnitRelationshipClassAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.UnitRelationshipClassAttribute, value); }
        }

        public int VisionDaytimeRange
        {
            get { return GetAttribute<int>(DotaObjectsSchema.DotaBaseUnitType.VisionDaytimeRangeAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.VisionDaytimeRangeAttribute, value); }
        }

        public int VisionNighttimeRange
        {
            get { return GetAttribute<int>(DotaObjectsSchema.DotaBaseUnitType.VisionNighttimeRangeAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.VisionNighttimeRangeAttribute, value); }
        }

        public bool HasInventory
        {
            get { return GetAttribute<bool>(DotaObjectsSchema.DotaBaseUnitType.HasInventoryAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.HasInventoryAttribute, value); }
        }

        public int HealthBarOffset
        {
            get { return GetAttribute<int>(DotaObjectsSchema.DotaBaseUnitType.HealthBarOffsetAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.HealthBarOffsetAttribute, value); }
        }

        public string IdleSoundLoop
        {
            get { return GetAttribute<string>(DotaObjectsSchema.DotaBaseUnitType.IdleSoundLoopAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaBaseUnitType.IdleSoundLoopAttribute, value); }
        }

    }
}
