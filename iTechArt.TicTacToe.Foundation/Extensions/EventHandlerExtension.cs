using System;

namespace iTechArt.TicTacToe.Foundation.Extensions
{
    public static class EventHandlerExtension
    {
        public static void Raise<TEventArgs> (this EventHandler<TEventArgs> handler, object sender, TEventArgs args)
            where TEventArgs : EventArgs
        {
            handler?.Invoke(sender, args);
        }
    }
}