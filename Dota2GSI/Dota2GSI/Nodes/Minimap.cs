﻿using Dota2GSI.Nodes.MinimapProvider;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Dota2GSI.Nodes
{
    /// <summary>
    /// Class representing the minimap.
    /// </summary>
    public class Minimap : Node
    {
        /// <summary>
        /// The minimap elements.<br/>
        /// Key is element ID.<br/>
        /// Value is minimap element.
        /// </summary>
        public readonly Dictionary<int, MinimapElement> Elements = new Dictionary<int, MinimapElement>();

        private Regex _object_regex = new Regex(@"o(\d+)");
        internal Minimap(JObject parsed_data = null) : base(parsed_data)
        {
            GetMatchingObjects(parsed_data, _object_regex, (Match match, JObject obj) =>
            {
                var object_index = Convert.ToInt32(match.Groups[1].Value);

                Elements.Add(object_index, new MinimapElement(obj));
            });
        }

        /// <summary>
        /// Gets minimap elements for a specific team.<br/>
        /// Key is element ID.<br/>
        /// Value is minimap element.
        /// </summary>
        /// <param name="team">The team.</param>
        /// <returns>The minimap elements.</returns>
        public Dictionary<int, MinimapElement> GetForTeam(PlayerTeam team)
        {
            Dictionary<int, MinimapElement> found_elements = new Dictionary<int, MinimapElement>();

            foreach (var element_kvp in Elements)
            {
                if (element_kvp.Value.Team == team)
                {
                    found_elements.Add(element_kvp.Key, element_kvp.Value);
                }
            }

            return found_elements;
        }

        /// <summary>
        /// Gets minimap elements for a specific unit name.<br/>
        /// Key is element ID.<br/>
        /// Value is minimap element.
        /// </summary>
        /// <param name="unit_name">The unit name.</param>
        /// <returns>The minimap elements.</returns>
        public Dictionary<int, MinimapElement> GetByUnitName(string unit_name)
        {
            Dictionary<int, MinimapElement> found_elements = new Dictionary<int, MinimapElement>();

            if (!string.IsNullOrEmpty(unit_name))
            {
                foreach (var element_kvp in Elements)
                {
                    if (element_kvp.Value.UnitName.Equals(unit_name))
                    {
                        found_elements.Add(element_kvp.Key, element_kvp.Value);
                    }
                }
            }

            return found_elements;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"[" +
                $"Elements: {Elements}" +
                $"]";
        }
    }
}
