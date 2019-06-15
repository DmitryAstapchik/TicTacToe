using System;
using System.Collections.Generic;
using System.Linq;

namespace GameService
{
    public class Game : IGame
    {
        static Dictionary<Guid, GameState> games = new Dictionary<Guid, GameState>();
        public GameState GetData(Guid guid)
        {
            return games[guid];
        }

        public int GetGames()
        {
            return games.Count;
        }

        public void DoTurn(Guid guid, int position)
        {
            GetData(guid).Position = position;
        }

        public Guid SendName(string name)
        {
            Guid guid;
            if (games.Count == 0)
            {
                games.Add(guid = Guid.NewGuid(), new GameState());
                if (name == "Player")
                {
                    games.ElementAt(0).Value.Name1 = "Player1";
                }
                else
                {
                    games.ElementAt(0).Value.Name1 = name;
                }
                games.Last().Value.CrossNext = true;
                return guid;
            }
            else
            {
                var firstVacant = games.FirstOrDefault(g => g.Value.Name2 == "");
                if (!firstVacant.Equals(default(KeyValuePair<Guid, GameState>)))
	            {
                    if (name == "Player")
                    {
                        firstVacant.Value.Name2 = "Player2";
                    }
                    else
                    {
                        firstVacant.Value.Name2 = name;
                    }
                    firstVacant.Value.CrossNext = false;
                    return firstVacant.Key;
	            }
                else
                {
                    games.Add(guid = Guid.NewGuid(), new GameState());
                    if (name == "Player")
                    {
                        games.First(g => g.Key == guid).Value.Name1 = "Player1";
                    }
                    else
                    {
                        games.First(g => g.Key == guid).Value.Name1 = name;
                    }
                    games.First(g => g.Key == guid).Value.CrossNext = true;
                    return guid;
                }
            }
        }

        public void Reset(Guid guid)
        {
            GetData(guid).Position = 0;
        }

        public void EndGame(Guid guid)
        {
            games.Remove(guid);
        }

        public void SetOff(Guid guid)
        {
            games[guid].On = false;
        }

        public void SetMessage(Guid guid, string[] message)
        {
            GetData(guid).Message = message;
        }

        public void SendReady(Guid guid, bool ready, string name)
        {
            if (GetData(guid).Name1 == name)
            {
                GetData(guid).Ready1 = ready;
            }
            else
            {
                GetData(guid).Ready2 = ready;
            }
        }
    }
}