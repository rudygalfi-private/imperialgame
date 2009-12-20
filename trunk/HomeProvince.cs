// <copyright file="HomeProvince.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// Defines a Home Province, which is a type of Region.
    /// </summary>
    public class HomeProvince : Region
    {
        /// <summary>
        /// The type of Factory that this HomeProvince can build.
        /// </summary>
        private readonly FactoryType factoryType;

        /// <summary>
        /// The Factory of this HomeProvince.
        /// </summary>
        private Factory factory = null;

        /// <summary>
        /// Initializes a new instance of the HomeProvince class that can have a Factory of the specified type.
        /// </summary>
        /// <param name="typeOfFactory">The type of Factory that this province can have.</param>
        public HomeProvince(FactoryType typeOfFactory)
        {
            this.factoryType = typeOfFactory;
        }

        /// <summary>
        /// Builds the appropriate type of Factory in this HomeProvince.
        /// </summary>
        public void BuildFactory()
        {
            switch (this.factoryType)
            {
                case FactoryType.Shipyard:
                    this.factory = new Shipyard();
                    break;

                case FactoryType.ArmamentFacility:
                    this.factory = new ArmamentFacility();
                    break;

                default:
                    //// InvalidFactoryTypeExpception
                    break;
            }
        }

        /// <summary>
        /// Destroys the Factory of this HomeProvince.
        /// </summary>
        public void DestroyFactory()
        {
            this.factory = null;
        }

        /// <summary>
        /// Produces a Unit of the appropriate type.
        /// </summary>
        public void ProduceUnit()
        {
            Unit producedUnit = this.factory.Produce();
            this.DomesticMilitary.Add(producedUnit);
        }
    }
}
