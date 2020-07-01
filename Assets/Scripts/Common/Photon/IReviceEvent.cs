using System.Collections.Generic;
public interface IReviceEvent
{
    void ReviceEvent(byte Code, Dictionary<byte, object> Parameters);
}
