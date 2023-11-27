using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NetProgramm
{
    internal class Message
    {
        string Text {  get; set; }
        DateTime DateTime { get; set; }
        string? NickNameFrom { get; set; }
        string? NickNameTo { get; set; }

        public string SerialazeMessageToJSON() => JsonSerializer.Serialize(this);
     
        public static Message? DeserializeMessgeFromJSON(string message) => JsonSerializer.Deserialize<Message>(message);

        public string PrintGetMessageFrom()
        {
            return ToString();
        }

        public override string ToString()
        {
            return $"{DateTime} \n Получено сообщение {Text} \n от {NickNameFrom}  ";
        }
    }
}
