using System.Collections.Generic;

namespace CV19WpfApp.Model.Decanat
{
    internal class Group
    {
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }

    }

}
