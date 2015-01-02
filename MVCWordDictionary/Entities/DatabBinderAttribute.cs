using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWordDictionary.Models
{
    public class DatabBinderAttribute : Attribute, IMetadataAware
    {

        private readonly string _bindingValue;

        public DatabBinderAttribute(params string[] bindings)
        {
            string temp = string.Empty;
            Array.ForEach(bindings, b => temp += b + ",");
            _bindingValue = temp;
        }


        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.AdditionalValues[DataBindHelper.BindingKey] = _bindingValue;
        }



    }

    public static class DataBindHelper
    {

        public const string BindingKey = "required";
        public static string GetBinding(this HtmlHelper html, ModelMetadata metadata)
        {
            object value;
            metadata.AdditionalValues.TryGetValue(BindingKey, out value);
            return (string)value;
        }
    }
}