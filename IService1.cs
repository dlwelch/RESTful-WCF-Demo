using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace DemoWCFService
{

   [ServiceContract]
   
   public interface IService1
   {

      [OperationContract]
      [XmlSerializerFormat]
      [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Xml,
          UriTemplate = "artists/{id}")]
      Artist GetArtist(string id);

      [XmlSerializerFormat]
      [WebInvoke(Method = "POST", 
           UriTemplate = "artists")]
      Artist TestPost(Stream stream);
   }


   [XmlRoot(ElementName = "Artist")]
   public class Artist
   {
      [XmlAttribute("uri")]
      public string theUri { get; set; }

      [XmlAttribute("rel")]
      public string theRel { get; set; }

      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Grammys { get; set; }

      public Artist() { }

      public Artist(int artistid, string firstName, string lastName, string grammys)
      {
         this.theRel = "edit";
         this.theUri = "/artists/" + artistid;
         this.FirstName = firstName;
         this.LastName = lastName;
         this.Grammys = grammys;
      }
   }
}
