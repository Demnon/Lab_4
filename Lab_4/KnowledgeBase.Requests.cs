

namespace Lab_4
{
    public partial class KnowledgeBase
    {
        // Префиксы
        const string s_PrefixCl = "URN:classes:stock";
        const string s_PrefixPr = "URN:properties:stock";
        const string s_PrefixIns = "URN:instanses:stock";
        const string s_PrefixOwl = "http://www.w3.org/2002/07/owl#";
        const string s_PrefixRdf = "http://www.w3.org/1999/02/22-rdf-syntax-ns#";
        const string s_PrefixRdfs = "http://www.w3.org/2000/01/rdf-schema#";
        const string s_PrefixRdfType = "rdf:type";


        private static string GetRequests(string s_NameRequest, string s_Name = "")
        {
            switch (s_NameRequest)
            {
                case "getnamesformulas":
                    return @"
                            prefix cl:<" + s_PrefixCl + @">
                            prefix pr:<" + s_PrefixPr + @">
                            prefix ins:<" + s_PrefixIns + @">
                            prefix owl:<" + s_PrefixOwl + @">
                            prefix rdf:<" + s_PrefixRdf + @">
                            prefix rdfs:<" + s_PrefixRdfs + @">

                            SELECT ?formula ?label WHERE
                            {?formula a cl:Formula.
                                ?formula rdfs:label ?label.
                            }";
                case "getinputparameters":
                    return @"
                            prefix cl:<" + s_PrefixCl + @">
                            prefix pr:<" + s_PrefixPr + @">
                            prefix ins:<" + s_PrefixIns + @">
                            prefix owl:<" + s_PrefixOwl + @">
                            prefix rdf:<" + s_PrefixRdf + @">
                            prefix rdfs:<" + s_PrefixRdfs + @">

                            SELECT ?input ?label WHERE
                            {?input pr:input " + s_Name + @".
                                ?input rdfs:label ?label.
                            }";
                case "getoutputparameter":
                    return @"
                            prefix cl:<" + s_PrefixCl + @">
                            prefix pr:<" + s_PrefixPr + @">
                            prefix ins:<" + s_PrefixIns + @">
                            prefix owl:<" + s_PrefixOwl + @">
                            prefix rdf:<" + s_PrefixRdf + @">
                            prefix rdfs:<" + s_PrefixRdfs + @">

                            SELECT ?output ?label WHERE
                            {?output pr:output " + s_Name + @".
                                ?output rdfs:label ?label.
                            }";
                case "getnamefile":
                    return @"
                            prefix cl:<" + s_PrefixCl + @">
                            prefix pr:<" + s_PrefixPr + @">
                            prefix ins:<" + s_PrefixIns + @">
                            prefix owl:<" + s_PrefixOwl + @">
                            prefix rdf:<" + s_PrefixRdf + @">
                            prefix rdfs:<" + s_PrefixRdfs + @">

                            SELECT ?namefile ?label WHERE
                            {?namefile pr:nameFile " + s_Name + @".
                                ?namefile rdfs:label ?label.
                            }";
                default:
                    return "";
            }
        }
    }
}
