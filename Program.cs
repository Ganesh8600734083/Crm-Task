using CrmEarlyBound;
using Microsoft.Ajax.Utilities;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using Polly;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using XrmToolkit.Linq;


namespace coonections
{
    class Program
    {
        static void Main(string[] args)
        {
            using (CrmServiceClient svcClient = new CrmServiceClient(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                if (!svcClient.IsReady)
                {
                    Console.WriteLine("unable to connect!");

                    return;
                }

                WhoAmIRequest request = new WhoAmIRequest();
                WhoAmIResponse response = (WhoAmIResponse)svcClient.Execute(request);

                Console.WriteLine("UserId =" + response.UserId.ToString());
                //performing crud operations through late binding
                // Create a new record

                //var myContact = new Entity("STUDENT");
                //myContact.Attributes["FirstName"] = "GANESH";
                //myContact.Attributes["LastName"] = "GUNJAL";
                // Guid cr06_STUDENTid = svcClient.Create(myContact);
                //Console.WriteLine("Contact create with ID - " + cr06_STUDENTid);
                //Console.ReadLine();

                ////Update record
                //Entity entContact = new Entity("STUDENT");
                //entContact.Id = cr06_STUDENTid;
                //entContact.Attributes["lastname"] = "RAMESH";
                //svcClient.Update(entContact);
                //Console.WriteLine("Contact lastname updated");

                //////DELETE RECORD
                //svcClient.Delete("contact", cr06_STUDENTid);

                ////Retrieve Multiple Record by using query expression
                //QueryExpression qe = new QueryExpression("COURCE");
                //qe.ColumnSet = new ColumnSet("courcename");
                //EntityCollection ec = svcClient.RetrieveMultiple(qe);

                //for (int i = 0; i < ec.Entities.Count; i++)
                //{
                //    if (ec.Entities[i].Attributes.ContainsKey("courcename"))
                //    {
                //        Console.WriteLine(ec.Entities[i].Attributes["courcename"]);
                //    }
                //}
                //Console.WriteLine("Retrieved all Contacts...");
                //using linq query
                //var query1 = from c in context.CreateQuery<Contact>()
                //             orderby c.FullName ascending
                //             select c;
                //foreach (var q in query1)
                //{
                //    Console.WriteLine(q.FirstName + " " + q.LastName);
                //}


                //using FatchXML
                //string fetchxml = @"<fetch version='1.0' output-format='xml - platform' mapping='logical' distinct='true'>
                //           < entity name = 'cr06e_classroom' >

                //          < attribute name = 'cr06e_classroomid' />

                //        < attribute name = 'cr06e_name' />

                //       < attribute name = 'createdon' />

                //     < order attribute = 'cr06e_name' descending = 'false'/>

                //       < filter type = 'and' >

                //    < condition attribute = 'cr06e_classroomid' operator= 'eq' />

                // </ filter >

                // < link - entity name = 'cr06e_student' from = 'cr06e_classroom' to = 'cr06e_classroomid' link - type = 'inner' alias = 'aa' />

                //            </ entity >
                //          </ fetch > ";
                //  EntityCollection cr06e_student = svcClient.RetrieveMultiple(new FetchExpression(fetchxml));
                //string str = string.Empty;
                //foreach (Entity e in cr06e_student.Entities)
                //{
                //    str = str + e.Attributes["Name"].ToString();
                //}
                //throw new InvalidPluginExecutionException(str);

                // by using early bound class
                cr06e_SUBJECT subjectsvc = new cr06e_SUBJECT();
                subjectsvc.cr06e_Name = "Math";
                Guid cr06e_SUBJECTId = svcClient.Create(subjectsvc);
                Console.WriteLine("Contact create with ID - " + cr06e_SUBJECTId);
                Console.ReadLine();
                
                //early bound class for teacher
                cr06e_TEACHER teachersvc = new cr06e_TEACHER();
                teachersvc.cr06e_FirstName = "mahi";
                teachersvc.cr06e_LastName = "yadav";
                Guid cr06e_TEACHERId = svcClient.Create(teachersvc);
                Console.WriteLine("contact created with ID-"+ cr06e_TEACHERId);
                Console.ReadLine();

                
               







            }

        }
    }
}
