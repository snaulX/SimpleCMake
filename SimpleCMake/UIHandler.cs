using System;
using System.Collections.Generic;
using System.Reactive;
using ReactiveUI;

namespace SimpleCMake
{
    public class UIHandler
    {
        public UIHandler()
        {
            Exit = ReactiveCommand.Create(_Exit);
            NewFile = ReactiveCommand.Create(_NewFile);
            OpenFile = ReactiveCommand.Create(_OpenFile);
            AddHdrs = ReactiveCommand.Create(_AddHdrs);
            AddProj = ReactiveCommand.Create(_AddProj);
            AddSrcs = ReactiveCommand.Create(_AddSrcs);
        }

        public ReactiveCommand<Unit, Unit> Exit { get; }
        public ReactiveCommand<Unit, Unit> NewFile { get; }
        public ReactiveCommand<Unit, Unit> OpenFile { get; }
        public ReactiveCommand<Unit, Unit> AddProj { get; }
        public ReactiveCommand<Unit, Unit> AddSrcs { get; }
        public ReactiveCommand<Unit, Unit> AddHdrs { get; }

        private void _Exit()
        {
            Environment.Exit(0);
        }
        private void _NewFile()
        {
            //pass
        }
        private void _OpenFile()
        {
            //pass
        }
        private void _AddProj()
        {
            //pass
        }
        private void _AddSrcs()
        {
            //pass
        }
        private void _AddHdrs()
        {
            //pass
        }
    }
}
