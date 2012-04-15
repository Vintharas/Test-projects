using System.Windows.Input;

namespace Chapter9_CreatingCustomCommands
{
    public class ReverseCommand
    {
        private static RoutedUICommand reverse;
        public static RoutedUICommand Reverse { get { return reverse; } }

        static ReverseCommand()
        {
            InputGestureCollection gestures = new InputGestureCollection();
            gestures.Add(new KeyGesture(Key.R, ModifierKeys.Control, "Control-R"));
            reverse = new RoutedUICommand("Reverse", // Description
                                          "Reverse", // Name of the command
                                          typeof (ReverseCommand), // Type registerting of the command
                                          gestures); // collection of InputGestures
        }
    }
}