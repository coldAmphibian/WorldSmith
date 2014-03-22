using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldsmithATF.ObjectTypes
{
    class DotaUnit : DotaBaseUnit
    {
        public bool IsAncient
        {
            get { return GetAttribute<bool>(DotaObjectsSchema.DotaUnitType.IsAncientAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaUnitType.IsAncientAttribute, value); }
        }

        public bool IsNeutralUnitType
        {
            get { return GetAttribute<bool>(DotaObjectsSchema.DotaUnitType.IsNeutralUnitTypeAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaUnitType.IsNeutralUnitTypeAttribute, value); }
        }

        public string SelectionGroup
        {
            get { return GetAttribute<string>(DotaObjectsSchema.DotaUnitType.SelectionGroupAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaUnitType.SelectionGroupAttribute, value); }
        }

        public bool SelectOnSpawn
        {
            get { return GetAttribute<bool>(DotaObjectsSchema.DotaUnitType.SelectOnSpawnAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaUnitType.SelectOnSpawnAttribute, value); }
        }

        public bool CanBeDominated
        {
            get { return GetAttribute<bool>(DotaObjectsSchema.DotaUnitType.CanBeDominatedAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaUnitType.CanBeDominatedAttribute, value); }
        }

        public bool IgnoreAddSummonedToSelection
        {
            get { return GetAttribute<bool>(DotaObjectsSchema.DotaUnitType.IgnoreAddSummonedToSelectionAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaUnitType.IgnoreAddSummonedToSelectionAttribute, value); }
        }

        public bool AutoAttacksByDefault
        {
            get { return GetAttribute<bool>(DotaObjectsSchema.DotaUnitType.AutoAttacksByDefaultAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaUnitType.AutoAttacksByDefaultAttribute, value); }
        }

        public int AttackRangeBuffer
        {
            get { return GetAttribute<int>(DotaObjectsSchema.DotaUnitType.AttackRangeBufferAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaUnitType.AttackRangeBufferAttribute, value); }
        }

        public int FollowRange
        {
            get { return GetAttribute<int>(DotaObjectsSchema.DotaUnitType.FollowRangeAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaUnitType.FollowRangeAttribute, value); }
        }

        public float AttackDesire
        {
            get { return GetAttribute<float>(DotaObjectsSchema.DotaUnitType.AttackDesireAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaUnitType.AttackDesireAttribute, value); }
        }

        public bool WakesNeutrals
        {
            get { return GetAttribute<bool>(DotaObjectsSchema.DotaUnitType.WakesNeutralsAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaUnitType.WakesNeutralsAttribute, value); }
        }
    }
}
