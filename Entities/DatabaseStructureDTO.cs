using System;

namespace MechTech.Entities
{
    [Serializable]
    public class DatabaseStructureDTO
    {
        public DatabaseStructureDTO()
        { }

        private string name = string.Empty;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}