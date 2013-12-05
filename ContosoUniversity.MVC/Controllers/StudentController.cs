using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;

using ContosoUniversity.WCF;
using ContosoUniversity.BE;

namespace ContosoUniversity.MVC.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/

        public ActionResult Index()
        {
            //URL: http://es.softuses.com/147952

            string url = "http://localhost:59114/ServiceForMVC.svc?wsdl";
            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress endpoint = new EndpointAddress(url);
            ChannelFactory<IServiceForMVC> chanFac = new ChannelFactory<IServiceForMVC>(binding, endpoint);
            IServiceForMVC clientProxy = chanFac.CreateChannel();
            List<Estudiante> lst = new List<Estudiante>();
            lst = clientProxy.listarEstudiantes();
            return View(lst);
        }
    }
}
