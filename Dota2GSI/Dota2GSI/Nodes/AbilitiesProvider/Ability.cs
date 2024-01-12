using Newtonsoft.Json.Linq;

namespace Dota2GSI.Nodes.AbilitiesProvider
{
    /// <summary>
    /// Class representing ability information.
    /// </summary>
    public class Ability : Node
    {
        /// <summary>
        /// Ability name.
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// Ability level.
        /// </summary>
        public readonly int Level;

        /// <summary>
        /// A boolean representing whether the ability can be casted.
        /// </summary>
        public readonly bool CanCast;

        /// <summary>
        /// A boolean representing whether the ability is passive.
        /// </summary>
        public readonly bool IsPassive;

        /// <summary>
        /// A boolean representing whether the ability is active.
        /// </summary>
        public readonly bool IsActive;

        /// <summary>
        /// Ability cooldown in seconds.
        /// </summary>
        public readonly int Cooldown;

        /// <summary>
        /// A boolean representing whether the ability is an ultimate.
        /// </summary>
        public readonly bool IsUltimate;

        /// <summary>
        /// Ability charges.
        /// </summary>
        public readonly int Charges;

        /// <summary>
        /// Ability max charges.
        /// </summary>
        public readonly int MaxCharges;

        /// <summary>
        /// Ability charge cooldown.
        /// </summary>
        public readonly int ChargeCooldown;

        internal Ability(JObject parsed_data = null) : base(parsed_data)
        {
            Name = GetString("name");
            Level = GetInt("level");
            CanCast = GetBool("can_cast");
            IsPassive = GetBool("passive");
            IsActive = GetBool("ability_active");
            Cooldown = GetInt("cooldown");
            IsUltimate = GetBool("ultimate");
            Charges = GetInt("charges");
            MaxCharges = GetInt("max_charges");
            ChargeCooldown = GetInt("charge_cooldown");
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"[" +
                $"Name: {Name}, " +
                $"Level: {Level}, " +
                $"CanCast: {CanCast}, " +
                $"IsPassive: {IsPassive}, " +
                $"IsActive: {IsActive}, " +
                $"Cooldown: {Cooldown}, " +
                $"IsUltimate: {IsUltimate}, " +
                $"Charges: {Charges}, " +
                $"MaxCharges: {MaxCharges}, " +
                $"ChargeCooldown: {ChargeCooldown}" +
                $"]";
        }
    }
}