using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.ServiceModel.Activation;
using System.IO;
using System.Net;

namespace DemoWCFService
{
   // the next line is added for no .svc URIs
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
   public class Service1 : IService1
   {
      public Artist GetArtist(string id)
      {
         Artist player = new Artist(Convert.ToInt32(id), "Shirley", "Horn", "9");
         return player;
      }

      public Artist TestPost(Stream stream)
      {
          StreamReader reader = new StreamReader(stream);
          string data = reader.ReadToEnd();
          char[] delimiterChars = { '&' };
          string[] words = data.Split(delimiterChars);

          Artist player = new Artist(1000, words[0].Substring(words[0].IndexOf("=") + 1), 
              words[1].Substring(words[1].IndexOf("=") + 1),
              words[2].Substring(words[2].IndexOf("=") + 1));
          return player;
       
      }

   }
}
