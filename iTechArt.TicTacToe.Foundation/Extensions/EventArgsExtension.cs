using System;

namespace iTechArt.TicTacToe.Foundation.Extensions
{
    public static class EventArgsExtension
    {
        public static void Raise<TEventArgs>(this TEventArgs e, EventHandler<TEventArgs> eventHandler, object sender)
        {
            eventHandler?.Invoke(sender, e);
        }
    }
}