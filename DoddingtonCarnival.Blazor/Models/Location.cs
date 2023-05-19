using System.Text;

namespace DoddingtonCarnival.Blazor.Models
{
    public class Location
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public string? Address4 { get; set; }
        public string? PostCode { get; set; }

        public override string ToString()
        {
            StringBuilder stringbuilder = new StringBuilder();

            this.Add(stringbuilder, this.Name);
            this.Add(stringbuilder, this.Address1);
            this.Add(stringbuilder, this.Address2);
            this.Add(stringbuilder, this.Address3);
            this.Add(stringbuilder, this.Address4);
            this.Add(stringbuilder, this.PostCode);

            return stringbuilder.ToString();
        }

        private void Add(StringBuilder stringbuilder, string? newValue)
        {
            if (string.IsNullOrEmpty(newValue))
            {
                return;
            }

            if (stringbuilder.Length > 0)
            {
                stringbuilder.Append(", ");
            }

            stringbuilder.Append(newValue);
        }
    }
}
