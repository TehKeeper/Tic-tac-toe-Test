namespace general.win.condition
{
    public class WinCheckOne : WinCheckBase
    {
        public override WinConditionBase Create()
        {
            var winCheck = new WinConditionTie();
            winCheck
                .SetNext(new WinConditionMain())
                .SetNext(new WinConditionFinale());

            return winCheck;
        }
    }
}