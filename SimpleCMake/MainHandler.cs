﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reactive;
using System.Threading.Tasks;
using CMakeUtils;
using SimpleCMake.Dialogs;

namespace SimpleCMake
{
    public class MainHandler
    {
        public MainHandler()
        {
            Exit = ReactiveCommand.Create(_Exit);
            NewFile = ReactiveCommand.Create(_NewFile);
            OpenFile = ReactiveCommand.Create(_OpenFile);
            AddHdrs = ReactiveCommand.Create(_AddHdrs);
            AddProj = ReactiveCommand.Create(_AddProj);
            AddSrcs = ReactiveCommand.Create(_AddSrcs);

            if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime)
                desktop = (IClassicDesktopStyleApplicationLifetime)Application.Current.ApplicationLifetime;
            else
                desktop = null;
        }

        public static CMakeScript script = new CMakeScript();

        public ReactiveCommand<Unit, Unit> Exit { get; }
        public ReactiveCommand<Unit, Unit> NewFile { get; }
        public ReactiveCommand<Unit, Unit> OpenFile { get; }
        public ReactiveCommand<Unit, Unit> AddProj { get; }
        public ReactiveCommand<Unit, Unit> AddSrcs { get; }
        public ReactiveCommand<Unit, Unit> AddHdrs { get; }

        private IClassicDesktopStyleApplicationLifetime desktop;

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
        private async void _AddProj()
        {
            if (desktop != null)
                await new NewProjectDialog().ShowDialog(desktop.MainWindow);
        }
        private void _AddSrcs()
        {
            if (desktop != null)
            {
                OpenFolderDialog folderDialog = new OpenFolderDialog();
                folderDialog.Title = "Choose source folder";
                Task<string> folderTask = folderDialog.ShowAsync(desktop.MainWindow);
                folderTask.Wait();
                string folder = folderTask.Result;
                string[] srcs = Directory.GetFiles(folder, "*.cpp");
            }
            else
            {
                Console.Error.WriteLine("Main window not found. Folder for sources cannot be choose.");
            }
        }
        private void _AddHdrs()
        {
            //pass
        }
    }
}