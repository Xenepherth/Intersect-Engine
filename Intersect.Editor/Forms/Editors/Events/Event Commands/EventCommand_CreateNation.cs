using System;
using System.Windows.Forms;

using Intersect.Editor.Localization;
using Intersect.GameObjects;
using Intersect.GameObjects.Events;
using Intersect.GameObjects.Events.Commands;

namespace Intersect.Editor.Forms.Editors.Events.Event_Commands
{

    public partial class EventCommandCreateNation : UserControl
    {

        private readonly FrmEvent mEventEditor;

        private EventPage mCurrentPage;

        private CreateNationCommand mMyCommand;

        public EventCommandCreateNation(CreateNationCommand refCommand, EventPage page, FrmEvent editor)
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
            grpCreateNation.Text = Strings.EventCreateNation.Title;
            lblVariable.Text = Strings.EventCreateNation.SelectVariable;
            btnSave.Text = Strings.EventCreateNation.Okay;
            btnCancel.Text = Strings.EventCreateNation.Cancel;
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
