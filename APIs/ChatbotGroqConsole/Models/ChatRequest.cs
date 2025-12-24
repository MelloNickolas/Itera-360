using System.Collections.Generic;

namespace Models
{
  public class ChatRequest
  {
    public string model { get; set; } = "llama-3.3-70b-versatile";
    public List<Message> messages { get; set; } = new();

    public double? temperature { get; set; } = 0.4;
    public int? max_tokens { get; set; } = 512;
  }
}
