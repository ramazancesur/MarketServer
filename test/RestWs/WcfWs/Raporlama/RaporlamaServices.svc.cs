using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace test.RestWs.WcfWs.Raporlama
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RaporlamaServices" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RaporlamaServices.svc or RaporlamaServices.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class RaporlamaServices : IRaporlamaServices
    {
        public void DoWork()
        {
        }
    }
}
