using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;  
using System.ServiceModel.Channels;
using System.Text;
using Model;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        //[OperationContract]
        //Cat CreatCat(Cat cat); 

        //[OperationContract]
        //string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        PizzaMenu CheckPizzaOrder(PizzaMenu order);

        [OperationContract]
        bool AddUser(User user);

        // TODO: Add your service operations here
        [OperationContract]
        bool AddDog(Dog dog);

        [OperationContract]
        bool AddCat(Cat cat);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WcfServiceLibrary1.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }


    }
    [DataContract]
    public class PizzaMenu
    {
        string name;
        int price;

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        [DataMember]
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        
    }
    //[DataContract]
    //public class Cat
    //{
    //    private string name;
    //    private int age;
    //    private string type;
    //    private double weight;
    //    private bool likeMyau;

    //    [DataMember]
    //    public string Name { get => name; set => name = value; }
    //    [DataMember]
    //    public int Age { get => age; set => age = value; }
    //    [DataMember]
    //    public string Type { get => type; set => type = value; }
    //    [DataMember]
    //    public double Weight { get => weight; set => weight = value; }
    //    [DataMember]
    //    public bool LikeMyau { get => likeMyau; set => likeMyau = value; }
    //}
}
