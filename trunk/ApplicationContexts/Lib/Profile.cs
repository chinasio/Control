using System;
namespace Artech.ApplicationContexts
{
    [Serializable]
    public class Profile
    {
        public string FirstName
        { get; set; }
        public string LastName
        { get; set; }
        public int Age
        { get; set; }
        public Profile()
        {
            this.FirstName = "N/A";
            this.LastName = "N/A";
            this.Age = 0;
        }
    }
}
