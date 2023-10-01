// See https://aka.ms/new-console-template for more information

using RemoteController.Commands;
using System.Text;

namespace RemoteController
{
    public class RemoteControl
    {
        private List<ICommand> onCommands;
        private List<ICommand> offCommands;
        private ICommand undoCommand { get; set; }
        private const int BUTTONS_COUNT = 7;

        public RemoteControl()
        {
            onCommands = new List<ICommand>(BUTTONS_COUNT);
            offCommands = new List<ICommand>(BUTTONS_COUNT);

            var noCommand = new NoCommand();
            undoCommand = noCommand;
            for (int i = 0; i < BUTTONS_COUNT; i++)
            {
                onCommands.Add(noCommand);
                offCommands.Add(noCommand);
            }
        }

        public void SetCommand(int slot, ICommand onCommand, ICommand offCommand)
        {
            onCommands[slot] = onCommand;
            offCommands[slot] = offCommand;
        }

        public void PressOnButton(int slot)
        {
            onCommands[slot].Execute();
            undoCommand = onCommands[slot];
        }

        public void PressOffButton(int slot)
        {
            offCommands[slot].Execute();
            undoCommand = offCommands[slot];
        }

        public void PressUndoButton()
        {
            undoCommand.Undo();
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("------ Remote Control ------");
            for (int i = 0; i < BUTTONS_COUNT; i++)
            {
                stringBuilder.AppendLine($"[slot {i}] - {onCommands[i].Name}");
            }
            return stringBuilder.ToString();
        }
    }
}