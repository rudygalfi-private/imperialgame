// <copyright file="TaxableRegion.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// Defines a TaxableRegion, which is a type of Region.
    /// </summary>
    public abstract class TaxableRegion : Region
    {
        /// <summary>
        /// The controller of the region.
        /// </summary>
        private TaxChip taxChip = null;

        /// <summary>
        /// Initializes a new instance of the TaxableRegion class according to the specified definition.
        /// </summary>
        /// <param name="definition">The XML definition of this TaxableRegion.</param>
        protected TaxableRegion(System.Xml.XmlNode definition) : base(definition)
        {
        }

        public void UpdateTaxChip()
        {
            // Generate a list of all Nations with Units in the Region.
            System.Collections.Generic.HashSet<Nation> nationsInRegion = new System.Collections.Generic.HashSet<Nation>();
            foreach (System.Collections.Generic.KeyValuePair<Nation, Military> military in this.Militaries)
            {
                if (!military.Value.IsEmpty())
                {
                    nationsInRegion.Add(military.Key);
                }
            }

            // Check if there's only one Nation in the Region.
            if (1 == nationsInRegion.Count)
            {
                // Get that Nation.
                foreach (Nation controllingNation in nationsInRegion)
                {
                    // Check if control is changing hands.
                    if (this.taxChip.Owner != controllingNation)
                    {
                        // Send the current TaxChip back to its owner.
                        this.taxChip.Owner.CollectTaxChip(this.taxChip);

                        // Place the TaxChip of the new owner.
                        // We might not have any left, so we'll get null. In this case,
                        // don't place anything.
                        TaxChip newOwner = controllingNation.DispenseTaxChip();
                        if (null != newOwner)
                        {
                            this.taxChip = newOwner;
                        }
                    }
                }
            }
        }
    }
}
