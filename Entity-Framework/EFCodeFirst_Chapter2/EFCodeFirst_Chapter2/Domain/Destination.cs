using System.Collections.Generic;

namespace EFCodeFirst_Chapter2.Domain
{
    public class Destination
    {
        public int DestinationId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }

        public List<Lodging> Lodgings { get; set; }

        #region Equality Operations

        public bool Equals(Destination other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.DestinationId == DestinationId && Equals(other.Name, Name) && Equals(other.Country, Country) && Equals(other.Description, Description) && Equals(other.Photo, Photo) && Equals(other.Lodgings, Lodgings);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Destination)) return false;
            return Equals((Destination) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = DestinationId;
                result = (result*397) ^ (Name != null ? Name.GetHashCode() : 0);
                result = (result*397) ^ (Country != null ? Country.GetHashCode() : 0);
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                result = (result*397) ^ (Photo != null ? Photo.GetHashCode() : 0);
                result = (result*397) ^ (Lodgings != null ? Lodgings.GetHashCode() : 0);
                return result;
            }
        }

        #endregion
    }
}