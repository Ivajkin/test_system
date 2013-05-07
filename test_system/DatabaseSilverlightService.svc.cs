using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using test_system.Models;
using System.Collections.Generic;

namespace test_system
{
    [ServiceContract(Namespace = "")]
    [SilverlightFaultBehavior]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class DatabaseSilverlightService
    {
        [OperationContract]
        public IEnumerable<Vopr> GetVoprForGlav(Guid glavID)
        {
            DataManager DB = new DataManager();
            return DB.GetVoprForGlav(glavID);
        }

        [OperationContract]
        public TestData GetTestData()
        {
            return testData;
        }

        [OperationContract]
        public IEnumerable<Otv> GetOtvet(Guid id)
        {
            DataManager DB = new DataManager();
            return DB.GetOtvet(id);
        }

        [OperationContract]
        public DNSInfo GetDNSInfo()
        {
            return dnsInfo;
        }

        [OperationContract]
        public void AddStatistic(string Date, string Time, string Computer, string IP_address, int Balls, int Tasks, int Answers, string Glava)
        {
            DataManager DB = new DataManager();
            DB.AddStatistic(Date, Time, Computer, IP_address, Balls, Tasks, Answers, Glava);
        }

        #region structures
        public static DNSInfo dnsInfo = new DNSInfo();
        public class DNSInfo
        {
            public string Computer;
            public string IP_address;
        }

        public static TestData testData = new TestData();
        public class TestData
        {
            public Guid glavaID;
            public string glavaName;
            public bool isControlMode;
        }
        #endregion
    }
}
