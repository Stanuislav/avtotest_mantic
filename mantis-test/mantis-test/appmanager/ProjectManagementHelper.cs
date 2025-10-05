using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_test
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager) { }

        public void Creation(ProjectData project)
        {
            manager.ProjectMenu.OpenPageProject();
            OpnePageCreateProject();
            FillProjectForm(project);
            SumbitProjcetCreation();


        }

        public void Remove(int index)
        {
            manager.ProjectMenu.OpenPageProject();
            OpenProject(index);
            RemoveProject();
            SumbitDeleteProject();

        }



        private void SumbitDeleteProject()
        {
            driver.FindElement(By.CssSelector(".btn.btn-primary.btn-white.btn-round")).Click();
        }

        private void RemoveProject()
        {
            driver.FindElement(By.XPath("//button[@formaction='manage_proj_delete.php']")).Click();
        }

        private void OpenProject(int index)
        {
            driver.FindElement(By.XPath("//table[@class='table table-striped table-bordered table-condensed table-hover']/tbody/tr[" + (index+1) + "]/td/a")).Click();
        }

        private void SumbitProjcetCreation()
        {
            driver.FindElement(By.CssSelector(".btn.btn-primary.btn-white.btn-round")).Click();
        }

        private void FillProjectForm(ProjectData project)
        {
            Type(By.Name("name"), project.NameProfect);
            Type(By.Name("description"), project.ProjectDescription);

        }

        private void OpnePageCreateProject()
        {
            driver.FindElement(By.CssSelector(".btn.btn-primary.btn-white.btn-round")).Click();
        }

        public int GetProjectGount()
        {
            manager.ProjectMenu.OpenPageProject();
            return driver.FindElements(By.XPath("//table[@class='table table-striped table-bordered table-condensed table-hover']/tbody/tr")).Count();
        }


    }
}
