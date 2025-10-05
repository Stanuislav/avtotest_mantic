using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_test
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager) { }

        public void Creation()
        {
            manager.ProjectMenu.OpenPageProject();
            //OpnePageCreateProject();
            //FillProjectForm();
            //SumbitProjcetCreation();


        }

    }
}
