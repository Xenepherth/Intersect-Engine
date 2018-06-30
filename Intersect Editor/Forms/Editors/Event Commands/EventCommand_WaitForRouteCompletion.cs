﻿using System;
using System.Linq;
using System.Windows.Forms;
using Intersect.Editor.Localization;
using Intersect.GameObjects.Events;
using Intersect.GameObjects.Maps;

namespace Intersect.Editor.Forms.Editors.Event_Commands
{
    public partial class EventCommandWaitForRouteCompletion : UserControl
    {
        private readonly EventBase mEditingEvent;
        private MapBase mCurrentMap;
        private EventCommand mEditingCommand;
        private FrmEvent mEventEditor;

        public EventCommandWaitForRouteCompletion(EventCommand refCommand, FrmEvent eventEditor, MapBase currentMap,
            EventBase currentEvent)
        {
            InitializeComponent();

            //Grab event editor reference
            mEventEditor = eventEditor;
            mEditingEvent = currentEvent;
            mEditingCommand = refCommand;
            mCurrentMap = currentMap;
            InitLocalization();
            cmbEntities.Items.Clear();
            if (!mEditingEvent.CommonEvent)
            {
                cmbEntities.Items.Add(Strings.EventWaitForRouteCompletion.player);
                if (mEditingCommand.Ints[0] == -1) cmbEntities.SelectedIndex = -1;
                foreach (var evt in mCurrentMap.LocalEvents)
                {
                    cmbEntities.Items.Add(evt.Key == mEditingEvent.Index
                        ? Strings.EventWaitForRouteCompletion.This + " "
                        : "" + evt.Value.Name);
                    if (mEditingCommand.Ints[0] == evt.Key) cmbEntities.SelectedIndex = cmbEntities.Items.Count - 1;
                }
            }
            if (cmbEntities.SelectedIndex == -1 && cmbEntities.Items.Count > 0)
            {
                cmbEntities.SelectedIndex = 0;
            }

            mEditingCommand = refCommand;
            mEventEditor = eventEditor;
        }

        private void InitLocalization()
        {
            grpWaitRoute.Text = Strings.EventWaitForRouteCompletion.title;
            lblEntity.Text = Strings.EventWaitForRouteCompletion.label;
            btnSave.Text = Strings.EventWaitForRouteCompletion.okay;
            btnCancel.Text = Strings.EventWaitForRouteCompletion.cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!mEditingEvent.CommonEvent)
            {
                if (cmbEntities.SelectedIndex == 0)
                {
                    mEditingCommand.Ints[0] = -1;
                }
                else
                {
                    mEditingCommand.Ints[0] = mCurrentMap.LocalEvents.Keys.ToList()[cmbEntities.SelectedIndex - 1];
                }
            }
            mEventEditor.FinishCommandEdit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mEventEditor.CancelCommandEdit();
        }
    }
}