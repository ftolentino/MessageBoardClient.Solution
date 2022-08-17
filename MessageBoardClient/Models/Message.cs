using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MessageBoardClient.Models
{
  public class Message
  {
    public int MessageId { get; set; }
    public string Name { get; set; }
    public string Comment { get; set; }
    public string PostDate { get; set; }
    public string User { get; set; } //Application User?? at somep point 

    public static List<Message> GetMessages()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Message> messageList = JsonConvert.DeserializeObject<List<Message>>(jsonResponse.ToString());

      return messageList;
    }
  }
}