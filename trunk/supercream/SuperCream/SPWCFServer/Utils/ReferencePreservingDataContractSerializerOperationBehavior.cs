using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Runtime.Serialization;
using System.ServiceModel.Description;


namespace SPWCFServer
{
    /// <summary>
    /// A specialized DataContractSerializer that has 
    /// preserveObjectReferences set true, which allows for
    /// circular references to be serialized
    /// </summary>
    public class ReferencePreservingDataContractSerializerOperationBehavior :
        DataContractSerializerOperationBehavior
    {
        #region Ctor
        public ReferencePreservingDataContractSerializerOperationBehavior(
            OperationDescription operationDescription)
            : base(operationDescription) { }
        #endregion

        #region Public Methods
        public override XmlObjectSerializer CreateSerializer(Type type, string name,
            string ns, IList<Type> knownTypes)
        {
            return CreateDataContractSerializer(type, name, ns, knownTypes);
        }

        public override XmlObjectSerializer CreateSerializer(Type type,
            XmlDictionaryString name, XmlDictionaryString ns, IList<Type> knownTypes)
        {
            return new DataContractSerializer(type, name, ns, knownTypes,
                2147483646 /*maxItemsInObjectGraph*/,
                false/*ignoreExtensionDataObject*/,
                true/*preserveObjectReferences*/,
                null/*dataContractSurrogate*/);
        }
        #endregion

        #region Private Methods
        private static XmlObjectSerializer CreateDataContractSerializer(Type type,
            string name, string ns, IList<Type> knownTypes)
        {
            return CreateDataContractSerializer(type, name, ns, knownTypes);
        }
        #endregion
    }
}
