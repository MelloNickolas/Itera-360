using System.Collections.Generic;

namespace Models
{
  public class ChatResponse
  {
    public string id { get; set; } = "";
    public List<Choice> choices { get; set; } = new();
    public Usage? usage { get; set; }

    public class Choice
    {
      public int index { get; set; }
      public Message message { get; set; } = new();
      public string? finish_reason { get; set; }
    }

    public class Usage
    {
      public int prompt_tokens { get; set; }
      public int completion_tokens { get; set; }
      public int total_tokens { get; set; }
    }
  }
}
