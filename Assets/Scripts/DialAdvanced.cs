using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialAdvanced : MonoBehaviour
{
    private int[] cableShape;
    
    private DialConnection[] connections;
    public struct DialConnection
    {
        public DialAdvanced directConnection;
        public List<DialAdvanced> indirectConnections;
    }

    public void GetIndirectConnections(int connectionPosition, ref List<DialAdvanced> indirectConnections)
    {
        for (int i = 0; i < connections.Length; i++)
        {
            if (i != connectionPosition)
            {
                GetIndirectConnections(i, ref indirectConnections);
            }
        }
    }
    
    public void onChange()
    {
        for (int i = 0; i < connections.Length; i++)
        {
            connections[i].indirectConnections = new List<DialAdvanced>();
            connections[i].directConnection.GetIndirectConnections(i, ref connections[i].indirectConnections);
        }
    }
}
