using general.win.condition.single;

namespace general.win.condition
{
    public class WinCheckOne : WinCheckBase
    {
        public override WinConditionBase Create()
        {
            var winCheck = new WinConditionMain();
            winCheck
                .SetNext(new WinConditionTie())
                /*.SetNext(new WinConditionFinale())*/;

            return winCheck;
        }
    }
}