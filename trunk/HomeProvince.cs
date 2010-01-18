// <copyright file="HomeProvince.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// Defines a Home Province, which is a type of Region.
    /// </summary>
    public abstract class HomeProvince : Region
    {
        /// <summary>
        /// The XML attribute that describes whether this HomeProvince starts with a Factory.
        /// </summary>
        private const string XmlStartFactoryLoadAttribute = "start";

        /// <summary>
        /// The Factory of this HomeProvince.
        /// </summary>
        private bool hasFactory = false;

        /// <summary>
        /// Initializes a new instance of the HomeProvince class according to the specified definition.
        /// </summary>
        /// <param name="definition">The XML definition of this HomeProvince.</param>
        public HomeProvince(System.Xml.XmlNode definition) : base(definition)
        {
            if (((System.Xml.XmlElement)definition).HasAttribute(HomeProvince.XmlStartFactoryLoadAttribute))
            {
                if ("true" == ((System.Xml.XmlElement)definition).GetAttribute(HomeProvince.XmlStartFactoryLoadAttribute).ToLower())
                {
                    this.BuildFactory();
                }
                else if ("false" == ((System.Xml.XmlElement)definition).GetAttribute(HomeProvince.XmlStartFactoryLoadAttribute).ToLower())
                {
                }
                else
                {
                    //// throw InvalidStartFactoryException
                }
            }
            else
            {
                //// throw UnspecifiedStartFactoryException
            }
        }

        public override string ToString()
        {
            string result = base.ToString() + " [Home Province] ";

            result += "Has Factory?: " + this.hasFactory;

            return result;
        }

        /// <summary>
        /// Builds the appropriate type of Factory in this HomeProvince.
        /// </summary>
        public void BuildFactory()
        {
            this.hasFactory = true;
        }

        /// <summary>
        /// Produces a Unit of the appropriate type for the given Nation.
        /// </summary>
        /// <param name="allegiance">The allegiance of the produced Unit.</param>
        public abstract void ProduceUnit(Nation allegiance);

        /// <summary>
        /// Destroys the Factory of this HomeProvince.
        /// </summary>
        private void DestroyFactory()
        {
            this.hasFactory = false;
        }
    }
}
