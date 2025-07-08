using Services;
using LogicExt;

namespace RefactoringPlan
{
    public class QuitCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Thank you for playing! Hope to see you again soon!");
        }
    }
}
