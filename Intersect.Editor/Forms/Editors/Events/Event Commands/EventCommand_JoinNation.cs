using System;
using System.Windows.Forms;

using Intersect.Editor.Localization;
using Intersect.GameObjects;
using Intersect.GameObjects.Events;
using Intersect.GameObjects.Events.Commands;

namespace Intersect.Editor.Forms.Editors.Events.Event_Commands
{

    public partial class EventCommandJoinNation : UserControl
    {

        private readonly FrmEvent mEventEditor;

        private EventPage mCurrentPage;

        private JoinNationCommand mMyCommand;

        public EventCommandJoinNation(JoinNationCommand refCommand, EventPage page, FrmEvent editor)
        {
            InitializeComponent();
            mMyCommand = refCommand;
            mCurrentPage = page;
            mEventEditor = editor;

            InitLocalization();
            cmbVariable.Items.Clear();
            cmbVariable.Items.AddRange(PlayerVariableBase.Names);

            if (mMyCommand.VariableId != null && mMyCommand.VariableId != Guid.Empty)
            {
                cmbVariable.SelectedIndex = PlayerVariableBase.ListIndex(mMyCommand.VariableId);
            }
            else if (cmbVariable.Items.Count > 0)
            {
                cmbVariable.SelectedIndex = 0;
            }
        }

        private void InitLocalization()
        {
            grpJoinNation.Text = Strings.EventJoinNation.Title;
            lblVariable.Text = Strings.EventJoinNation.SelectVariable;
            btnSave.Text = Strings.EventJoinNation.Okay;
            btnCancel.Text = Strings.EventJoinNation.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            mMyCommand.VariableId = PlayerVariableBase.IdFromList(cmbVariable.SelectedIndex);
            mEventEditor.FinishCommandEdit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mEventEditor.CancelCommandEdit();
        }

        private void cmbVariable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }

}
