using DoddingtonCarnival.Blazor.Models;

namespace DoddingtonCarnival.Blazor.Services
{
    public class LocationsService
    {
        public string? GetLocationName(string tag)
        {
            Location? location = Get(tag);

            if (location == null)
            {
                return null;
            }

            return location.Name;
        }

        public string? GetLocationString(string tag)
        {
            Location? location = Get(tag);

            if (location == null)
            {
                return null;
            }

            return location.ToString();
        }

        private Location? Get(string tag)
        {
            if (string.IsNullOrEmpty(tag))
            {
                return null;
            }

            return DummyGetAll().FirstOrDefault(x => x.Id == tag);
        }

        private static List<Location> DummyGetAll()
        {
            return new List<Location>
            {
                new Location {
                    Id = "Doddington",
                    Name = "Doddington Village",
                    Address2 = "Doddington",
                    Address3 = "March",
                    Address4 = "Cambridgeshire"
                },
                 new Location {
                    Id = "ChurchRooms",
                    Name = "The Church Rooms",
                    Address1 = "New Street",
                    Address2 = "Doddington",
                    Address3 = "March",
                    Address4 = "Cambridgeshire",
                    PostCode = "PE15 0SP"
                 },
                  new Location {
                    Id = "Pavilion",
                    Name = "Doddington Pavilion & Sports Field",
                    Address1 = "Benwick Road",
                    Address2 = "Doddington",
                    Address3 = "March",
                    Address4 = "Cambridgeshire",
                    PostCode = "PE15 0TG"
                },
                new Location {
                    Id = "VillageHall",
                    Name = "Doddington Village Hall",
                    Address1 = "Benwick Road",
                    Address2 = "Doddington",
                    Address3 = "March",
                    Address4 = "Cambridgeshire",
                    PostCode = "PE15 0TG"
                },
                new Location {
                    Id = "Tuns",
                    Name = "The Three Tuns",
                    Address1 = "32 High Street",
                    Address2 = "Doddington",
                    Address3 = "March",
                    Address4 = "Cambridgeshire",
                    PostCode = "PE15 0SP"
                }
            };
        }
    }
}