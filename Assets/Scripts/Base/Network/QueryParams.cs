using System.Collections.Generic;
using UnityEngine;
namespace LTAUnityBase.Base.Network
{
    public class QueryParams
    {
        private Dictionary<string, string> parameters;

        public QueryParams()
        {
            parameters = new Dictionary<string, string>();
        }

        public QueryParams(Dictionary<string,string> queries)
        {
            parameters = queries;
        }

        public void AddParam(string key, string value)
        {
            parameters.Add(key, value);
        }

        public override string ToString()
        {
            if (parameters.Count == 0)
            {
                return "";
            }
            string strQueries = "";
            foreach (KeyValuePair<string, string> query in parameters)
            {
                if (strQueries == "") strQueries = "?";
                strQueries += query.Key + "=" + query.Value + "&";
            }
            strQueries =  strQueries.Remove(strQueries.Length-1,1);
            return strQueries;
        }
    }
}
