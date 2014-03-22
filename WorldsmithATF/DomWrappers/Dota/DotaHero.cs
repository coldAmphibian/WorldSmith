using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldsmithATF.ObjectTypes
{
    class DotaHero : DotaBaseUnit
    {
        public bool Enabled
        {
            get { return GetAttribute<bool>(DotaObjectsSchema.DotaHeroType.EnabledAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaHeroType.EnabledAttribute, value); }
        }

        public bool BotImplemented
        {
            get { return GetAttribute<bool>(DotaObjectsSchema.DotaHeroType.BotImplementedAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaHeroType.BotImplementedAttribute, value); }
        }

        public bool NewHero
        {
            get { return GetAttribute<bool>(DotaObjectsSchema.DotaHeroType.NewHeroAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaHeroType.NewHeroAttribute, value); }
        }

        public bool HeroPool1
        {
            get { return GetAttribute<bool>(DotaObjectsSchema.DotaHeroType.HeroPool1Attribute); }
            set { SetAttribute(DotaObjectsSchema.DotaHeroType.HeroPool1Attribute, value); }
        }

        public int HeroUnlockOrder
        {
            get { return GetAttribute<int>(DotaObjectsSchema.DotaHeroType.HeroUnlockOrderAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaHeroType.HeroUnlockOrderAttribute, value); }
        }

        public bool CMEnabled
        {
            get { return GetAttribute<bool>(DotaObjectsSchema.DotaHeroType.CMEnabledAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaHeroType.CMEnabledAttribute, value); }
        }

        public bool CMTournamentIgnore
        {
            get { return GetAttribute<bool>(DotaObjectsSchema.DotaHeroType.CMTournamentIgnoreAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaHeroType.CMTournamentIgnoreAttribute, value); }
        }

        public bool new_player_enable
        {
            get { return GetAttribute<bool>(DotaObjectsSchema.DotaHeroType.new_player_enableAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaHeroType.new_player_enableAttribute, value); }
        }

        public string VoiceBackgroundSound
        {
            get { return GetAttribute<string>(DotaObjectsSchema.DotaHeroType.VoiceBackgroundSoundAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaHeroType.VoiceBackgroundSoundAttribute, value); }
        }

        public string IdleExpression
        {
            get { return GetAttribute<string>(DotaObjectsSchema.DotaHeroType.IdleExpressionAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaHeroType.IdleExpressionAttribute, value); }
        }

        public string HUD
        {
            get { return GetAttribute<string>(DotaObjectsSchema.DotaHeroType.HUDAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaHeroType.HUDAttribute, value); }
        }

        public string override_hero
        {
            get { return GetAttribute<string>(DotaObjectsSchema.DotaHeroType.override_heroAttribute); }
            set { SetAttribute(DotaObjectsSchema.DotaHeroType.override_heroAttribute, value); }
        }

    }
}
