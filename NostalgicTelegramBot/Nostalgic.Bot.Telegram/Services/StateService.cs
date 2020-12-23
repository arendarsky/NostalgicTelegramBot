using System.Collections.Generic;
using Nostalgic.Bot.Telegram.Models;

namespace Nostalgic.Bot.Telegram.Services
{
    internal interface IStateService
    {
        State GetState(Player player);
        void UpdateState(Player player, State state);
        void AddSentMessagesId(Player player, IEnumerable<int> messagesId);
    }

    internal class StateService: IStateService
    {
        private readonly IDictionary<string, State> _states;

        public StateService()
        {
            _states = new Dictionary<string, State>();
        }

        public State GetState(Player player)
        {
            var key = player.GetHash();

            return _states.TryGetValue(key, out var state) ? state : State.Default;
        }

        public void UpdateState(Player player, State state)
        {
            var key = player.GetHash();
            _states[key] = state;
        }

        public void AddSentMessagesId(Player player, IEnumerable<int> messagesId)
        {
            var key = player.GetHash();

            if (!_states.TryGetValue(key, out var state))
            {
                state = State.Default;
                _states[key] = state;
            }

            state.UpdateSentMessagesId(messagesId);
        }
    }
}
