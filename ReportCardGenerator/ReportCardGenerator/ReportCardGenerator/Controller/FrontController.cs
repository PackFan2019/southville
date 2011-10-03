using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReportCardGenerator.Interfaces;
namespace ReportCardGenerator.Controller
{
    public class FrontController:IController
    {
        /*Class variables*/
        private List<IView> views = new List<IView>();
        private StudentController studentController = new StudentController();
        private bool updateViews = true;
        /*Singleton pattern*/
        private static FrontController instance = new FrontController();
        public static FrontController getInstance()
        {
            return instance;
        }
        /*MVC pattern*/
        public void registerView(IView i)
        {
            views.Add(i);
        }

        public void unregisterView(IView i)
        {
            views.Remove(i);
        }

        public void setUpdateViews(bool condition)
        {
            updateViews = condition;
        }
        public void updateRegisteredViews()
        {
            if (updateViews)
            {
                foreach (IView i in views)
                {
                    i.updateGUI();
                }
            }
        }

        /*FrontController pattern*/

        public void registerView(IView i, IController c)
        {
            //To be done later
        }

        public void unregisterView(IView i, IController c)
        {
            //To be done later
        }

        public IStudentController getStudentController()
        {
            return studentController;
        }
    }
}
