namespace EierfarmBl
{
    public class GefluegelEventArgs : EventArgs
    {
        public GefluegelEventArgs(string propertyName)
        {
            this.GeaenderteProperty = propertyName;
        }
        public string GeaenderteProperty { get; set; }
    }
}