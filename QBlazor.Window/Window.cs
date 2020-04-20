﻿using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace QBlazor
{
    public class Window : IWindow
    {
        public IHistory History { get; }

        public INavigator Navigator { get; }

        public ICookie Cookie { get; }

        private readonly IJSRuntime jsRuntime;

        public Window(IJSRuntime jSRuntime)
        {
            this.jsRuntime = jSRuntime;

            this.History = new History(this.jsRuntime);
            this.Navigator = new Navigator(this.jsRuntime);
            this.Cookie = new Cookie(this.jsRuntime);
        }

        public async Task Alert(string message)
        {
            await jsRuntime.InvokeVoidAsync("alert", message);
        }

        public async Task Open(string url)
        {
            if (Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
            {
                await jsRuntime.InvokeVoidAsync("open", url);
            }
        }
    }
}