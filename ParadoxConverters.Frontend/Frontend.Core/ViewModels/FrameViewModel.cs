﻿
using Caliburn.Micro;
using Frontend.Core.Commands;
using Frontend.Core.Events.EventArgs;
using Frontend.Core.ViewModels.Interfaces;
using System.Collections.Generic;
using System.Windows.Input;
namespace Frontend.Core.ViewModels
{
    public class FrameViewModel : StepConductorBase, IFrameViewModel
    {
        #region [ Fields ]

        private ILogViewModel logViewModel;
        private ICommand moveCommand;

        #endregion 

        public FrameViewModel(IEventAggregator eventAggregator)
            : base(eventAggregator)
        {
        }

        #region [ Properties ]

        public ILogViewModel Log
        {
            get
            {
                return this.logViewModel ?? (this.logViewModel = new LogViewModel(this.EventAggregator));
            }
        }

        public ICommand MoveCommand
        {
            get
            {
                return this.moveCommand ?? (this.moveCommand = new MoveCommand(this.EventAggregator, this));
            }
        }

        #endregion

        public void Handle(PreferenceStepOperationArgs message)
        {
            switch(message.Operation)
            {
                case PreferenceOperation.AddSteps:
                    this.AddPreferenceSteps(message.NewSteps);
                    break;

                case PreferenceOperation.Clear:
                    this.RemovePreferenceSteps();
                    break;
            }
        }

        private void AddPreferenceSteps(IList<IStep> newSteps)
        {
            foreach(IStep step in newSteps)
            {
                this.Steps.Add(step);
            }
        }

        private void RemovePreferenceSteps()
        {
            // Assumption: The first two steps are:
            // The welcome view
            // The path picker view
            // So we remove everything else.
            for (int i = 1; i < this.Steps.Count; i ++)
            {
                this.Steps.RemoveAt(i);
            }
        }
    }
}
