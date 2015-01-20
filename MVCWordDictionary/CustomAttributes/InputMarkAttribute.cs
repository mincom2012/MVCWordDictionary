using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWordDictionary.CustomAttribute
{
    public class InputMarkAttribute : Attribute, IMetadataAware
    {
        private string _mask = string.Empty;

        public InputMarkAttribute(string mask)
        {
            _mask = mask;
        }

        public string Mask
        {
            get
            {
                return _mask;
            }
        }

        private const string scriptText = "<script type='text/javascript'> $(document).ready(function () {{ $('#{0}').mark('{1}'); }}); </script>";

        public const string templateHint = "_mark";

        private int _count;

        public string Id
        {
            get
            {
                return "maskedInput_" + _count;
            }
        }

        internal HttpContextBase Context
        {
            get
            {
                return new HttpContextWrapper(HttpContext.Current);
            }
        }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            var lst = Context.Items["Scripts"] as IList<string> ?? new List<string>();
            _count = lst.Count;
            metadata.TemplateHint = templateHint;
            metadata.AdditionalValues[templateHint] = Id;
            lst.Add(string.Format(scriptText, Id, Mask));
            Context.Items["Scripts"] = lst;
        }
    }


}