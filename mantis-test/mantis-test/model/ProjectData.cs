using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_test
{
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {

        public ProjectData (string nameProfect, string projectDescription)
        {
            this.NameProfect = nameProfect;
            this.ProjectDescription = projectDescription;
        }
        public ProjectData()
        {

        }

        public ProjectData(string nameProfect)
        {
            this.NameProfect = nameProfect;
        }


        public bool Equals(ProjectData other)
        {
            if (Object.ReferenceEquals(this, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return NameProfect == other.NameProfect && ProjectDescription == other.ProjectDescription;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(NameProfect, ProjectDescription); ;
        }

        public override string ToString()
        {
            return $"NameProfect={NameProfect} ProjectDescription={ProjectDescription}";
        }

        public int CompareTo(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            int NameProfectCompare = NameProfect.CompareTo(other.NameProfect);
            if (NameProfectCompare != 0)
            {
                return NameProfectCompare;
            }
            return NameProfect.CompareTo(other.NameProfect);
        }

       

        public string NameProfect { get; set; } 
        public string ProjectDescription { get; set; }

        public string Id { get; set; }
    }
}
