using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportCardGenerator.Interfaces
{
    public interface IController
    {
        void registerView(IView i);
        void unregisterView(IView i);
        void setUpdateViews(bool condition);
        void updateRegisteredViews();
    }
}
