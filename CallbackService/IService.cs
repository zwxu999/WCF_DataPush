using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CallbackService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IServiceCallback))]
    public interface IService
    {
        [OperationContract(IsOneWay = true)]
        void Seed();
        [OperationContract(IsOneWay = true)]
        void StartSpam(int interval);
        [OperationContract(IsOneWay = true)]
        void StopSpam();
    }

    public interface IServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void SendOffer(Book offer);

        [OperationContract(IsOneWay = true)]
        void SendContext(Book[] context);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    
    public class Book
    {
        public int Id { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Author { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string ImgPath { get; set; }

    }
}
