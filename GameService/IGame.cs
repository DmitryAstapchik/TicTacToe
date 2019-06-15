using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace GameService
{
    [ServiceContract]
    public interface IGame
    {
        [OperationContract]
        GameState GetData(Guid guid);

        [OperationContract]
        void DoTurn(Guid clientId, int position);

        [OperationContract]
        Guid SendName(string name);

        [OperationContract]
        void Reset(Guid guid);

        [OperationContract]
        void EndGame(Guid guid);

        [OperationContract]
        void SetOff(Guid guid);

        [OperationContract]
        int GetGames();

        [OperationContract]
        void SetMessage(Guid guid, string[] message);

        [OperationContract]
        void SendReady(Guid guid, bool ready, string name);
    }

    [DataContract]
    public class GameState
    {
        [DataMember]
        public bool Ready1 { get; set; }

        [DataMember]
        public bool Ready2 { get; set; }

        [DataMember]
        public string[] Message { get; set; } = new string[3];

        [DataMember]
        public bool On { get; set; } = true;

        [DataMember]
        public int Position { get; set; }

        [DataMember]
        public bool CrossNext { get; set; } = true;

        [DataMember]
        public string Name1 { get; set; } = "";

        [DataMember]
        public string Name2 { get; set; } = "";
    }
}